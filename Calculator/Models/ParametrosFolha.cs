using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    /// <summary>
    /// Parâmetros de entrada para cálculo de folha de pagamento CLT
    /// </summary>
    public class ParametrosFolha
    {
        /// <summary>
        /// Salário bruto mensal (obrigatório)
        /// </summary>
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salário bruto deve ser maior que zero")]
        public decimal SalarioBrutoMensal { get; set; }

        /// <summary>
        /// Número de dependentes (opcional, default = 0)
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Número de dependentes deve ser maior ou igual a zero")]
        public int NumeroDependentes { get; set; } = 0;

        /// <summary>
        /// Pensão alimentícia mensal comprovada (opcional, default = 0)
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Pensão alimentícia deve ser maior ou igual a zero")]
        public decimal PensaoAlimenticia { get; set; } = 0;

        /// <summary>
        /// Percentual do vale transporte sobre salário bruto (opcional, default = 0)
        /// </summary>
        [Range(0, 1, ErrorMessage = "Percentual do vale transporte deve estar entre 0 e 1")]
        public decimal ValeTransporteBasePercent { get; set; } = 0;

        /// <summary>
        /// Contribuição sindical (opcional, default = 0)
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Contribuição sindical deve ser maior ou igual a zero")]
        public decimal ContribuicaoSindical { get; set; } = 0;

        /// <summary>
        /// Coparticipação em saúde (opcional, default = 0)
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Coparticipação em saúde deve ser maior ou igual a zero")]
        public decimal SaudeCoparticipacao { get; set; } = 0;

        /// <summary>
        /// Desconto do vale refeição (opcional, default = 0)
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Desconto do vale refeição deve ser maior ou igual a zero")]
        public decimal ValeRefeicaoDesconto { get; set; } = 0;

        /// <summary>
        /// Desconto do vale alimentação (opcional, default = 0)
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Desconto do vale alimentação deve ser maior ou igual a zero")]
        public decimal ValeAlimentacaoDesconto { get; set; } = 0;

        /// <summary>
        /// Descontos pré-tributação (opcional)
        /// </summary>
        public List<ItemDesconto> DescontosPreTributacao { get; set; } = new();

        /// <summary>
        /// Descontos pós-tributação (opcional)
        /// </summary>
        public List<ItemDesconto> DescontosPosTributacao { get; set; } = new();

        /// <summary>
        /// Flag para usar desconto simplificado do IRRF (opcional, default = false)
        /// </summary>
        public bool UsarDescontoSimplificado { get; set; } = false;
    }
}

