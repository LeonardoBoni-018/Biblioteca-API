# BibliotecaAPI

API REST para gerenciamento de biblioteca com autenticação JWT.

## Tecnologias

- .NET 10
- Entity Framework Core + SQL Server
- JWT Bearer Authentication
- Swagger UI

## Endpoints

| Método | Rota | Descrição |
|---|---|---|
| POST | `/api/auth/register` | Cadastro de usuário |
| POST | `/api/auth/login` | Login e retorno do token JWT |

## Como executar

1. Configure a connection string em `appsettings.json`
2. Execute as migrations:
   ```
   dotnet ef database update
   ```
3. Inicie o projeto:
   ```
   dotnet run
   ```
4. Acesse o Swagger em: `http://localhost:5116/swagger`
