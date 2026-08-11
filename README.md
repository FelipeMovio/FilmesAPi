# 🎬 FilmesApi

Uma API REST desenvolvida em **ASP.NET Core (.NET 9)** para gerenciamento de filmes, utilizando **Entity Framework Core**, **MySQL** e **AutoMapper**.

## 🎯 Sobre o Projeto

O **FilmesApi** é uma aplicação backend que disponibiliza uma API REST para realizar o gerenciamento de filmes.

A aplicação permite realizar operações completas de **CRUD (Create, Read, Update e Delete)**, além de contar com paginação, validação de dados e documentação através do Swagger.

O projeto foi desenvolvido com foco na utilização de boas práticas no desenvolvimento de APIs utilizando o ecossistema **.NET**.

## ✨ Funcionalidades

* ✅ **Criar filmes** — Adicionar novos filmes ao banco de dados
* ✅ **Listar filmes** — Recuperar filmes cadastrados com paginação
* ✅ **Buscar filme por ID** — Consultar informações de um filme específico
* ✅ **Atualizar filme** — Atualização completa através de `PUT`
* ✅ **Atualização parcial** — Alterar campos específicos através de `PATCH`
* ✅ **Deletar filme** — Remover filmes do banco de dados
* ✅ **Validação de dados** — Validação das informações recebidas pela API
* ✅ **Swagger/OpenAPI** — Documentação e testes dos endpoints

## 🛠️ Tecnologias Utilizadas

| Tecnologia                | Utilização                          |
| ------------------------- | ----------------------------------- |
| **C#**                    | Linguagem de programação            |
| **.NET 9**                | Framework de desenvolvimento        |
| **ASP.NET Core**          | Construção da API REST              |
| **Entity Framework Core** | ORM para acesso ao banco            |
| **MySQL**                 | Banco de dados                      |
| **AutoMapper**            | Mapeamento entre entidades e DTOs   |
| **Swagger / OpenAPI**     | Documentação e testes da API        |
| **Newtonsoft.Json**       | Serialização e desserialização JSON |

## 🏗️ Arquitetura

O projeto utiliza uma estrutura organizada para separar as responsabilidades da aplicação.

```text
FilmesApi/
│
├── Controllers/
│   └── FilmesController.cs
│
├── Data/
│   └── FilmeContext.cs
│
├── Models/
│   └── Filme.cs
│
├── DTOs/
│   └── ...
│
├── Profiles/
│   └── ...
│
├── Migrations/
│   └── ...
│
├── Program.cs
├── appsettings.json
└── FilmesApi.csproj
```

## 📚 Endpoints

### 🎬 Criar filme

```http
POST /filmes
```

Adiciona um novo filme ao banco de dados.

---

### 📋 Listar filmes

```http
GET /filmes
```

Retorna os filmes cadastrados.

A listagem suporta **paginação** para facilitar o gerenciamento de grandes quantidades de registros.

---

### 🔎 Buscar filme por ID

```http
GET /filmes/{id}
```

Retorna os dados de um filme específico.

**Exemplo:**

```http
GET /filmes/1
```

---

### ✏️ Atualizar filme

```http
PUT /filmes/{id}
```

Realiza a atualização completa dos dados de um filme.

**Exemplo:**

```http
PUT /filmes/1
```

---

### 🩹 Atualização parcial

```http
PATCH /filmes/{id}
```

Permite atualizar parcialmente os dados de um filme, alterando somente os campos necessários.

**Exemplo:**

```http
PATCH /filmes/1
```

---

### 🗑️ Deletar filme

```http
DELETE /filmes/{id}
```

Remove um filme do banco de dados.

**Exemplo:**

```http
DELETE /filmes/1
```

## 🗄️ Banco de Dados

O projeto utiliza **MySQL** como banco de dados e **Entity Framework Core** como ORM.

A conexão com o banco é configurada através da `ConnectionString`.

Exemplo:

```json
{
  "ConnectionStrings": {
    "FilmesConnection": "server=localhost;database=filmes;user=root;password=sua_senha;"
  }
}
```

> ⚠️ Evite publicar senhas ou informações sensíveis diretamente no repositório.

## 🚀 Como Executar o Projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/FelipeMovio/FilmesApi.git
```

### 2. Acessar o diretório

```bash
cd FilmesApi
```

### 3. Restaurar as dependências

```bash
dotnet restore
```

### 4. Configurar o banco de dados

Configure a `ConnectionString` do MySQL no arquivo de configuração da aplicação.

### 5. Executar as migrations

```bash
dotnet ef database update
```

### 6. Executar a aplicação

```bash
dotnet run
```

Após iniciar a aplicação, a API estará disponível localmente.

## 📖 Swagger

A API possui documentação através do **Swagger/OpenAPI**, permitindo visualizar e testar os endpoints diretamente pelo navegador.

Com a aplicação em execução, acesse:

```text
/swagger
```

O Swagger permite testar operações como:

* Criar filmes
* Listar filmes
* Buscar filmes por ID
* Atualizar filmes
* Atualizar parcialmente
* Deletar filmes

## 🔄 Exemplo de Fluxo

Um exemplo de utilização da API:

```text
Cliente
   │
   ▼
POST /filmes
   │
   ▼
ASP.NET Core
   │
   ▼
Entity Framework Core
   │
   ▼
MySQL
```

Depois, os filmes podem ser consultados através de:

```text
GET /filmes
```

Ou um filme específico:

```text
GET /filmes/{id}
```

## 🎓 Objetivo do Projeto

Este projeto foi desenvolvido com o objetivo de praticar e consolidar conhecimentos em:

* Desenvolvimento de APIs REST
* C# e ASP.NET Core
* Entity Framework Core
* Banco de dados MySQL
* CRUD
* DTOs
* AutoMapper
* Migrations
* Paginação
* Validação de dados
* Swagger/OpenAPI
* Arquitetura e organização de projetos .NET

## 👨‍💻 Autor

**Felipe Movio**

Projeto desenvolvido para fins de estudo e evolução no desenvolvimento backend com **C# e .NET**.
