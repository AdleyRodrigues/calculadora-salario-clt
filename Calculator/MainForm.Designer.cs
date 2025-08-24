namespace Calculator
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelEntrada;
        private Label lblSalarioBruto;
        private TextBox txtSalarioBruto;
        private Label lblDependentes;
        private NumericUpDown numDependentes;
        private Label lblPensaoAlimenticia;
        private TextBox txtPensaoAlimenticia;
        private Label lblValeTransporte;
        private NumericUpDown numValeTransporte;
        private Label lblContribuicaoSindical;
        private TextBox txtContribuicaoSindical;
        private Label lblSaudeCoparticipacao;
        private TextBox txtSaudeCoparticipacao;
        private Label lblValeRefeicao;
        private TextBox txtValeRefeicao;
        private Label lblValeAlimentacao;
        private TextBox txtValeAlimentacao;
        private CheckBox chkDescontoSimplificado;
        private Button btnCalcular;
        private Button btnLimpar;
        private Panel panelResultados;
        private Label lblResultadoTitulo;
        private Label lblSalarioBrutoResultado;
        private Label lblSalarioLiquidoResultado;
        private Label lblTotalDescontosResultado;
        private Label lblInssTitulo;
        private Label lblInssValor;
        private Label lblInssBase;
        private Label lblIrrfTitulo;
        private Label lblIrrfValor;
        private Label lblIrrfBase;
        private Label lblFgtsTitulo;
        private Label lblFgtsValor;
        private ListView listInssFaixas;
        private ListView listBeneficios;
        private Label lblIrrfFaixa;
        private Label lblIrrfParcelaDeduzir;
        private Button btnSalvarResultado;
        private Button btnSobre;
        private ToolTip toolTip1;
        private Label lblDataCalculo;
        private Label lblVersaoConfig;
        private Label lblAposentadoriaTitulo;
        private Label lblContribuicaoMensal;
        private Label lblContribuicaoAnual;
        private Label lblAposentadoria35Anos;
        private Label lblAposentadoria40Anos;
        private Label lblIdadeMinima;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);

            // Configurações da janela
            this.Text = "Calculadora de Salário Líquido CLT - Brasil 2025";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 500);

            // Cabeçalho
            this.panelHeader = new Panel();
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 60;
            this.panelHeader.Padding = new Padding(20, 10, 20, 10);

            this.lblTitulo = new Label();
            this.lblTitulo.Text = "💰 Calculadora de Salário Líquido CLT - Brasil 2025";
            this.lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new Point(0, 15);
            this.panelHeader.Controls.Add(this.lblTitulo);

            // Painel de entrada
            this.panelEntrada = new Panel();
            this.panelEntrada.Dock = DockStyle.Left;
            this.panelEntrada.Width = 400;
            this.panelEntrada.Padding = new Padding(20);

            // Campos de entrada
            int y = 20;
            int labelWidth = 150;
            int controlWidth = 200;
            int spacing = 35;

            // Salário bruto
            this.lblSalarioBruto = new Label();
            this.lblSalarioBruto.Text = "Salário Bruto (R$):";
            this.lblSalarioBruto.Location = new Point(20, y);
            this.lblSalarioBruto.Size = new Size(labelWidth, 20);
            this.lblSalarioBruto.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.txtSalarioBruto = new TextBox();
            this.txtSalarioBruto.Location = new Point(180, y);
            this.txtSalarioBruto.Size = new Size(controlWidth, 25);
            this.txtSalarioBruto.Font = new Font("Segoe UI", 10);

            y += spacing;

            // Dependentes
            this.lblDependentes = new Label();
            this.lblDependentes.Text = "Dependentes:";
            this.lblDependentes.Location = new Point(20, y);
            this.lblDependentes.Size = new Size(labelWidth, 20);
            this.lblDependentes.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.numDependentes = new NumericUpDown();
            this.numDependentes.Location = new Point(180, y);
            this.numDependentes.Size = new Size(controlWidth, 25);
            this.numDependentes.Maximum = 20;
            this.numDependentes.Font = new Font("Segoe UI", 10);

            y += spacing;

            // Pensão alimentícia
            this.lblPensaoAlimenticia = new Label();
            this.lblPensaoAlimenticia.Text = "Pensão Alimentícia (R$):";
            this.lblPensaoAlimenticia.Location = new Point(20, y);
            this.lblPensaoAlimenticia.Size = new Size(labelWidth, 20);
            this.lblPensaoAlimenticia.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.txtPensaoAlimenticia = new TextBox();
            this.txtPensaoAlimenticia.Location = new Point(180, y);
            this.txtPensaoAlimenticia.Size = new Size(controlWidth, 25);
            this.txtPensaoAlimenticia.Font = new Font("Segoe UI", 10);

            y += spacing;

            // Vale transporte
            this.lblValeTransporte = new Label();
            this.lblValeTransporte.Text = "Vale Transporte (%):";
            this.lblValeTransporte.Location = new Point(20, y);
            this.lblValeTransporte.Size = new Size(labelWidth, 20);
            this.lblValeTransporte.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.numValeTransporte = new NumericUpDown();
            this.numValeTransporte.Location = new Point(180, y);
            this.numValeTransporte.Size = new Size(controlWidth, 25);
            this.numValeTransporte.Maximum = 100;
            this.numValeTransporte.Font = new Font("Segoe UI", 10);

            y += spacing;

            // Contribuição sindical
            this.lblContribuicaoSindical = new Label();
            this.lblContribuicaoSindical.Text = "Contribuição Sindical (R$):";
            this.lblContribuicaoSindical.Location = new Point(20, y);
            this.lblContribuicaoSindical.Size = new Size(labelWidth, 20);
            this.lblContribuicaoSindical.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.txtContribuicaoSindical = new TextBox();
            this.txtContribuicaoSindical.Location = new Point(180, y);
            this.txtContribuicaoSindical.Size = new Size(controlWidth, 25);
            this.txtContribuicaoSindical.Font = new Font("Segoe UI", 10);

            y += spacing;

            // Saúde coparticipação
            this.lblSaudeCoparticipacao = new Label();
            this.lblSaudeCoparticipacao.Text = "Coparticipação Saúde (R$):";
            this.lblSaudeCoparticipacao.Location = new Point(20, y);
            this.lblSaudeCoparticipacao.Size = new Size(labelWidth, 20);
            this.lblSaudeCoparticipacao.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.txtSaudeCoparticipacao = new TextBox();
            this.txtSaudeCoparticipacao.Location = new Point(180, y);
            this.txtSaudeCoparticipacao.Size = new Size(controlWidth, 25);
            this.txtSaudeCoparticipacao.Font = new Font("Segoe UI", 10);

            y += spacing;

            // Vale refeição
            this.lblValeRefeicao = new Label();
            this.lblValeRefeicao.Text = "Vale Refeição (R$):";
            this.lblValeRefeicao.Location = new Point(20, y);
            this.lblValeRefeicao.Size = new Size(labelWidth, 20);
            this.lblValeRefeicao.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.txtValeRefeicao = new TextBox();
            this.txtValeRefeicao.Location = new Point(180, y);
            this.txtValeRefeicao.Size = new Size(controlWidth, 25);
            this.txtValeRefeicao.Font = new Font("Segoe UI", 10);

            y += spacing;

            // Vale alimentação
            this.lblValeAlimentacao = new Label();
            this.lblValeAlimentacao.Text = "Vale Alimentação (R$):";
            this.lblValeAlimentacao.Location = new Point(20, y);
            this.lblValeAlimentacao.Size = new Size(labelWidth, 20);
            this.lblValeAlimentacao.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.txtValeAlimentacao = new TextBox();
            this.txtValeAlimentacao.Location = new Point(180, y);
            this.txtValeAlimentacao.Size = new Size(controlWidth, 25);
            this.txtValeAlimentacao.Font = new Font("Segoe UI", 10);

            y += spacing;

            // Desconto simplificado
            this.chkDescontoSimplificado = new CheckBox();
            this.chkDescontoSimplificado.Text = "Usar Desconto Simplificado IRRF";
            this.chkDescontoSimplificado.Location = new Point(20, y);
            this.chkDescontoSimplificado.Size = new Size(300, 25);
            this.chkDescontoSimplificado.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            y += 50;

            // Botões
            this.btnCalcular = new Button();
            this.btnCalcular.Text = "🔄 Calcular (F5)";
            this.btnCalcular.Location = new Point(20, y);
            this.btnCalcular.Size = new Size(120, 35);
            this.btnCalcular.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.btnLimpar = new Button();
            this.btnLimpar.Text = "🗑️ Limpar (F2)";
            this.btnLimpar.Location = new Point(150, y);
            this.btnLimpar.Size = new Size(120, 35);
            this.btnLimpar.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.btnSalvarResultado = new Button();
            this.btnSalvarResultado.Text = "💾 Salvar (F12)";
            this.btnSalvarResultado.Location = new Point(280, y);
            this.btnSalvarResultado.Size = new Size(120, 35);
            this.btnSalvarResultado.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            y += 50;

            this.btnSobre = new Button();
            this.btnSobre.Text = "ℹ️ Sobre (F1)";
            this.btnSobre.Location = new Point(20, y);
            this.btnSobre.Size = new Size(120, 35);
            this.btnSobre.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Adicionar controles ao painel de entrada
            this.panelEntrada.Controls.AddRange(new Control[] {
                this.lblSalarioBruto, this.txtSalarioBruto,
                this.lblDependentes, this.numDependentes,
                this.lblPensaoAlimenticia, this.txtPensaoAlimenticia,
                this.lblValeTransporte, this.numValeTransporte,
                this.lblContribuicaoSindical, this.txtContribuicaoSindical,
                this.lblSaudeCoparticipacao, this.txtSaudeCoparticipacao,
                this.lblValeRefeicao, this.txtValeRefeicao,
                this.lblValeAlimentacao, this.txtValeAlimentacao,
                this.chkDescontoSimplificado,
                this.btnCalcular, this.btnLimpar, this.btnSalvarResultado, this.btnSobre
            });

            // Painel de resultados
            this.panelResultados = new Panel();
            this.panelResultados.Dock = DockStyle.Fill;
            this.panelResultados.Padding = new Padding(20);
            this.panelResultados.Visible = false;

            // Título dos resultados
            this.lblResultadoTitulo = new Label();
            this.lblResultadoTitulo.Text = "📊 RESULTADOS DO CÁLCULO";
            this.lblResultadoTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblResultadoTitulo.ForeColor = Color.FromArgb(0, 123, 255);
            this.lblResultadoTitulo.Location = new Point(20, 20);
            this.lblResultadoTitulo.AutoSize = true;

            // Valores principais
            y = 60;

            this.lblSalarioBrutoResultado = new Label();
            this.lblSalarioBrutoResultado.Text = "Salário Bruto: R$ 0,00";
            this.lblSalarioBrutoResultado.Location = new Point(20, y);
            this.lblSalarioBrutoResultado.Size = new Size(200, 25);
            this.lblSalarioBrutoResultado.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            this.lblSalarioLiquidoResultado = new Label();
            this.lblSalarioLiquidoResultado.Text = "Salário Líquido: R$ 0,00";
            this.lblSalarioLiquidoResultado.Location = new Point(250, y);
            this.lblSalarioLiquidoResultado.Size = new Size(200, 25);
            this.lblSalarioLiquidoResultado.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblSalarioLiquidoResultado.ForeColor = Color.FromArgb(40, 167, 69);

            this.lblTotalDescontosResultado = new Label();
            this.lblTotalDescontosResultado.Text = "Total Descontos: R$ 0,00";
            this.lblTotalDescontosResultado.Location = new Point(480, y);
            this.lblTotalDescontosResultado.Size = new Size(200, 25);
            this.lblTotalDescontosResultado.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblTotalDescontosResultado.ForeColor = Color.FromArgb(220, 53, 69);

            y += 40;

            // INSS
            this.lblInssTitulo = new Label();
            this.lblInssTitulo.Text = "📋 INSS (Empregado):";
            this.lblInssTitulo.Location = new Point(20, y);
            this.lblInssTitulo.Size = new Size(150, 25);
            this.lblInssTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            this.lblInssValor = new Label();
            this.lblInssValor.Text = "Valor: R$ 0,00";
            this.lblInssValor.Location = new Point(180, y);
            this.lblInssValor.Size = new Size(120, 25);
            this.lblInssValor.Font = new Font("Segoe UI", 10);

            this.lblInssBase = new Label();
            this.lblInssBase.Text = "Base: R$ 0,00";
            this.lblInssBase.Location = new Point(320, y);
            this.lblInssBase.Size = new Size(120, 25);
            this.lblInssBase.Font = new Font("Segoe UI", 10);

            y += 30;

            // IRRF
            this.lblIrrfTitulo = new Label();
            this.lblIrrfTitulo.Text = "📋 IRRF:";
            this.lblIrrfTitulo.Location = new Point(20, y);
            this.lblIrrfTitulo.Size = new Size(150, 25);
            this.lblIrrfTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            this.lblIrrfValor = new Label();
            this.lblIrrfValor.Text = "Valor: R$ 0,00";
            this.lblIrrfValor.Location = new Point(180, y);
            this.lblIrrfValor.Size = new Size(120, 25);
            this.lblIrrfValor.Font = new Font("Segoe UI", 10);

            this.lblIrrfBase = new Label();
            this.lblIrrfBase.Text = "Base: R$ 0,00";
            this.lblIrrfBase.Location = new Point(320, y);
            this.lblIrrfBase.Size = new Size(120, 25);
            this.lblIrrfBase.Font = new Font("Segoe UI", 10);

            this.lblIrrfFaixa = new Label();
            this.lblIrrfFaixa.Text = "Faixa: Isento";
            this.lblIrrfFaixa.Location = new Point(460, y);
            this.lblIrrfFaixa.Size = new Size(100, 25);
            this.lblIrrfFaixa.Font = new Font("Segoe UI", 10);

            this.lblIrrfParcelaDeduzir = new Label();
            this.lblIrrfParcelaDeduzir.Text = "Parcela: R$ 0,00";
            this.lblIrrfParcelaDeduzir.Location = new Point(580, y);
            this.lblIrrfParcelaDeduzir.Size = new Size(120, 25);
            this.lblIrrfParcelaDeduzir.Font = new Font("Segoe UI", 10);

            y += 30;

            // FGTS
            this.lblFgtsTitulo = new Label();
            this.lblFgtsTitulo.Text = "📋 FGTS (Empregador):";
            this.lblFgtsTitulo.Location = new Point(20, y);
            this.lblFgtsTitulo.Size = new Size(150, 25);
            this.lblFgtsTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            this.lblFgtsValor = new Label();
            this.lblFgtsValor.Text = "Valor: R$ 0,00";
            this.lblFgtsValor.Location = new Point(180, y);
            this.lblFgtsValor.Size = new Size(120, 25);
            this.lblFgtsValor.Font = new Font("Segoe UI", 10);

            y += 50;

            // Lista de faixas INSS
            var lblInssFaixas = new Label();
            lblInssFaixas.Text = "📊 Detalhamento INSS por Faixas:";
            lblInssFaixas.Location = new Point(20, y);
            lblInssFaixas.Size = new Size(250, 25);
            lblInssFaixas.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            y += 30;

            this.listInssFaixas = new ListView();
            this.listInssFaixas.Location = new Point(20, y);
            this.listInssFaixas.Size = new Size(400, 100);
            this.listInssFaixas.View = View.Details;
            this.listInssFaixas.FullRowSelect = true;
            this.listInssFaixas.GridLines = true;
            this.listInssFaixas.Columns.Add("Faixa", 200);
            this.listInssFaixas.Columns.Add("Alíquota", 80);
            this.listInssFaixas.Columns.Add("Valor", 100);

            y += 120;

            // Lista de benefícios
            var lblBeneficios = new Label();
            lblBeneficios.Text = "📋 Benefícios e Descontos:";
            lblBeneficios.Location = new Point(20, y);
            lblBeneficios.Size = new Size(250, 25);
            lblBeneficios.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            y += 30;

            this.listBeneficios = new ListView();
            this.listBeneficios.Location = new Point(20, y);
            this.listBeneficios.Size = new Size(400, 100);
            this.listBeneficios.View = View.Details;
            this.listBeneficios.FullRowSelect = true;
            this.listBeneficios.GridLines = true;
            this.listBeneficios.Columns.Add("Item", 200);
            this.listBeneficios.Columns.Add("Valor", 100);
            this.listBeneficios.Columns.Add("Tipo", 100);

            y += 120;

            // Seção de Aposentadoria
            this.lblAposentadoriaTitulo = new Label();
            this.lblAposentadoriaTitulo.Text = "👴 INFORMAÇÕES DE APOSENTADORIA";
            this.lblAposentadoriaTitulo.Location = new Point(20, y);
            this.lblAposentadoriaTitulo.Size = new Size(400, 25);
            this.lblAposentadoriaTitulo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblAposentadoriaTitulo.ForeColor = Color.FromArgb(111, 66, 193);

            y += 35;

            this.lblContribuicaoMensal = new Label();
            this.lblContribuicaoMensal.Text = "Contribuição Mensal: R$ 0,00";
            this.lblContribuicaoMensal.Location = new Point(20, y);
            this.lblContribuicaoMensal.Size = new Size(200, 20);
            this.lblContribuicaoMensal.Font = new Font("Segoe UI", 9);

            this.lblContribuicaoAnual = new Label();
            this.lblContribuicaoAnual.Text = "Contribuição Anual: R$ 0,00";
            this.lblContribuicaoAnual.Location = new Point(250, y);
            this.lblContribuicaoAnual.Size = new Size(200, 20);
            this.lblContribuicaoAnual.Font = new Font("Segoe UI", 9);

            y += 25;

            this.lblIdadeMinima = new Label();
            this.lblIdadeMinima.Text = "Idade Mínima: 65 anos (H) / 62 anos (M)";
            this.lblIdadeMinima.Location = new Point(20, y);
            this.lblIdadeMinima.Size = new Size(300, 20);
            this.lblIdadeMinima.Font = new Font("Segoe UI", 9);

            y += 25;

            this.lblAposentadoria35Anos = new Label();
            this.lblAposentadoria35Anos.Text = "Estimativa 35 anos: R$ 0,00";
            this.lblAposentadoria35Anos.Location = new Point(20, y);
            this.lblAposentadoria35Anos.Size = new Size(200, 20);
            this.lblAposentadoria35Anos.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblAposentadoria35Anos.ForeColor = Color.FromArgb(40, 167, 69);

            this.lblAposentadoria40Anos = new Label();
            this.lblAposentadoria40Anos.Text = "Estimativa 40 anos: R$ 0,00";
            this.lblAposentadoria40Anos.Location = new Point(250, y);
            this.lblAposentadoria40Anos.Size = new Size(200, 20);
            this.lblAposentadoria40Anos.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblAposentadoria40Anos.ForeColor = Color.FromArgb(40, 167, 69);

            y += 40;

            // Informações adicionais
            this.lblDataCalculo = new Label();
            this.lblDataCalculo.Text = "Data do Cálculo: -";
            this.lblDataCalculo.Location = new Point(20, y);
            this.lblDataCalculo.Size = new Size(200, 25);
            this.lblDataCalculo.Font = new Font("Segoe UI", 9);

            this.lblVersaoConfig = new Label();
            this.lblVersaoConfig.Text = "Versão Config: -";
            this.lblVersaoConfig.Location = new Point(250, y);
            this.lblVersaoConfig.Size = new Size(200, 25);
            this.lblVersaoConfig.Font = new Font("Segoe UI", 9);

            // Adicionar controles ao painel de resultados
            this.panelResultados.Controls.AddRange(new Control[] {
                this.lblResultadoTitulo,
                this.lblSalarioBrutoResultado, this.lblSalarioLiquidoResultado, this.lblTotalDescontosResultado,
                this.lblInssTitulo, this.lblInssValor, this.lblInssBase,
                this.lblIrrfTitulo, this.lblIrrfValor, this.lblIrrfBase, this.lblIrrfFaixa, this.lblIrrfParcelaDeduzir,
                this.lblFgtsTitulo, this.lblFgtsValor,
                lblInssFaixas, this.listInssFaixas,
                lblBeneficios, this.listBeneficios,
                this.lblAposentadoriaTitulo, this.lblContribuicaoMensal, this.lblContribuicaoAnual,
                this.lblIdadeMinima, this.lblAposentadoria35Anos, this.lblAposentadoria40Anos,
                this.lblDataCalculo, this.lblVersaoConfig
            });

            // Adicionar painéis à janela
            this.Controls.Add(this.panelResultados);
            this.Controls.Add(this.panelEntrada);
            this.Controls.Add(this.panelHeader);
        }
    }
}

