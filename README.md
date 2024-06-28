# Pizzaria .NET 8

Este é um projeto de exemplo de uma API para uma Pizzaria, desenvolvido com .NET Core 8. A API permite realizar pedidos de pizza, especificar sabores e fornecer o endereço de entrega.

## Funcionalidades

- **Realizar Pedidos**: Crie novos pedidos de pizza especificando os sabores desejados.
- **Detalhar Pedido**: Consulte os detalhes de um pedido específico.

## Tecnologias Utilizadas

- .NET Core 8
- ASP.NET Core para desenvolvimento da API
- Swagger para documentação da API
- System.Text.Json para serialização e desserialização de JSON
- Entity Framework Core com Pomelo para acesso ao banco de dados MySQL
- AutoMapper para mapeamento de entidades
- XUnit e FluentAssertions para testes
- Dependency Injection para gerenciamento de dependências

## Pré-requisitos

- .NET 8 SDK instalado
- MySQL instalado e configurado

## Como Executar

1. Clone este repositório:

   ```bash
   git clone https://github.com/FabricioMello/Pizzaria.git

2. Navegue até o diretório do projeto:

   ```bash
   cd Pizzaria

3. Restaure as dependências do projeto:

   ```bash
   dotnet restore

4. Atualize a string de conexão com o banco de dados no arquivo appsettings.json:

   ```bash
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=PizzariaDB;User=seuUsuario;Password=suaSenha;"
      }
    }


5. Aplique as migrações do Entity Framework Core para criar o banco de dados:

   ```bash
   dotnet ef database update
   
6. Execute o projeto:

   ```bash
   dotnet run
   
7. Acesse a documentação da API no Swagger:

   ```bash
   Abra o navegador e acesse http://localhost:5000/swagger para visualizar e interagir com a documentação da API.


## Estrutura do Projeto

- **API**: Contém os controladores da API.
- **Application**: Contém a lógica de aplicação e serviços.
- **CrossCutting**: Contém as configurações transversais do projeto.
- **Domain**: Contém as entidades de domínio e regras de negócio.
- **Domain.Tests**: Contém os testes unitários do domínio.
- **Infrastructure**: Contém a implementação de infraestrutura como acesso a banco de dados e serviços externos.
