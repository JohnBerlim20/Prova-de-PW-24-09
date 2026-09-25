# BibliotecaMVC

Sistema web para gerenciamento de acervo de uma biblioteca, desenvolvido com **ASP.NET Core MVC**, **Entity Framework Core** e **MySQL**.

O projeto implementa as operações básicas de um CRUD de livros, com uma interface web para visualizar, cadastrar, editar e excluir registros do acervo.

## Funcionalidades

- Página inicial com visão geral do sistema.
- Cadastro de livros.
- Listagem dos livros cadastrados.
- Edição de livros.
- Exclusão de livros.
- Persistência dos dados em MySQL.
- Migrations do Entity Framework Core para controle da estrutura do banco.
- Interface responsiva utilizando Bootstrap.
- Consulta de capas de livros pela Open Library quando ISBN ou título estão disponíveis.
- Favicon personalizado para a aplicação.

## Tecnologias utilizadas

| Tecnologia | Utilização |
|---|---|
| C# | Linguagem principal |
| ASP.NET Core MVC | Framework da aplicação web |
| .NET 10 | Plataforma de execução |
| Entity Framework Core | ORM e acesso ao banco |
| MySQL | Banco de dados |
| Bootstrap | Componentes e responsividade da interface |
| Razor | Construção das Views |
| Open Library API | Consulta opcional de capas de livros |

## Arquitetura

O projeto utiliza o padrão **MVC (Model-View-Controller)** e separa o acesso aos dados por meio da camada de **Repository**.

### Model

Representa os dados utilizados pela aplicação.

- `Models/Livro.cs` — entidade de livro.
- `Models/ErrorViewModel.cs` — modelo utilizado para tratamento e exibição de erros.

### View

Responsável pela interface apresentada ao usuário.

- `Views/Home/Index.cshtml` — página inicial.
- `Views/Home/Privacy.cshtml` — página de privacidade.
- `Views/Livro/Index.cshtml` — listagem do acervo.
- `Views/Livro/CriarEditar.cshtml` — formulário de cadastro e edição.
- `Views/Shared/_Layout.cshtml` — layout compartilhado, incluindo header, navegação e footer.

### Controller

Recebe as requisições, coordena as operações e encaminha os dados para as Views.

- `Controllers/HomeController.cs` — páginas gerais da aplicação.
- `Controllers/LivroController.cs` — operações do CRUD de livros.

### Repository

Centraliza as operações de persistência dos livros.

- `Repository/ILivroRepository.cs` — contrato do repositório.
- `Repository/LivroRepository.cs` — implementação das operações no banco de dados.

### Data

Responsável pelo contexto do Entity Framework Core.

- `Data/DatabaseContext.cs` — `DbContext` utilizado para acessar a tabela de livros.

### Migrations

Contém as migrations criadas pelo Entity Framework Core para versionamento da estrutura do banco.

- `Migrations/20260806173359_CriacaoTabelaLivro.cs`
- `Migrations/20260924162524_dbContext.cs`
- `Migrations/DatabaseContextModelSnapshot.cs`

## Estrutura do projeto

```text
BibliotecaMVC/
├── Controllers/
│   ├── HomeController.cs
│   └── LivroController.cs
│
├── Data/
│   └── DatabaseContext.cs
│
├── Migrations/
│   ├── 20260806173359_CriacaoTabelaLivro.cs
│   ├── 20260806173359_CriacaoTabelaLivro.Designer.cs
│   ├── 20260924162524_dbContext.cs
│   ├── 20260924162524_dbContext.Designer.cs
│   └── DatabaseContextModelSnapshot.cs
│
├── Models/
│   ├── ErrorViewModel.cs
│   └── Livro.cs
│
├── Repository/
│   ├── ILivroRepository.cs
│   └── LivroRepository.cs
│
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   ├── Livro/
│   │   ├── CriarEditar.cshtml
│   │   └── Index.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   ├── _Layout.cshtml.css
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   └── Error.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
│
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   ├── lib/
│   │   ├── bootstrap/
│   │   ├── jquery/
│   │   ├── jquery-validation/
│   │   └── jquery-validation-unobtrusive/
│   └── favicon.ico
│
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── ProjetoCadastroMVC.csproj
└── ProjetoCadastroMVC.slnx
```

