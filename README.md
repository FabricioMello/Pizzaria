Pizzaria .NET Core 8
Este é um projeto de exemplo de uma API para uma Pizzaria, desenvolvido com .NET Core 8. A API permite realizar pedidos de pizza, especificar sabores e fornecer o endereço de entrega.

Funcionalidades
Realizar Pedidos: Crie novos pedidos de pizza especificando os sabores desejados.
Listar Pedidos: Obtenha uma lista de todos os pedidos feitos.
Detalhar Pedido: Consulte os detalhes de um pedido específico.
Atualizar Pedido: Atualize as informações de um pedido existente.
Cancelar Pedido: Cancele um pedido.
Endereço de Entrega: Especifique o endereço de entrega para os pedidos.
Tecnologias Utilizadas
.NET Core 8
ASP.NET Core para desenvolvimento da API
Swagger para documentação da API
System.Text.Json para serialização e desserialização de JSON
Entity Framework Core com Pomelo para acesso ao banco de dados MySQL
AutoMapper para mapeamento de entidades
XUnit e FluentAssertions para testes
Dependency Injection para gerenciamento de dependências
Pré-requisitos
.NET 8 SDK instalado
MySQL instalado e configurado
Como Executar
Clone este repositório:

bash
Copiar código
git clone https://github.com/FabricioMello/Pizzaria.git
Navegue até o diretório do projeto:

bash
Copiar código
cd Pizzaria
Restaure as dependências do projeto:

bash
Copiar código
dotnet restore
Atualize a string de conexão com o banco de dados no arquivo appsettings.json:

json
Copiar código
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=PizzariaDB;User=seuUsuario;Password=suaSenha;"
  }
}
Aplique as migrações do Entity Framework Core para criar o banco de dados:

bash
Copiar código
dotnet ef database update
Execute o projeto:

bash
Copiar código
dotnet run
Acesse a documentação da API no Swagger:

Abra o navegador e acesse http://localhost:5000/swagger para visualizar e interagir com a documentação da API.

Estrutura do Projeto
Controllers: Contém os controladores da API.
Models: Contém os modelos de dados.
Data: Contém o contexto do Entity Framework Core.
Services: Contém a lógica de negócios e serviços.
DTOs: Contém os Data Transfer Objects usados para transferir dados entre as camadas.
Mappings: Contém as configurações do AutoMapper.
Tests: Contém os testes de unidade e de integração usando XUnit e FluentAssertions.
Exemplos de Requisições
Criar Pedido
http
Copiar código
POST /api/pedidos
Corpo da Requisição:

json
Copiar código
{
  "cliente": "Nome do Cliente",
  "sabores": ["Calabresa", "Quatro Queijos"],
  "enderecoEntrega": {
    "rua": "Rua Exemplo",
    "numero": 123,
    "cidade": "Cidade Exemplo",
    "estado": "Estado Exemplo",
    "cep": "12345-678"
  }
}
Listar Pedidos
http
Copiar código
GET /api/pedidos
Obter Detalhes de um Pedido
http
Copiar código
GET /api/pedidos/{id}
Atualizar Pedido
http
Copiar código
PUT /api/pedidos/{id}
Corpo da Requisição:

json
Copiar código
{
  "cliente": "Nome Atualizado",
  "sabores": ["Mussarela", "Portuguesa"],
  "enderecoEntrega": {
    "rua": "Rua Atualizada",
    "numero": 456,
    "cidade": "Cidade Atualizada",
    "estado": "Estado Atualizado",
    "cep": "87654-321"
  }
}
Cancelar Pedido
http
Copiar código
DELETE /api/pedidos/{id}
Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests no repositório do GitHub.

Licença
Este projeto está licenciado sob a Licença MIT. Consulte o arquivo LICENSE para obter mais informações.
