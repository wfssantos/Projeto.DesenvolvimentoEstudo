 TODO: stop container 'projeto.desenvolvimentoestudo.authazurefunctions' and run manual => func start --port 7072 (debbug mod)

# Projeto.DesenvolvimentoEstudo

# Developer Evaluation Project

This project demonstrates the implementation of a modern backend architecture using .NET technologies, following best practices for clean architecture, separation of concerns, and containerized environments.

All documentation and code are written in English as required.

---

# 🚀 Running the Project

To start the project using Docker, follow the steps below.

## 1. Stop Existing Containers

Stops and removes all containers defined in the docker-compose configuration.

```bash
docker compose down
```

## 2. Clean Docker Environment

Removes unused Docker resources (containers, networks, images and cache) to guarantee a clean environment.

```bash
docker system prune -af
```

## 3. Build and Start the Application

Builds all images and starts the environment in detached mode.

```bash
docker compose up -d --build
```

After execution, all services will be available locally.

---

# 🌐 Service Endpoints

______________________________________________________________________________
| Service             | URL                                                  |
|---------------------|------------------------------------------------------|
| Web API (Swagger)   | http://localhost:8080/swagger/index.html             |
| Blazor Application  | http://localhost:8090/                               |
| Azure Functions     | http://localhost:7072/api				             |
| PostgreSQL Database | localhost:5432 - DeveloperDB - developer / test@2025 |
|____________________________________________________________________________|

---

# 🏗️ Architecture Overview

This project follows **Clean Architecture principles**, separating responsibilities into well-defined layers.

The architecture is organized into the following layers:

```
Core
 ├── Application
 └── Domain

Crosscutting
 ├── Common
 ├── IoC
 └── Language

Infrastructure
 └── ORM

Presentation
 ├── APIAuthAzureFunctions
 ├── WebAPI
 └── WebBlazor
```

### Layer Responsibilities

**Domain**

Contains the core business logic and domain entities.

**Application**

Implements use cases and application services.

**Crosscutting**

Contains shared utilities used across layers such as:

- Dependency Injection
- Common helpers
- Language resources

**Infrastructure**

Handles persistence and external integrations.

- ORM implementation
- Database access
- Entity Framework Core

**Presentation**

Responsible for exposing the application to users and external systems.

Includes:

- Web API
- Blazor frontend
- Azure Functions

---

# 📦 Project Structure

```
Projeto.DesenvolvimentoEstudo
│
├── Core
│   ├── Projeto.DesenvolvimentoEstudo.Application
│   └── Projeto.DesenvolvimentoEstudo.Domain
│
├── Crosscutting
│   ├── Projeto.DesenvolvimentoEstudo.Common
│   ├── Projeto.DesenvolvimentoEstudo.IoC
│   └── Projeto.DesenvolvimentoEstudo.Language
│
├── Infrastructure
│   └── Projeto.DesenvolvimentoEstudo.ORM
│
├── Presentation
│   ├── Projeto.DesenvolvimentoEstudo.APIAuthAzureFunctions
│   ├── Projeto.DesenvolvimentoEstudo.WebAPI
│   └── Projeto.DesenvolvimentoEstudo.WebBlazor
│
├── docker-compose
│   └── docker-compose.yml
│
└── README.md
```

---

# 🧱 Technologies Used

- .NET 8
- ASP.NET Core
- Blazor
- Azure Functions
- Entity Framework Core
- PostgreSQL
- Docker
- Docker Compose

---

# 🔧 Development Practices

The project follows modern development practices:

- Clean Architecture
- Layered architecture
- Dependency Injection
- Git Flow
- Semantic commits
- Separation of concerns
- Containerized environment

---

# 🔍 Azure Functions Debug Mode

When running the project using Docker, the Azure Functions service runs inside a container.

However, during development it may be useful to run the Functions locally in **debug mode**.

To do this, stop the container and start the function manually.

## 1. Stop the Azure Functions Container

```bash
docker stop projeto.desenvolvimentoestudo.authazurefunctions
```

## 2. Run Azure Functions Locally

Navigate to the Azure Functions project folder:

```bash
cd Presentation/Projeto.DesenvolvimentoEstudo.APIAuthAzureFunctions
```

Run the function host manually:

```bash
func start --port 7072
```

