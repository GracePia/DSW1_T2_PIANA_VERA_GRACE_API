# Library API – Sistema de Préstamo de Libros  
Proyecto del Examen – Arquitectura Hexagonal  
**Alumno:** APELLIDOS, NOMBRE  
**Curso:** Desarrollo de Servicios Web I  

---
## Overview

This API allows managing books (CRUD) and loans, including stock validation, loan returns, and transactional operations like book liquidation.  
It separates concerns into **Domain**, **Application**, and **Infrastructure** layers.

---

## Architecture

- **Domain**: Contains entities, exceptions, and repository interfaces.  
- **Application**: Contains application services, DTOs, and interfaces.  
- **Infrastructure**: Contains repository implementations and database access.  
- **API**: ASP.NET Core Web API exposing endpoints for books and loans, with Swagger documentation.

---

## Tech Stack

- .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core (Infrastructure layer)  
- Swagger/OpenAPI for API documentation  
- AutoMapper for mapping DTOs  
- Clean Architecture pattern

---

## Getting Started

### Prerequisites

- .NET 8 SDK  
- Visual Studio 2022 or VS Code  
- SQL Server / LocalDB

### Installation

Clone the repository:

```bash
git clone <repository-url>
cd DSW1_T2_PIANA_VERA_GRACE
Restore dependencies:

bash
Copiar código
dotnet restore
Run the API:

bash
Copiar código
cd src/Library.API
dotnet run
API is available at: https://localhost:5210

Swagger UI: http://localhost:5210/swagger/index.html

API Endpoints
Books

GET /api/books → List all books

GET /api/books/{id} → Get book by ID

POST /api/books → Create a new book

DELETE /api/books/{id} → Delete a book

Loans

GET /api/loans → List all loans

GET /api/loans/active → List active loans

POST /api/loans → Create a new loan

PUT /api/loans/return/{id} → Return a loan

DELETE /api/loans/{id} → Delete a loan