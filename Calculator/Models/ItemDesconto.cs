namespace Calculator.Models
{
    /// <summary>
    /// Representa um item de desconto ou benefício
    /// </summary>
    public class ItemDesconto
    {
        /// <summary>
        /// Nome/descrição do desconto
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Valor do desconto
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Indica se é pré-tributação (true) ou pós-tributação (false)
        /// </summary>
        public bool PreTributacao { get; set; }

        public ItemDesconto() { }

        public ItemDesconto(string nome, decimal valor, bool preTributacao = true)
        {
            Nome = nome;
            Valor = valor;
            PreTributacao = preTributacao;
        }
    }
}

