FilmesApi
Uma API REST desenvolvida em .NET 9 para gerenciar filmes, com operações CRUD completas e banco de dados MySQL.
🎯 Sobre o Projeto
FilmesApi é uma aplicação backend que fornece endpoints para criar, consultar, atualizar e deletar filmes. O projeto utiliza as melhores práticas de desenvolvimento com ASP.NET Core, EntityFramework Core e AutoMapper.

✨ Funcionalidades
•	✅ Criar Filmes - Adicionar novos filmes ao banco de dados
•	✅ Listar Filmes - Recuperar todos os filmes com paginação
•	✅ Buscar por ID - Consultar um filme específico
•	✅ Atualizar Filmes - Atualização completa ou parcial (PATCH)
•	✅ Deletar Filmes - Remover filmes do banco de dados
•	✅ Validação de Dados - Validações robustas no modelo
•	✅ Documentação Swagger - API documentada e testável
🛠️ Tecnologias Utilizadas
•	Framework: ASP.NET Core (.NET 9)
•	Banco de Dados: MySQL
•	ORM: Entity Framework Core
•	Mapeamento: AutoMapper
•	Documentação: Swagger/OpenAPI
•	Serialização: Newtonsoft.Json

📚 Endpoints da API
Filmes
Método	Rota	Descrição
POST	/filmes	Criar um novo filme
GET	/filmes	Listar todos os filmes (com paginação)
GET	/filmes/{id}	Obter detalhes de um filme
PUT	/filmes/{id}	Atualizar um filme completamente
PATCH	/filmes/{id}	Atualizar parcialmente um filme
DELETE	/filmes/{id}	Deletar um filme
