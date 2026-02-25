# 📚 Biblioteca API - Gerenciador de Empréstimos

![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen) ![Platform](https://img.shields.io/badge/Platform-.NET%208-blueviolet) ![License](https://img.shields.io/badge/License-MIT-blue)

## 🚀 Sobre o Projeto

O **Biblioteca API** é uma aplicação RESTful desenvolvida para gerenciar o ecossistema de uma biblioteca, controlando o fluxo de livros, leitores e empréstimos.

Este projeto foi construído com foco em **Arquitetura em Camadas**, visando desacoplamento, testabilidade e manutenção. O objetivo principal é demonstrar a aplicação prática de conceitos sólidos de Engenharia de Software no ecossistema .NET.

> 🚧 **Status do Projeto:** Em evolução contínua. Novas features de arquitetura e segurança estão sendo implementadas semanalmente.

## 🛠 Tecnologias e Práticas Utilizadas

O projeto utiliza o que há de mais moderno no desenvolvimento Back-end com C#:

- **.NET 8 (Core):** Framework principal.
- **Entity Framework Core:** ORM para acesso a dados (Code-First).
- **SQL Server:** Banco de dados relacional.
- **Swagger (OpenAPI):** Documentação interativa dos endpoints.
- **Injeção de Dependência:** Gestão do ciclo de vida dos objetos (Scoped).
- **Padrão Repository:** Abstração da camada de acesso a dados.
- **Padrão Service:** Isolamento das regras de negócio (Validações de disponibilidade, lógica de empréstimo).
- **DTOs (Data Transfer Objects):** Segurança e filtro no tráfego de dados.
- **Mapeamento de Relacionamentos:** Configuração de Chaves Estrangeiras (FKs) e Propriedades de Navegação.

## 🏗 Arquitetura do Projeto

A solução foi dividida para respeitar o princípio da Separação de Responsabilidades (SoC):

📂 Biblioteca
├── 📂 Controllers   # Pontos de entrada (Endpoints HTTP)
├── 📂 Services      # Regras de Negócio (ex: Verificar se livro está disponível)
├── 📂 Repositories  # Acesso direto ao Banco de Dados
├── 📂 Entities      # Modelos do Domínio (Espelho do Banco)
├── 📂 DTOs          # Objetos de transporte (Request/Response)
└── 📂 Context       # Configuração do Entity Framework


## ✨ Funcionalidades Principais

- **Gestão de Livros:** Cadastro e consulta de acervo.
- **Gestão de Leitores (Pessoas):** Cadastro de usuários.
- **Motor de Empréstimos:**
  - Validação automática de disponibilidade do livro.
  - Verificação de existência de cadastro.
  - Registro de datas de empréstimo e previsão de devolução.
- **Devolução:** Processamento de retorno de livros ao acervo.

## 🚀 Como Rodar o Projeto

### Pré-requisitos
- .NET SDK 8.0+
- SQL Server (Express ou LocalDB)
- Visual Studio 2022 ou VS Code

### Passo a Passo

1. **Clone o repositório:**
   ```bash
   git clone [https://github.com/seu-usuario/biblioteca-api.git](https://github.com/seu-usuario/biblioteca-api.git)
Configure o Banco de Dados:
No arquivo appsettings.json, ajuste a ConnectionString para o seu servidor SQL local.

Aplique as Migrations:
Abra o terminal na pasta do projeto e execute:

PowerShell

dotnet ef database update
Execute a Aplicação:

PowerShell

dotnet run
Acesse o Swagger em: https://localhost:7034/swagger (ou a porta indicada no seu terminal).

🔮 Roadmap (Próximos Passos)
O projeto segue um plano de estudos avançado para implementação de padrões corporativos:

[x] Separação em Camadas (Service/Repository)

[x] Implementação de DTOs

[ ] Notification Pattern: Substituição de Exceptions por notificações de domínio.

[ ] Base Controller: Padronização de respostas da API (Envelopamento).

[ ] Unit Tests: Cobertura de testes com xUnit e Moq.

[ ] Autenticação JWT: Proteção de rotas sensíveis.

🤝 Contato
Gustavo Henrique - Desenvolvedor Back-end .NET
LinkedIn | Email
📧 [gustavohenriquesantil@gmail.com](email:gustavohenriquesantil@gmail.com)  
🔗www.linkedin.com/in/gustavo-santil
