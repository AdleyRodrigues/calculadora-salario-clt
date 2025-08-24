namespace Calculator.Models
{
    /// <summary>
    /// Resultado completo do cálculo de folha de pagamento CLT
    /// </summary>
    public class ResultadoFolha
    {
        /// <summary>
        /// Parâmetros de entrada utilizados no cálculo
        /// </summary>
        public ParametrosFolha Parametros { get; set; } = new();

        /// <summary>
        /// Salário bruto mensal
        /// </summary>
        public decimal SalarioBrutoMensal { get; set; }

        /// <summary>
        /// Salário líquido mensal
        /// </summary>
        public decimal SalarioLiquidoMensal { get; set; }

        /// <summary>
        /// Detalhes do cálculo do INSS
        /// </summary>
        public DetalheInss DetalheInss { get; set; } = new();

        /// <summary>
        /// Detalhes do cálculo do IRRF
        /// </summary>
        public DetalheIrrf DetalheIrrf { get; set; } = new();

        /// <summary>
        /// Lista de benefícios e descontos
        /// </summary>
        public List<ItemDesconto> BeneficiosDescontos { get; set; } = new();

        /// <summary>
        /// FGTS (empregador) - informativo
        /// </summary>
        public decimal FgtsEmpregador { get; set; }

        /// <summary>
        /// Total de descontos
        /// </summary>
        public decimal TotalDescontos { get; set; }

        /// <summary>
        /// Data e hora do cálculo
        /// </summary>
        public DateTime DataCalculo { get; set; } = DateTime.Now;

        /// <summary>
        /// Versão da configuração tributária utilizada
        /// </summary>
        public string VersaoConfiguracao { get; set; } = string.Empty;
    }

    /// <summary>
    /// Detalhes do cálculo do INSS
    /// </summary>
    public class DetalheInss
    {
        /// <summary>
        /// Base de cálculo do INSS
        /// </summary>
        public decimal BaseCalculo { get; set; }

        /// <summary>
        /// Valor total do INSS
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Detalhes por faixa
        /// </summary>
        public List<DetalheFaixa> Faixas { get; set; } = new();

        /// <summary>
        /// Link de referência oficial
        /// </summary>
        public string LinkReferencia { get; set; } = "https://www.gov.br/inss/pt-br/servicos-do-inss/calculo-da-guia-da-previdencia-social-gps/tabela-de-contribuicao-mensal";
    }

    /// <summary>
    /// Detalhes do cálculo do IRRF
    /// </summary>
    public class DetalheIrrf
    {
        /// <summary>
        /// Base de cálculo do IRRF
        /// </summary>
        public decimal BaseCalculo { get; set; }

        /// <summary>
        /// Valor total do IRRF
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Faixa aplicada
        /// </summary>
        public DetalheFaixa FaixaAplicada { get; set; } = new();

        /// <summary>
        /// Dedução por dependentes
        /// </summary>
        public decimal DeducaoDependentes { get; set; }

        /// <summary>
        /// Dedução por pensão alimentícia
        /// </summary>
        public decimal DeducaoPensaoAlimenticia { get; set; }

        /// <summary>
        /// Desconto simplificado aplicado (se houver)
        /// </summary>
        public decimal DescontoSimplificado { get; set; }

        /// <summary>
        /// Link de referência oficial
        /// </summary>
        public string LinkReferencia { get; set; } = "https://www.gov.br/receitafederal/pt-br/assuntos/orientacao-tributaria/tributacao/tributacao-2024-e-2025-incidencia-mensal";
    }
}

