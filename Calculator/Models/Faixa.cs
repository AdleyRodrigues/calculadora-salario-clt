namespace Calculator.Models
{
    /// <summary>
    /// Representa uma faixa de tributação (INSS ou IRRF)
    /// </summary>
    public class Faixa
    {
        /// <summary>
        /// Limite superior da faixa
        /// </summary>
        public decimal Limite { get; set; }

        /// <summary>
        /// Alíquota da faixa (0.00 a 1.00)
        /// </summary>
        public decimal Aliquota { get; set; }

        /// <summary>
        /// Parcela a deduzir (usado apenas para IRRF)
        /// </summary>
        public decimal ParcelaDeduzir { get; set; } = 0;

        public Faixa() { }

        public Faixa(decimal limite, decimal aliquota, decimal parcelaDeduzir = 0)
        {
            Limite = limite;
            Aliquota = aliquota;
            ParcelaDeduzir = parcelaDeduzir;
        }
    }
}

