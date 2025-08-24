using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Calculator.Models;
using Calculator.Config;

namespace Calculator.Services
{
    /// <summary>
    /// Serviço para cálculo de folha de pagamento CLT
    /// </summary>
    public class CltPayrollCalculator
    {
        private readonly ConfiguracaoTributaria _config;

        public CltPayrollCalculator(ConfiguracaoTributaria? config = null)
        {
            _config = config ?? ConfiguracaoTributaria.Carregar();
        }

        /// <summary>
        /// Calcula o salário líquido detalhado
        /// </summary>
        /// <param name="parametros">Parâmetros de entrada</param>
        /// <returns>Resultado detalhado do cálculo</returns>
        public ResultadoFolha CalcularDetalhado(ParametrosFolha parametros)
        {
            // Validação dos parâmetros
            ValidarParametros(parametros);

            var resultado = new ResultadoFolha
            {
                Parametros = parametros,
                SalarioBrutoMensal = parametros.SalarioBrutoMensal,
                VersaoConfiguracao = _config.Versao
            };

            // Calcular INSS
            resultado.DetalheInss = CalcularInss(parametros.SalarioBrutoMensal);

            // Calcular IRRF
            resultado.DetalheIrrf = CalcularIrrf(parametros, resultado.DetalheInss.ValorTotal);

            // Processar benefícios e descontos
            resultado.BeneficiosDescontos = ProcessarBeneficiosDescontos(parametros);

            // Calcular FGTS (empregador)
            resultado.FgtsEmpregador = CalcularFgts(parametros.SalarioBrutoMensal);

            // Calcular salário líquido
            resultado.SalarioLiquidoMensal = CalcularSalarioLiquido(parametros, resultado);

            // Calcular total de descontos
            resultado.TotalDescontos = resultado.SalarioBrutoMensal - resultado.SalarioLiquidoMensal;

            return resultado;
        }

        /// <summary>
        /// Valida os parâmetros de entrada
        /// </summary>
        private void ValidarParametros(ParametrosFolha parametros)
        {
            var context = new ValidationContext(parametros);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(parametros, context, results, true))
            {
                var errors = string.Join("; ", results.Select(r => r.ErrorMessage));
                throw new ArgumentException($"Parâmetros inválidos: {errors}");
            }
        }

        /// <summary>
        /// Calcula o INSS progressivo por faixas
        /// </summary>
        private DetalheInss CalcularInss(decimal salarioBruto)
        {
            var detalhe = new DetalheInss
            {
                BaseCalculo = Math.Min(salarioBruto, _config.Inss.Teto),
                LinkReferencia = _config.Fontes.Inss
            };

            decimal baseCalculo = detalhe.BaseCalculo;
            decimal limiteAnterior = 0;

            foreach (var faixa in _config.Inss.Faixas)
            {
                if (baseCalculo <= 0) break;

                decimal baseFaixa = Math.Min(baseCalculo, faixa.Limite - limiteAnterior);
                decimal valorFaixa = Arredondar(baseFaixa * faixa.Aliquota);

                if (valorFaixa > 0)
                {
                    detalhe.Faixas.Add(new DetalheFaixa(
                        limiteAnterior,
                        faixa.Limite,
                        baseFaixa,
                        faixa.Aliquota,
                        valorFaixa
                    ));
                }

                detalhe.ValorTotal += valorFaixa;
                baseCalculo -= baseFaixa;
                limiteAnterior = faixa.Limite;
            }

            detalhe.ValorTotal = Arredondar(detalhe.ValorTotal);
            return detalhe;
        }

