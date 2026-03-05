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