This allows debugging directly from the IDE.

---

# 🔐 Authentication Flow (JWT + MFA)

This project implements a **modern authentication flow** based on:

- JWT (JSON Web Tokens)
- Multi-Factor Authentication (TOTP)
- Stateless authentication
- Token validation

The authentication system is implemented using **Azure Functions**.

---

# Authentication Architecture

```
Blazor Client
      │
      │ POST /auth/token
      ▼
Azure Function (AuthToken)
      │
      │ Validate username/password
      ▼
MFA Challenge
(mfa_token)
      │
      │ POST /auth/verify-mfa
      ▼
Azure Function (VerifyMfa)
      │
      │ Validate TOTP
      ▼
Access Token (JWT)
      │
      │ Authorization: Bearer <token>
      ▼
Protected APIs
      │
      ▼
GET /auth/me
```

---

# Step 1 — Request Authentication

Endpoint:

```
POST /api/auth/token
```

Request:

```json
{
  "username": "admin",
  "password": "password"
}
```

Response:

```json
{
  "mfa_required": true,
  "mfa_token": "JWT_TOKEN",
  "message": "MFA required. Provide TOTP code to verify."
}
```

The `mfa_token` is a **temporary token used only to complete MFA verification**.

---

# Step 2 — Verify Multi-Factor Authentication

Endpoint:

```
POST /api/auth/verify-mfa
```

Request:

```json
{
  "mfaToken": "JWT_TOKEN",
  "code": "123456"
}
```

Response:

```json
{
  "token_type": "Bearer",
  "access_token": "JWT_ACCESS_TOKEN",
  "expires_in": 1800
}
```

The returned `access_token` represents a **fully authenticated session**.

---

# Step 3 — Access Protected APIs

Protected endpoints require the JWT token.

Example request:

```
Authorization: Bearer <access_token>
```

---

# Step 4 — Retrieve Current User

Endpoint:

```
GET /api/auth/me
```

Headers:

```
Authorization: Bearer <access_token>
```

Response:

```json
{
  "username": "admin",
  "amr": "pwd+mfa"
}
```

### Meaning of `amr`

`amr` stands for **Authentication Methods Reference**.

Example:

```
pwd+mfa
```

Meaning the user authenticated using:

- password
- multi-factor authentication

---

# Token Types

| Token | Purpose |
|------|------|
| `mfa_token` | Temporary token used only during MFA verification |
| `access_token` | JWT token used to access protected resources |

---

# Security Principles Implemented

The authentication architecture demonstrates several important security principles.

### Stateless Authentication

The server does not store user sessions.

All authentication information is contained inside the JWT token.

### Multi-Factor Authentication (MFA)

Authentication requires:

- username/password
- a valid TOTP code

### Token Purpose Separation

The system distinguishes between:

- **challenge tokens** (`mfa_token`)
- **access tokens** (`access_token`)

This prevents bypassing the MFA verification step.

---

# Notes

This authentication flow is implemented **for demonstration purposes**.

In production environments, dedicated identity platforms are commonly used:

- Azure Entra ID
- Keycloak
- IdentityServer
- Auth0
- AWS Cognito

This project demonstrates the **core authentication mechanisms behind those systems**.

---

# 🇧🇷 Executando o Projeto

Para executar o projeto utilizando Docker, siga os passos abaixo.

## 1. Parar Containers Existentes

```bash
docker compose down
```

## 2. Limpar o Ambiente Docker

```bash
docker system prune -af
```

## 3. Construir e Iniciar a Aplicação

```bash
docker compose up -d --build
```

Após executar os comandos, os serviços estarão disponíveis localmente.

---

# 🌐 Endpoints dos Serviços

| Serviço           | URL                           |
|-------------------|------                         |
| Web API (Swagger) | http://localhost:8080/swagger |
| Aplicação Blazor  | http://localhost:8090         |
| Azure Functions   | http://localhost:7072         |
| Banco PostgreSQL  | localhost:5432                |

---

# 📌 Observações

- Certifique-se de que o **Docker Desktop esteja em execução** antes de iniciar o ambiente.
- O ambiente completo é iniciado através do **Docker Compose**.
- Caso ocorram problemas durante o build, execute novamente os comandos de limpeza do Docker.

---

# 👨‍💻 Author

William Santos