# Calculadora de Salário Líquido CLT - Brasil 2025

Calculadora completa para cálculo de salário líquido CLT no Brasil, com todas as deduções legais e benefícios, seguindo as tabelas oficiais de 2025.

## Características

- ✅ **Cálculo completo de INSS** (progressivo por faixas)
- ✅ **Cálculo de IRRF** (com deduções legais ou simplificado)
- ✅ **Benefícios e descontos** (pré e pós-tributação)
- ✅ **FGTS** (empregador - informativo)
- ✅ **Configuração parametrizável** (JSON)
- ✅ **Testes unitários** (xUnit)
- ✅ **Código limpo e testável**
- ✅ **Relatório detalhado** (Console + JSON)

## Estrutura do Projeto

```
Calculator/
├── Models/                     # DTOs e modelos
│   ├── ParametrosFolha.cs     # Parâmetros de entrada
│   ├── ResultadoFolha.cs      # Resultado do cálculo
│   ├── ItemDesconto.cs        # Benefícios/descontos
│   ├── Faixa.cs              # Faixas de tributação
│   └── DetalheFaixa.cs       # Detalhes por faixa
├── Services/                  # Lógica de negócio
│   └── CltPayrollCalculator.cs # Serviço principal
├── Config/                    # Configuração
│   ├── TaxConfig.json        # Tabelas tributárias
│   └── ConfiguracaoTributaria.cs
├── Tests/                     # Testes unitários
│   └── CltPayrollCalculatorTests.cs
└── Program.cs                # Aplicação console
```

## Como Usar

### Execução via Console

```bash
dotnet run
```

O programa solicitará os dados necessários:
- Salário bruto mensal (obrigatório)
- Número de dependentes
- Pensão alimentícia
- Percentual vale transporte
- Contribuição sindical
- Coparticipação saúde
- Descontos de vale refeição/alimentação
- Opção de desconto simplificado IRRF

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

## Tabelas Tributárias 2025

### INSS (Empregado)
- **Teto**: R$ 8.157,41
- **Faixas**:
  - Até R$ 1.518,00: 7,5%
  - R$ 1.518,01 a R$ 2.793,88: 9%
  - R$ 2.793,89 a R$ 4.190,83: 12%
  - R$ 4.190,84 a R$ 8.157,41: 14%

### IRRF (Mensal)
- **Dedução por dependente**: R$ 189,59
- **Desconto simplificado**: R$ 564,80
- **Faixas**:
  - Até R$ 2.259,20: Isento
  - R$ 2.259,21 a R$ 2.826,65: 7,5% (deduz R$ 169,44)
  - R$ 2.826,66 a R$ 3.751,05: 15% (deduz R$ 381,44)
  - R$ 3.751,06 a R$ 4.664,68: 22,5% (deduz R$ 662,77)
  - Acima de R$ 4.664,68: 27,5% (deduz R$ 896,00)

### FGTS (Empregador)
- **Alíquota**: 8% do salário bruto

## Funcionalidades

### Entrada de Dados
- **Salário bruto mensal** (obrigatório)
- **Número de dependentes** (opcional)
- **Pensão alimentícia** (opcional)
- **Vale transporte** (percentual sobre salário bruto)
- **Contribuição sindical** (opcional)
- **Coparticipação saúde** (opcional)
- **Vale refeição/alimentação** (opcional)
- **Descontos customizados** (pré e pós-tributação)
- **Desconto simplificado IRRF** (opcional)

### Saídas
- **Salário líquido mensal**
- **Detalhamento INSS** (por faixa)
- **Detalhamento IRRF** (base, faixa, alíquota)
- **Benefícios e descontos** (separados por tipo)
- **FGTS empregador** (informativo)
- **Relatório completo** (console + JSON)

## Configuração

As tabelas tributárias estão em `Config/TaxConfig.json` e podem ser facilmente atualizadas:

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

## Testes

Execute os testes unitários:

```bash
dotnet test
```

Os testes cobrem:
- Cálculos básicos
- Diferentes faixas salariais
- Deduções (dependentes, pensão)
- Desconto simplificado
- Benefícios e descontos
- Validações de entrada
- Casos limite

## Fontes Oficiais

- **INSS 2025**: [gov.br INSS](https://www.gov.br/inss/pt-br/servicos-do-inss/calculo-da-guia-da-previdencia-social-gps/tabela-de-contribuicao-mensal)
- **IRRF 2025**: [Receita Federal](https://www.gov.br/receitafederal/pt-br/assuntos/orientacao-tributaria/tributacao/tributacao-2024-e-2025-incidencia-mensal)
- **Ajuste Abril 2025**: [Planalto](https://www.gov.br/planalto/pt-br/acompanhe-o-planalto/noticias/2025/04/ajuste-na-tributacao-do-irrf)

## Tecnologias

- **.NET 6.0**
- **C# 10**
- **xUnit** (testes)
- **Newtonsoft.Json** (serialização)
- **Data Annotations** (validação)

## Licença

Este projeto é para fins educacionais e de demonstração. Sempre consulte um contador ou especialista para cálculos oficiais.