# HealthBooking API

API de gestión de citas médicas con .NET 10 usando Onion Architecture.

---

## 🏗️ Arquitectura: Onion Architecture

Arquitectura basada en capas concéntricas:

```
┌─────────────────────────────┐
│   Presentation (Web)        │  APIs, Controllers
├─────────────────────────────┤
│  Application (Application)  │  CQRS, Casos de uso
├─────────────────────────────┤
│     Domain (Domain)         │  Entidades, Lógica
├─────────────────────────────┤
│ Infrastructure (Infra)      │  BD, Repositorios
└─────────────────────────────┘
```

**Características:**
- Independencia de frameworks
- Lógica core aislada
- Fácil testabilidad
- Inversión de dependencias

### Proyectos
- **Domain** - Entidades, Eventos, Excepciones
- **Application** - CQRS, Validaciones, Comportamientos
- **Infrastructure** - EF Core, SQLite, Identity, Repositorios
- **Web** - Controllers REST, OpenAPI
- **Shared** - Utilidades
- **tests/** - Unit, Integration, Functional

---

## 🛠️ Stack Tecnológico

### Framework
| Componente | Versión |
|-----------|---------|
| .NET | 10.0 |
| ASP.NET Core | 10.0 |

### Base de Datos
| Componente | Versión |
|-----------|---------|
| SQLite | Latest |
| Entity Framework Core | 10.0.5 |

### Herramientas de Aplicación
| Herramienta | Versión |
|-----------|---------|
| MediatR (CQRS) | 14.1.0 |
| AutoMapper | 16.1.1 |
| FluentValidation | 12.1.1 |
| Ardalis.GuardClauses | 5.0.0 |

### Autenticación
| Componente | Versión |
|-----------|---------|
| ASP.NET Core Identity | 10.0 |
| JWT Tokens | 8.16.0 |

### API Documentation
| Componente | Versión |
|-----------|---------|
| OpenAPI | 10.0.5 |
| Scalar UI | 2.13.13 |

### Testing
| Framework | Versión |
|-----------|---------|
| NUnit | 4.5.1 |
| Moq | 4.20.72 |

---

## ✨ Características

**Funcionales:**
✅ CRUD Citas, Profesionales, Categorías
✅ Autenticación JWT
✅ Autorización por roles
✅ Auditoría automática
✅ Domain Events

**Técnicas:**
✅ Onion Architecture
✅ CQRS Pattern
✅ Mediator Pattern
✅ Repository Pattern
✅ OpenAPI Docs
✅ Exception Handling
✅ Validación automática
✅ Object Mapping
✅ Tests (Unit/Integration/E2E)

---

## 🚀 Quick Start

```bash
# Clonar
git clone https://github.com/Luciano-Grilli/HealthBookingAPI.git
cd HealthBookingAPI

# Restaurar
dotnet restore

# Migraciones
dotnet ef database update -p src/Infrastructure -s src/Web

# Ejecutar
dotnet run --project src/Web
```

**API Docs**: http://localhost:5000/scalar

### Tests
```bash
dotnet test
```

---

## 👤 Autor

Luciano Grilli - [@GitHub](https://github.com/Luciano-Grilli)

**Versión**: .NET 10.0 | **Status**: ✅ Activo
