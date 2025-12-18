EnterpriseApi – API REST con .NET 8, JWT y Roles

EnterpriseApi es una API REST segura desarrollada en ASP.NET Core 8, que implementa autenticación JWT, autorización basada en roles (Admin/User) y persistencia con SQL Server usando Entity Framework Core, siguiendo buenas prácticas de arquitectura.

🧩 Arquitectura del Proyecto

El proyecto sigue una arquitectura en capas (Clean Architecture):



EnterpriseApi
│
├── EnterpriseApi.Api              → API / Controllers / JWT / Swagger
├── EnterpriseApi.Application      → DTOs / Lógica de aplicación
├── EnterpriseApi.Domain           → Entidades y contratos (Interfaces)
├── EnterpriseApi.Infrastructure   → EF Core / Repositorios / DbContext

🛠️ Tecnologías Utilizadas

.NET 8 (ASP.NET Core Web API)

Entity Framework Core

SQL Server (LocalDB / Express)

JWT (JSON Web Tokens)

Swagger / OpenAPI

BCrypt / PasswordHasher

Role-based Authorization

Dependency Injection

🔐 Seguridad Implementada

Registro y login de usuarios

Hash de contraseñas

Generación de JWT con:

Issuer

Audience

Expiración

Protección de endpoints con:

[Authorize]

[Authorize(Roles = "Admin")]

Integración completa de JWT en Swagger

📌 Endpoints Principales
🔓 Públicos
Método	Endpoint	Descripción
POST	/api/Users/register	Registro de usuario
POST	/api/Users/login	Login y generación de JWT
🔒 Protegidos (JWT requerido)
Método	Endpoint	Rol
GET	/api/Users	Admin
GET	/api/Users/{id}	Admin
🔑 Ejemplo de Login
Request
{
  "email": "admin@empresa.com",
  "password": "Admin123*"
}

Response
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}

🧪 Uso del Token en Swagger

Ejecuta la API

Abre Swagger
👉 http://localhost:5293/swagger

Click en Authorize

Ingresa:

Bearer TU_TOKEN_AQUI


Autoriza y prueba endpoints protegidos

🗄️ Configuración (appsettings.json)
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SANTI\\SQLEXPRESS;Database=EnterpriseApiDb;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Jwt": {
    "Key": "CLAVE_SUPER_SEGURA_DE_32_O_MAS_CARACTERES",
    "Issuer": "EnterpriseApi",
    "Audience": "EnterpriseApiUsers",
    "ExpiresInMinutes": 60
  }
}

🧱 Base de Datos

La base de datos se crea automáticamente usando Entity Framework Core Migrations.

Comandos usados:
dotnet ef migrations add InitialCreate -p EnterpriseApi.Infrastructure -s EnterpriseApi.Api
dotnet ef database update -p EnterpriseApi.Infrastructure -s EnterpriseApi.Api

👑 Gestión de Roles

Los roles se manejan mediante el campo Role en la tabla Users.

Ejemplo para asignar Admin:

UPDATE Users
SET Role = 'Admin'
WHERE Email = 'admin@empresa.com';

▶️ Cómo Ejecutar el Proyecto
dotnet restore
dotnet build
dotnet run --project EnterpriseApi.Api


Luego abrir:

http://localhost:5293/swagger

📈 Estado del Proyecto

✔ Autenticación JWT
✔ Autorización por roles
✔ Swagger protegido
✔ EF Core + SQL Server
✔ Arquitectura limpia
✔ Listo para producción / portafolio

👨‍💻 Autor

Santiago Panchi
Estudiante de Ingeniería de Software
UDLA
Proyecto académico / portafolio profesional
