using Xunit;
using Calculator.Models;
using Calculator.Services;
using Calculator.Config;

namespace Calculator.Tests
{
    public class CltPayrollCalculatorTests
    {
        private readonly CltPayrollCalculator _calculadora;

        public CltPayrollCalculatorTests()
        {
            _calculadora = new CltPayrollCalculator();
        }

        [Fact]
        public void CalcularDetalhado_SalarioBasico_SemDependentes_DeveCalcularCorretamente()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = 3000.00m
            };

            // Act
            var resultado = _calculadora.CalcularDetalhado(parametros);

            // Assert
            Assert.Equal(3000.00m, resultado.SalarioBrutoMensal);
            Assert.True(resultado.SalarioLiquidoMensal > 0);
            Assert.True(resultado.SalarioLiquidoMensal < resultado.SalarioBrutoMensal);
            Assert.True(resultado.DetalheInss.ValorTotal > 0);
            Assert.True(resultado.FgtsEmpregador == 240.00m); // 8% de 3000
        }

        [Fact]
        public void CalcularDetalhado_ComDependentes_DeveAplicarDeducao()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = 5000.00m,
                NumeroDependentes = 2
            };

            // Act
            var resultado = _calculadora.CalcularDetalhado(parametros);

            // Assert
            Assert.Equal(379.18m, resultado.DetalheIrrf.DeducaoDependentes); // 2 * 189.59
            Assert.True(resultado.SalarioLiquidoMensal > 0);
        }

        [Fact]
        public void CalcularDetalhado_ComPensaoAlimenticia_DeveAplicarDeducao()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = 4000.00m,
                PensaoAlimenticia = 500.00m
            };

            // Act
            var resultado = _calculadora.CalcularDetalhado(parametros);

            // Assert
            Assert.Equal(500.00m, resultado.DetalheIrrf.DeducaoPensaoAlimenticia);
        }

        [Fact]
        public void CalcularDetalhado_ComDescontoSimplificado_DeveAplicarCorretamente()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = 6000.00m,
                UsarDescontoSimplificado = true
            };

            // Act
            var resultado = _calculadora.CalcularDetalhado(parametros);

            // Assert
            Assert.Equal(564.80m, resultado.DetalheIrrf.DescontoSimplificado);
            Assert.Equal(0m, resultado.DetalheIrrf.DeducaoDependentes);
            Assert.Equal(0m, resultado.DetalheIrrf.DeducaoPensaoAlimenticia);
        }

        [Fact]
        public void CalcularDetalhado_SalarioAcimaTetoInss_DeveAplicarTeto()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = 10000.00m
            };

            // Act
            var resultado = _calculadora.CalcularDetalhado(parametros);

            // Assert
            Assert.Equal(8157.41m, resultado.DetalheInss.BaseCalculo); // Teto do INSS
            Assert.True(resultado.DetalheInss.ValorTotal > 0);
        }

        [Fact]
        public void CalcularDetalhado_ComBeneficios_DeveProcessarCorretamente()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = 3500.00m,
                ValeTransporteBasePercent = 0.06m,
                ContribuicaoSindical = 50.00m,
                ValeRefeicaoDesconto = 100.00m
            };

            // Act
            var resultado = _calculadora.CalcularDetalhado(parametros);

            // Assert
            Assert.True(resultado.BeneficiosDescontos.Any());
            Assert.True(resultado.BeneficiosDescontos.Any(d => d.Nome == "Vale Transporte"));
            Assert.True(resultado.BeneficiosDescontos.Any(d => d.Nome == "Contribuição Sindical"));
            Assert.True(resultado.BeneficiosDescontos.Any(d => d.Nome == "Vale Refeição"));
        }

        [Fact]
        public void CalcularDetalhado_ComDescontosCustomizados_DeveProcessarCorretamente()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = 4000.00m,
                DescontosPreTributacao = new List<ItemDesconto>
                {
                    new ItemDesconto("Plano de Saúde", 200.00m, true)
                },
                DescontosPosTributacao = new List<ItemDesconto>
                {
                    new ItemDesconto("Empréstimo", 150.00m, false)
                }
            };

            // Act
            var resultado = _calculadora.CalcularDetalhado(parametros);

            // Assert
            Assert.True(resultado.BeneficiosDescontos.Any(d => d.Nome == "Plano de Saúde" && d.PreTributacao));
            Assert.True(resultado.BeneficiosDescontos.Any(d => d.Nome == "Empréstimo" && !d.PreTributacao));
        }

        [Fact]
        public void CalcularDetalhado_SalarioZero_DeveLancarExcecao()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = 0
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculadora.CalcularDetalhado(parametros));
        }

        [Fact]
        public void CalcularDetalhado_SalarioNegativo_DeveLancarExcecao()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = -1000
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculadora.CalcularDetalhado(parametros));
        }

        [Fact]
        public void CalcularDetalhado_DependentesNegativos_DeveLancarExcecao()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = 3000.00m,
                NumeroDependentes = -1
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculadora.CalcularDetalhado(parametros));
        }

        [Theory]
        [InlineData(1500.00, 112.50)] // 7.5% de 1500
        [InlineData(2500.00, 225.00)] // 7.5% de 1518 + 9% de 982
        [InlineData(4000.00, 440.00)] // 7.5% de 1518 + 9% de 1275.88 + 12% de 1206.12
        public void CalcularDetalhado_DiferentesSalarios_DeveCalcularInssCorretamente(decimal salario, decimal inssEsperado)
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = salario
            };

            // Act
            var resultado = _calculadora.CalcularDetalhado(parametros);

            // Assert
            Assert.Equal(inssEsperado, resultado.DetalheInss.ValorTotal, 2);
        }

        [Fact]
        public void CalcularDetalhado_DeveGerarResultadoCompleto()
        {
            // Arrange
            var parametros = new ParametrosFolha
            {
                SalarioBrutoMensal = 5000.00m,
                NumeroDependentes = 1,
                ValeTransporteBasePercent = 0.06m
            };

            // Act
            var resultado = _calculadora.CalcularDetalhado(parametros);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(5000.00m, resultado.SalarioBrutoMensal);
            Assert.True(resultado.SalarioLiquidoMensal > 0);
            Assert.NotNull(resultado.DetalheInss);
            Assert.NotNull(resultado.DetalheIrrf);
            Assert.NotNull(resultado.BeneficiosDescontos);
            Assert.True(resultado.FgtsEmpregador == 400.00m); // 8% de 5000
            Assert.True(resultado.TotalDescontos > 0);
            Assert.NotEqual(default(DateTime), resultado.DataCalculo);
            Assert.False(string.IsNullOrEmpty(resultado.VersaoConfiguracao));
        }
    }
}
