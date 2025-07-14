#  Law Pavilion Library Management System

This is a RESTful API built with ASP.NET Core (.NET 8.0) for managing books in a library. The API allows **authenticated users** to perform CRUD operations on book records, and includes user registration, login (with JWT), pagination, search, and Swagger documentation.

---

##  Folder Structure

```plaintext
│
├── Controllers/            # API Controllers (BooksController, AuthController)
├── Data/                   # AppDbContext and database seed
├── Dtos/                   # Data Transfer Objects (CreateBookDto, UserLoginDto, etc.)
├── Entities/               # Book and User entities
├── Interfaces/
│   ├── Repositories/       # IBookRepository, IUserRepository
│   └── Services/           # IBookService, IUserService
├── Middleware/             # Custom exception middleware
├── Mappings/               # AutoMapper profiles
├── Repositories/           # Repository implementations
├── Services/               # Service implementations
├── Utilities/              # Constants, BaseResponse, etc.
├── Program.cs              # Entry point, service config, middleware pipeline
└── README.md               # This file
```

---

##  Features

-  CRUD operations on books
-  JWT-based authentication
-  User registration & login
-  Search books by title/author
-  Paginate book listings
-  Swagger UI for testing
-  Meaningful HTTP responses and exception handling
-  Follows best practices: DI, DTOs, layered architecture

---

##  API Endpoints

###  Authentication

| Endpoint             | Method | Payload              | Description          |
|----------------------|--------|----------------------|----------------------|
| `/api/auth/register` | POST   | UserRegistrationDto  | Register a new user  |
| `/api/auth/login`    | POST   | UserLoginDto         | Login & get JWT token|

###  Books (Protected with [Authorize])

| Endpoint                          | Method | Payload         | Description             |
|-----------------------------------|--------|------------------|-------------------------|
| `/api/books`                      | GET    |                  | Get all books           |
| `/api/books/{id}`                 | GET    |                  | Get book by ID          |
| `/api/books`                      | POST   | CreateBookDto    | Create a new book       |
| `/api/books`                      | PUT    | UpdateBookDto    | Update a book           |
| `/api/books/{id}`                 | DELETE |                  | Delete a book by ID     |
| `/api/books/search?q=xxx`        | GET    |                  | Search by title/author  |
| `/api/books/paginate?page=1&size=10` | GET |               | Paginate books list     |

---

## 🛠️ How to Run the Application

### ✅ Prerequisites

- .NET SDK 8.0+
- SQL Server (LocalDB or full version)
- Git

###  Setup Instructions

1. **Clone the repository**

```bash
git clone https://github.com/faroukoyekunle/lawpavilion-library-api.git
cd lawpavilion-library-api
```

2. **Configure the database**

Update your `appsettings.json` or `secrets.json` with the following connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=LibraryDb;Trusted_Connection=True;"
}
```

Or use SQL Server LocalDB:

```json
"Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;"
```

3. **Run migrations & seed data**

```bash
dotnet ef database update
```

4. **Run the application**

```bash
dotnet run
```

---

##  Testing the API

Navigate to:

```
https://localhost:{port}/swagger
```

Here you can:

- Test endpoints
- Authenticate using JWT (click `Authorize` and enter: `Bearer {your_token}`)
- View payload structure for registration, login, and book operations

---

##  Authentication Flow (JWT)

1. Register a new user: `POST /api/auth/register`
2. Login with user credentials: `POST /api/auth/login`
3. Copy the returned JWT token
4. Use it in Swagger's "Authorize" button or HTTP header:

```http
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR...
```

---

##  Sample Payloads

### Register
```json
{
  "username": "admin",
  "password": "Admin1234"
}
```

### Login
```json
{
  "username": "admin",
  "password": "Admin1234"
}
```

### Create Book
```json
{
  "title": "1984",
  "author": "George Orwell",
  "isbn": "1234567890123",
  "publishedDate": "1949-06-08T00:00:00"
}
```

---

##  Tools & Tech Stack

- ASP.NET Core 8.0 Web API
- Entity Framework Core + SQL Server
- AutoMapper
- JWT 
- Swagger / Swashbuckle
- Dependency Injection (DI)
- Clean Architecture (Repository-Service-Controller layers)

---

## ✅ Project Expectations

- ✅ Clean folder & layered structure
- ✅ Entity Framework Core for persistence
- ✅ JWT Authentication
- ✅ Book CRUD operations
- ✅ DTO usage
- ✅ Dependency Injection
- ✅ Exception handling middleware
- ✅ Swagger API docs
- ✅ Pagination & search
- ✅ Run with `dotnet run`

---

##  Additional Features

-  `GET /api/books/search?q=term` – search books by title or author
-  `GET /api/books/paginate?page=1&size=10` – supports pagination
-  OpenAPI/Swagger documentation ready

---

##  Author

**Farouk Oyekunle**  
📧 Available upon request

> For questions or improvements, feel free to fork or open an issue.
