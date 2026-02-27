📚 Biblioteca API — Gerenciador de Empréstimos (ASP.NET Core)

API REST em ASP.NET Core (.NET 8) para gerenciar livros, leitores e o fluxo de empréstimos/devoluções, com regras de negócio (disponibilidade, validações) e arquitetura em camadas.

![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen) ![Platform](https://img.shields.io/badge/Platform-.NET%208-blueviolet) ![License](https://img.shields.io/badge/License-MIT-blue)

## 🚀 Sobre o Projeto

Pré-requisitos

.NET SDK 8+

SQL Server (Express/LocalDB)

Rodando localmente
git clone https://github.com/gustavowq/biblioteca-webapi-aspnetcore.git
cd biblioteca-webapi-aspnetcore
dotnet restore
dotnet ef database update
dotnet run

Acesse o Swagger:
https://localhost:7034/swagger (ou a porta indicada no terminal)

🧠 Funcionalidades do Sistema

Livros:

Cadastro, edição e consulta do acervo

Exposição controlada de dados utilizando DTOs

-----------------
Leitores:

Cadastro e gerenciamento de usuários

Vínculo relacional com histórico de empréstimos

-----------------
Motor de Empréstimos:

Validação de disponibilidade do livro (bloqueia empréstimos duplicados)

Validação de existência de leitor e livro

Registro automático da data de empréstimo e previsão de devolução

-----------------
Devolução:

Atualização do empréstimo via PATCH

Retorno imediato do livro ao status de disponível no acervo

-----------------
🧱 Arquitetura

Projeto estruturado em camadas para separação de responsabilidades, manutenção e testabilidade:

Biblioteca/
 ├── Controllers     # Endpoints HTTP
 ├── Services        # Regras de negócio
 ├── Repositories    # Acesso a dados
 ├── Entities        # Modelos de domínio
 ├── DTOs            # Request/Response
 └── Context         # EF Core DbContext

Práticas aplicadas:

POO • SOLID • Injeção de Dependência

Repository + Service

DTOs para controle de contrato e segurança

EF Core Code-First + Migrations

Swagger/OpenAPI

-----------------
🛠 Tecnologias

C# • .NET 8 • ASP.NET Core Web API

Entity Framework Core • SQL Server

Swagger/OpenAPI • Git

-----------------
🗺 Roadmap

 Camadas (Service/Repository) ✅

 DTOs ✅

 Padronização de respostas (Base Controller / Envelope) 

 Testes unitários (xUnit + Moq)

 Autenticação JWT

 Notification Pattern (substituir exceptions por notificações)

🤝 Contato

Gustavo Henrique Santil — Desenvolvedor Back-end .NET
📧 gustavohenriquesantil@gmail.com

🔗 LinkedIn: www.linkedin.com/in/gustavo-santil
