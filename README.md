# BibliotecaAPI

API REST para gerenciamento de biblioteca com autenticação JWT.

## Tecnologias

- .NET 10
- Entity Framework Core + SQL Server
- JWT Bearer Authentication
- BCrypt (hash de senhas)
- Swagger UI

## Endpoints

### Autenticação
| Método | Rota | Autorização | Descrição |
|---|---|---|---|
| POST | `/api/auth/register` | Público | Cadastro de usuário |
| POST | `/api/auth/login` | Público | Login e retorno do token JWT |

### Usuários
| Método | Rota | Autorização | Descrição |
|---|---|---|---|
| GET | `/api/user` | Público | Listar todos |
| GET | `/api/user/{id}` | Público | Obter por ID |
| POST | `/api/user` | Público | Criar usuário |
| PUT | `/api/user/{id}` | Admin | Atualizar |
| DELETE | `/api/user/{id}` | Admin | Remover |

### Autores
| Método | Rota | Autorização | Descrição |
|---|---|---|---|
| GET | `/api/author` | Público | Listar todos |
| GET | `/api/author/{id}` | Público | Obter por ID |
| POST | `/api/author` | Admin | Criar |
| PUT | `/api/author/{id}` | Admin | Atualizar |
| DELETE | `/api/author/{id}` | Admin | Remover |

### Livros
| Método | Rota | Autorização | Descrição |
|---|---|---|---|
| GET | `/api/book` | Público | Listar todos |
| GET | `/api/book/{id}` | Público | Obter por ID |
| POST | `/api/book` | Admin | Criar |
| PUT | `/api/book/{id}` | Admin | Atualizar |
| DELETE | `/api/book/{id}` | Admin | Remover |

## Models

- **User** — Id, Name, Email, PasswordHash, Role
- **Author** — Id, Name, Nationality, BirthDate
- **Book** — Id, Title, YearPublished, Genre, Isbn, IsRented, AuthorId
- **Rental** — Id, UserId, BookId, RentalDate, ReturnDate

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
