using System.Globalization;

namespace Calculator
{
    internal static class Program
    {
        /// <summary>
        ///  Ponto de entrada principal para a aplicação.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Para habilitar recursos visuais modernos do Windows Forms
            ApplicationConfiguration.Initialize();

            // Configurar cultura brasileira
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

            // Inicia o formulário principal da aplicação
            Application.Run(new MainForm());
        }
    }
}