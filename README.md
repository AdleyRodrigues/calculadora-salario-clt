# 🧮 Calculadora de Salário Líquido CLT - Brasil 2025

[![.NET](https://img.shields.io/badge/.NET-6.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/6.0)
[![C#](https://img.shields.io/badge/C%23-10.0-green.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Windows Forms](https://img.shields.io/badge/Windows%20Forms-Yes-orange.svg)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
[![Tests](https://img.shields.io/badge/Tests-xUnit-purple.svg)](https://xunit.net/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## 📋 Descrição

Sistema completo para cálculo de salário líquido CLT no Brasil, desenvolvido em **C# .NET 6.0** com interface gráfica **Windows Forms**. O projeto implementa todas as deduções legais obrigatórias e benefícios opcionais, seguindo rigorosamente as tabelas oficiais de 2025.

### 🎯 Objetivo do Projeto

Este projeto foi desenvolvido para demonstrar:

- **Arquitetura limpa** e **padrões de design** em C#
- **Testes unitários** abrangentes com xUnit
- **Interface gráfica** moderna e intuitiva
- **Configuração parametrizável** via JSON
- **Validação robusta** de dados de entrada
- **Documentação completa** do código

## ✨ Funcionalidades Principais

### 🧮 Cálculos Implementados

- ✅ **INSS Progressivo** (4 faixas com teto de R$ 8.157,41)
- ✅ **IRRF Mensal** (5 faixas com deduções legais)
- ✅ **FGTS Empregador** (8% informativo)
- ✅ **Vale Transporte** (percentual configurável)
- ✅ **Benefícios e Descontos** (pré e pós-tributação)
- ✅ **Dedução por Dependentes** (R$ 189,59 cada)
- ✅ **Pensão Alimentícia** (dedução IRRF)
- ✅ **Desconto Simplificado IRRF** (R$ 564,80)

### 🖥️ Interface Gráfica

- **Design moderno** com cores profissionais
- **Validação em tempo real** dos campos
- **Tooltips informativos** para cada campo
- **Formatação automática** de valores monetários
- **Exportação de resultados** em JSON
- **Teclas de atalho** para melhor usabilidade

### ⚙️ Configuração Flexível

- **Tabelas tributárias** em arquivo JSON
- **Fácil atualização** de alíquotas e limites
- **Versionamento** de configurações
- **Links de referência** para fontes oficiais

## 🏗️ Arquitetura do Projeto

```
📁 calculadora-salario-clt/
├── 📁 Calculator/                    # Projeto principal
│   ├── 📁 Models/                   # DTOs e entidades
│   │   ├── ParametrosFolha.cs      # Parâmetros de entrada
│   │   ├── ResultadoFolha.cs       # Resultado do cálculo
│   │   ├── ItemDesconto.cs         # Benefícios/descontos
│   │   ├── Faixa.cs               # Faixas de tributação
│   │   └── DetalheFaixa.cs        # Detalhes por faixa
│   ├── 📁 Services/                # Lógica de negócio
│   │   └── CltPayrollCalculator.cs # Serviço principal
│   ├── 📁 Config/                  # Configuração
│   │   ├── TaxConfig.json         # Tabelas tributárias
│   │   └── ConfiguracaoTributaria.cs
│   ├── 📁 Calculator.Tests/        # Testes unitários
│   │   └── CltPayrollCalculatorTests.cs
│   ├── MainForm.cs                # Interface gráfica
│   ├── Program.cs                 # Ponto de entrada
│   └── Calculator.csproj          # Configuração do projeto
└── 📄 README.md                   # Este arquivo
```

## 🚀 Como Executar

### Pré-requisitos

- **.NET 6.0 SDK** ou superior
- **Windows 10/11** (para interface gráfica)
- **Visual Studio 2022** ou **VS Code**

### Execução

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/calculadora-salario-clt.git
cd calculadora-salario-clt

# Restaure as dependências
dotnet restore

# Execute o projeto
dotnet run --project Calculator

# Ou execute os testes
dotnet test
```

### Uso como Biblioteca

```csharp
using Calculator.Models;
using Calculator.Services;

var parametros = new ParametrosFolha
{
    SalarioBrutoMensal = 5000.00m,
    NumeroDependentes = 2,
    ValeTransporteBasePercent = 0.06m
};

var calculadora = new CltPayrollCalculator();
var resultado = calculadora.CalcularDetalhado(parametros);

Console.WriteLine($"Salário Líquido: R$ {resultado.SalarioLiquidoMensal:N2}");
```

## 📊 Tabelas Tributárias 2025

### INSS (Empregado)

| Faixa | Limite | Alíquota |
|-------|--------|----------|
| 1ª | Até R$ 1.518,00 | 7,5% |
| 2ª | R$ 1.518,01 a R$ 2.793,88 | 9% |
| 3ª | R$ 2.793,89 a R$ 4.190,83 | 12% |
| 4ª | R$ 4.190,84 a R$ 8.157,41 | 14% |

### IRRF (Mensal)

| Faixa | Limite | Alíquota | Dedução |
|-------|--------|----------|---------|
| 1ª | Até R$ 2.259,20 | Isento | - |
| 2ª | R$ 2.259,21 a R$ 2.826,65 | 7,5% | R$ 169,44 |
| 3ª | R$ 2.826,66 a R$ 3.751,05 | 15% | R$ 381,44 |
| 4ª | R$ 3.751,06 a R$ 4.664,68 | 22,5% | R$ 662,77 |
| 5ª | Acima de R$ 4.664,68 | 27,5% | R$ 896,00 |

## 🧪 Testes

O projeto inclui **testes unitários abrangentes** que cobrem:

- ✅ Cálculos básicos de salário
- ✅ Diferentes faixas salariais
- ✅ Deduções (dependentes, pensão alimentícia)
- ✅ Desconto simplificado do IRRF
- ✅ Benefícios e descontos
- ✅ Validações de entrada
- ✅ Casos limite e edge cases

```bash
# Executar todos os testes
dotnet test

# Executar com cobertura (se configurado)
dotnet test --collect:"XPlat Code Coverage"
```

## 🛠️ Tecnologias Utilizadas

### Backend

- **.NET 6.0** - Framework principal
- **C# 10** - Linguagem de programação
- **Windows Forms** - Interface gráfica
- **Newtonsoft.Json** - Serialização JSON
- **Data Annotations** - Validação de modelos

### Testes

- **xUnit** - Framework de testes
- **Coverlet** - Cobertura de código

### Ferramentas

- **Visual Studio 2022** - IDE principal
- **Git** - Controle de versão
- **NuGet** - Gerenciamento de pacotes

## 📈 Funcionalidades Avançadas

### Validação Robusta

- **Validação de entrada** com Data Annotations
- **Tratamento de erros** personalizado
- **Mensagens de erro** claras e informativas

### Configuração Flexível

```json
{
  "inss": {
    "teto": 8157.41,
    "faixas": [...]
  },
  "irrf": {
    "descontoSimplificadoMensal": 564.80,
    "faixas": [...]
  }
}
```

### Exportação de Resultados

- **Relatório detalhado** em console
- **Exportação JSON** para análise
- **Formatação monetária** brasileira

## 🔗 Fontes Oficiais

- **INSS 2025**: [gov.br INSS](https://www.gov.br/inss/pt-br/servicos-do-inss/calculo-da-guia-da-previdencia-social-gps/tabela-de-contribuicao-mensal)
- **IRRF 2025**: [Receita Federal](https://www.gov.br/receitafederal/pt-br/assuntos/orientacao-tributaria/tributacao/tributacao-2024-e-2025-incidencia-mensal)
- **Ajuste Abril 2025**: [Planalto](https://www.gov.br/planalto/pt-br/acompanhe-o-planalto/noticias/2025/04/ajuste-na-tributacao-do-irrf)

## 🎯 Competências Demonstradas

### 💻 Desenvolvimento

- **C# .NET** avançado
- **Arquitetura limpa** e **SOLID**
- **Padrões de design** (Service, Repository)
- **Testes unitários** com xUnit
- **Validação de dados** robusta

### 🎨 Interface

- **Windows Forms** moderno
- **UX/UI** intuitiva
- **Formatação** e validação em tempo real
- **Responsividade** e usabilidade

### 🔧 Engenharia de Software

- **Versionamento** com Git
- **Documentação** completa
- **Configuração** parametrizável
- **Manutenibilidade** do código

## 📝 Licença

Este projeto é para fins **educacionais** e de **demonstração**. Sempre consulte um contador ou especialista para cálculos oficiais.

## 👨‍💻 Autor

**Seu Nome** - Desenvolvedor .NET

- 📧 Email: <seu-email@exemplo.com>
- 💼 LinkedIn: [linkedin.com/in/seu-perfil](https://linkedin.com/in/seu-perfil)
- 🐙 GitHub: [github.com/seu-usuario](https://github.com/seu-usuario)

---

⭐ **Se este projeto foi útil, considere dar uma estrela no repositório!**