        /// <summary>
        /// Calcula o IRRF
        /// </summary>
        private DetalheIrrf CalcularIrrf(ParametrosFolha parametros, decimal valorInss)
        {
            var detalhe = new DetalheIrrf
            {
                LinkReferencia = _config.Fontes.Irrf
            };

            // Calcular base de cálculo
            decimal baseCalculo = parametros.SalarioBrutoMensal - valorInss;

            if (parametros.UsarDescontoSimplificado)
            {
                // Usar desconto simplificado
                detalhe.DescontoSimplificado = _config.Irrf.DescontoSimplificadoMensal;
                baseCalculo -= detalhe.DescontoSimplificado;
            }
            else
            {
                // Usar deduções legais
                detalhe.DeducaoDependentes = parametros.NumeroDependentes * _config.Irrf.DeducaoDependenteMensal;
                detalhe.DeducaoPensaoAlimenticia = parametros.PensaoAlimenticia;

                baseCalculo -= detalhe.DeducaoDependentes + detalhe.DeducaoPensaoAlimenticia;

                // Subtrair descontos pré-tributação
                decimal descontosPreTributacao = parametros.DescontosPreTributacao.Sum(d => d.Valor);
                baseCalculo -= descontosPreTributacao;
            }

            detalhe.BaseCalculo = Math.Max(0, baseCalculo);

            // Encontrar faixa aplicável
            var faixaAplicavel = _config.Irrf.Faixas.FirstOrDefault(f => detalhe.BaseCalculo <= f.Limite);
            if (faixaAplicavel != null)
            {
                detalhe.FaixaAplicada = new DetalheFaixa(
                    0,
                    faixaAplicavel.Limite,
                    detalhe.BaseCalculo,
                    faixaAplicavel.Aliquota,
                    0,
                    faixaAplicavel.ParcelaDeduzir
                );

                // Calcular IRRF
                decimal irrfCalculado = (detalhe.BaseCalculo * faixaAplicavel.Aliquota) - faixaAplicavel.ParcelaDeduzir;
                detalhe.ValorTotal = Math.Max(0, Arredondar(irrfCalculado));
                detalhe.FaixaAplicada.Valor = detalhe.ValorTotal;
            }

            return detalhe;
        }

        /// <summary>
        /// Processa benefícios e descontos
        /// </summary>
        private List<ItemDesconto> ProcessarBeneficiosDescontos(ParametrosFolha parametros)
        {
            var beneficios = new List<ItemDesconto>();

            // Vale transporte (pré-tributação)
            if (parametros.ValeTransporteBasePercent > 0)
            {
                decimal valorValeTransporte = Math.Min(
                    parametros.SalarioBrutoMensal * parametros.ValeTransporteBasePercent,
                    _config.ValeTransporte.LimiteMensal
                );
                beneficios.Add(new ItemDesconto("Vale Transporte", valorValeTransporte, true));
            }

            // Outros benefícios/descontos
            if (parametros.ContribuicaoSindical > 0)
                beneficios.Add(new ItemDesconto("Contribuição Sindical", parametros.ContribuicaoSindical, true));

            if (parametros.SaudeCoparticipacao > 0)
                beneficios.Add(new ItemDesconto("Coparticipação Saúde", parametros.SaudeCoparticipacao, true));

            if (parametros.ValeRefeicaoDesconto > 0)
                beneficios.Add(new ItemDesconto("Vale Refeição", parametros.ValeRefeicaoDesconto, false));

            if (parametros.ValeAlimentacaoDesconto > 0)
                beneficios.Add(new ItemDesconto("Vale Alimentação", parametros.ValeAlimentacaoDesconto, false));

            // Adicionar descontos customizados
            beneficios.AddRange(parametros.DescontosPreTributacao);
            beneficios.AddRange(parametros.DescontosPosTributacao);

            return beneficios;
        }

        /// <summary>
        /// Calcula o FGTS (empregador)
        /// </summary>
        private decimal CalcularFgts(decimal salarioBruto)
        {
            return Arredondar(salarioBruto * _config.Fgts.Aliquota);
        }

        /// <summary>
        /// Calcula o salário líquido final
        /// </summary>
        private decimal CalcularSalarioLiquido(ParametrosFolha parametros, ResultadoFolha resultado)
        {
            decimal liquido = parametros.SalarioBrutoMensal;

            // Subtrair INSS
            liquido -= resultado.DetalheInss.ValorTotal;

            // Subtrair IRRF
            liquido -= resultado.DetalheIrrf.ValorTotal;

            // Subtrair descontos pré-tributação
            var descontosPreTributacao = resultado.BeneficiosDescontos
                .Where(d => d.PreTributacao)
                .Sum(d => d.Valor);
            liquido -= descontosPreTributacao;

            // Subtrair descontos pós-tributação
            var descontosPosTributacao = resultado.BeneficiosDescontos
                .Where(d => !d.PreTributacao)
                .Sum(d => d.Valor);
            liquido -= descontosPosTributacao;

            return Math.Max(0, Arredondar(liquido));
        }

        /// <summary>
        /// Arredonda valores para centavos usando MidpointRounding.ToEven
        /// </summary>
        private decimal Arredondar(decimal valor)
        {
            return Math.Round(valor, 2, MidpointRounding.ToEven);
        }
    }
}

