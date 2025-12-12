# Library API – Sistema de Préstamo de Libros  
Proyecto del Examen – Arquitectura Hexagonal  
**Alumno:** APELLIDOS, NOMBRE  
**Curso:** Desarrollo de Servicios Web I  

---

## Arquitectura  
El proyecto sigue la Arquitectura Hexagonal (Ports & Adapters), dividido en:

- **Library.Domain**
  - Entidades: Book, Loan
  - Excepciones de Dominio
  - Interfaces (Ports OUT): Repositorios + UnitOfWork

- **Library.Application**
  - DTOs
  - Interfaces de Servicios (Ports IN)
  - Servicios: BookService, LoanService
  - AutoMapper (MappingProfile)

- **Library.Infrastructure**
  - ApplicationDbContext (EF Core)
  - Repositorios (Repository, BookRepository, LoanRepository)
  - UnitOfWork
  - Dependency Injection

- **Library.API**
  - Controladores (BooksController, LoansController)
  - Configuración general  
  - Manejo de excepciones global

---

## Requisitos  
- .NET 8  
- SQL Server  
- EF Core 8  
- AutoMapper  
- Swashbuckle (Swagger)

---

## Cómo ejecutar el proyecto

### Restaurar paquetes
```bash
dotnet restore