## Modelo de dados

A entidade `Livro` possui os seguintes campos:

| Campo | Tipo | Descrição |
|---|---|---|
| `Id` | `int` | Identificador do livro |
| `Titulo` | `string` | Título da obra |
| `ISBN` | `string` | ISBN do livro |
| `Autor` | `string` | Autor da obra |
| `Editora` | `string` | Editora responsável pela publicação |
| `AnoPublicacao` | `int` | Ano de publicação |

O contexto `DatabaseContext` expõe a coleção `Livros`, que é utilizada pelo `LivroRepository` para realizar as operações no banco.

## Banco de dados

A aplicação está configurada para utilizar **MySQL**.

A configuração atual do projeto utiliza uma connection string chamada `Database` em `appsettings.json`:

```json
"ConnectionStrings": {
  "Database": "Server=localhost;Port=3306;Database=biblioteca;User=root;Password=;"
}
```

Antes de executar o projeto, verifique se o MySQL está em execução e ajuste a connection string conforme o ambiente local.

## Pré-requisitos

Instale os seguintes componentes:

- .NET SDK compatível com `net10.0`.
- MySQL Server.
- Visual Studio, Visual Studio Code ou outra IDE compatível com ASP.NET Core.

## Configuração e execução

### 1. Clone o repositório

```bash
git clone <URL-DO-REPOSITORIO>
cd BibliotecaMVC
```

### 2. Configure o banco de dados

Crie ou disponibilize um banco MySQL chamado `biblioteca` e confira os dados de acesso em `appsettings.json`.

### 3. Restaure as dependências

```bash
dotnet restore
```

### 4. Execute as migrations

Com o Entity Framework Core configurado, aplique as migrations:

```bash
dotnet ef database update
```

Caso o comando `dotnet ef` não esteja disponível:

```bash
dotnet tool install --global dotnet-ef
```

### 5. Inicie a aplicação

```bash
dotnet run
```

O endereço exibido no terminal será utilizado para acessar a aplicação pelo navegador.

## Fluxo do CRUD

O gerenciamento de livros segue o fluxo:

```text
Usuário
   ↓
LivroController
   ↓
ILivroRepository
   ↓
LivroRepository
   ↓
DatabaseContext
   ↓
MySQL
```

Para uma consulta, inclusão, alteração ou exclusão, o `LivroController` utiliza a abstração `ILivroRepository`, enquanto o `LivroRepository` executa as operações por meio do Entity Framework Core.

## Interface

O layout compartilhado está em `Views/Shared/_Layout.cshtml` e concentra a estrutura comum das páginas, incluindo:

- header e navegação;
- conteúdo principal;
- footer;
- carregamento das bibliotecas JavaScript;
- carregamento dos arquivos CSS globais.

Os estilos principais estão em `wwwroot/css/site.css`.

## Capas dos livros

A página do acervo possui uma integração com a **Open Library** para tentar carregar capas automaticamente.

A lógica segue esta ordem:

1. utiliza o ISBN informado para procurar a capa;
2. caso não exista ISBN, tenta localizar o livro pelo título;
3. se nenhuma capa for encontrada, mantém o placeholder do livro.

A integração é realizada no navegador diretamente pela View `Views/Livro/Index.cshtml`.

## Dependências NuGet

As principais dependências definidas no projeto são:

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Design`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microting.EntityFrameworkCore.MySql`

As versões utilizadas estão definidas no arquivo `ProjetoCadastroMVC.csproj`.

## Controle de versão

O projeto possui um `.gitignore` para evitar o versionamento de arquivos gerados automaticamente, como:

- `.vs/`
- `bin/`
- `obj/`
- arquivos temporários de IDE;
- logs;
- arquivos de ambiente e publicação.

Arquivos-fonte, Views, Controllers, Models, Migrations, configurações e recursos necessários para a aplicação permanecem versionáveis.
