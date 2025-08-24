namespace Calculator.Models
{
    /// <summary>
    /// Detalhe do cálculo por faixa de tributação
    /// </summary>
    public class DetalheFaixa
    {
        /// <summary>
        /// Limite inferior da faixa
        /// </summary>
        public decimal LimiteInferior { get; set; }

        /// <summary>
        /// Limite superior da faixa
        /// </summary>
        public decimal LimiteSuperior { get; set; }

        /// <summary>
        /// Base de cálculo da faixa
        /// </summary>
        public decimal BaseCalculo { get; set; }

        /// <summary>
        /// Alíquota aplicada
        /// </summary>
        public decimal Aliquota { get; set; }

        /// <summary>
        /// Valor calculado para esta faixa
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Parcela a deduzir (IRRF)
        /// </summary>
        public decimal ParcelaDeduzir { get; set; } = 0;

        public DetalheFaixa() { }

        public DetalheFaixa(decimal limiteInferior, decimal limiteSuperior, decimal baseCalculo, 
                           decimal aliquota, decimal valor, decimal parcelaDeduzir = 0)
        {
            LimiteInferior = limiteInferior;
            LimiteSuperior = limiteSuperior;
            BaseCalculo = baseCalculo;
            Aliquota = aliquota;
            Valor = valor;
            ParcelaDeduzir = parcelaDeduzir;
        }
    }
}

