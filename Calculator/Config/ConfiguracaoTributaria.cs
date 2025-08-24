using Newtonsoft.Json;
using Calculator.Models;

namespace Calculator.Config
{
    /// <summary>
    /// Configuração tributária carregada do arquivo JSON
    /// </summary>
    public class ConfiguracaoTributaria
    {
        public ConfiguracaoInss Inss { get; set; } = new();
        public ConfiguracaoIrrf Irrf { get; set; } = new();
        public ConfiguracaoFgts Fgts { get; set; } = new();
        public ConfiguracaoValeTransporte ValeTransporte { get; set; } = new();
        public string Versao { get; set; } = string.Empty;
        public string DataAtualizacao { get; set; } = string.Empty;
        public FontesConfig Fontes { get; set; } = new();

        /// <summary>
        /// Carrega a configuração do arquivo JSON
        /// </summary>
        /// <param name="caminhoArquivo">Caminho para o arquivo de configuração</param>
        /// <returns>Instância da configuração carregada</returns>
        public static ConfiguracaoTributaria Carregar(string caminhoArquivo = "Config/TaxConfig.json")
        {
            try
            {
                if (!File.Exists(caminhoArquivo))
                {
                    throw new FileNotFoundException($"Arquivo de configuração não encontrado: {caminhoArquivo}");
                }

                string json = File.ReadAllText(caminhoArquivo);
                var config = JsonConvert.DeserializeObject<ConfiguracaoTributaria>(json);
                
                if (config == null)
                {
                    throw new InvalidOperationException("Falha ao deserializar configuração tributária");
                }

                return config;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao carregar configuração tributária: {ex.Message}", ex);
            }
        }
    }

    public class ConfiguracaoInss
    {
        public decimal Teto { get; set; }
        public List<Faixa> Faixas { get; set; } = new();
    }

    public class ConfiguracaoIrrf
    {
        public bool UsarTabelaPosAbril2025 { get; set; }
        public decimal DescontoSimplificadoMensal { get; set; }
        public List<Faixa> Faixas { get; set; } = new();
        public decimal DeducaoDependenteMensal { get; set; }
    }

    public class ConfiguracaoFgts
    {
        public decimal Aliquota { get; set; }
    }

    public class ConfiguracaoValeTransporte
    {
        public decimal LimiteMensal { get; set; }
    }

    public class FontesConfig
    {
        public string Inss { get; set; } = string.Empty;
        public string Irrf { get; set; } = string.Empty;
        public string AjusteAbril2025 { get; set; } = string.Empty;
    }
}

