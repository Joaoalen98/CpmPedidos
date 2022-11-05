<br>

# CpmPedidos

Projeto em desenvolvimento para estudo e implementação do Entity Framework Core com C#, seguindo as boas práticas de desenvolvimento.

<br>
<br

## Descrição

O projeto constitui em um conjunto de outros projetos, separados cada um por função. 

<br>
<br

### CpmPedidos.API
A API é a responsável por receber requisições e enviar respostas, e mesma apenas tem esta função, em nenhum momento manipula o prórpio DbContext, evitando acoplamento e facilitando manuntenções futuras

<br>

#### AppBaseController
![image](https://user-images.githubusercontent.com/89602176/200096827-8a60c005-153a-4bfe-8f67-cf515bc96ae6.png)
O `AppBaseController` é a classe base da qual todos os outros controladores iram herdar, ele tem a função de receber os serviços da aplicação, os quais serão usados nos seus controladores filhos.

#### Funções do controlador de produtos usando o `serviceProvider` para usar os serviços da interface:
![image](https://user-images.githubusercontent.com/89602176/200096939-cde745a9-2069-4ab0-aa82-569363b85b80.png)

<br>
<br>

### CpmPedidos.Domain

Uma biblioteca de classes, encarregada de armazenar os modelos das entidades do projeto, os enums e interfaces.
<br>
<br>

#### Modelo base da entidade:
![image](https://user-images.githubusercontent.com/89602176/195497428-99197624-ecd0-4721-a28a-7d180604686c.png)

<br>

#### Entidade de exemplo:
![image](https://user-images.githubusercontent.com/89602176/195499327-ace174e2-05af-4f08-b55d-9dfd45a65855.png)

<br>

#### Exemplo de enum usado:

![image](https://user-images.githubusercontent.com/89602176/195497546-6b50a54f-b8a6-4bad-822a-c24f447a7154.png)

<br>

#### Exemplo de interface usada (uma entidade implementa esta interface, quando ela pode estar ativa, ou inativada):

![image](https://user-images.githubusercontent.com/89602176/195497720-0b2117ce-4d90-414b-8dc3-684480f44f0b.png)

<br>
<br>

### CpmPedidos.Interface
Guarda as interfaces usadas nas funções do CpmPedidos.Repository.

#### Exemplo de interface
![image](https://user-images.githubusercontent.com/89602176/200097058-d8528221-ed2c-4673-8211-486e8d2ce6f3.png)
Estas interfaces são injetadas na API, que será utilizada para executar as funções presentes nas classes concretas do repository

<br>
<br>

### CpmPedidos.Repository
Esta biblioteca de classes tem a função de salvar o nosso contexto do banco de dados, e o mapeamento das nossas entidades.

<br>

#### DbContext do projeto

![image](https://user-images.githubusercontent.com/89602176/195498878-21c64f0d-186c-4dbc-897a-4f7dcaf8ec60.png)

<br>

#### DesignTimeDbContextFactory
DesignTimeDbContextFactory é uma classe utilizada no projeto com a função de ler as configurações do projeto API e gerar um builder do DbContext do projeto:

![image](https://user-images.githubusercontent.com/89602176/195969767-8389e6bf-d80c-4f22-ad95-566320488ca6.png)

<br>

#### Classe BaseDomainMap
As classes de mapeamento das entidades herdam da classe `BaseDomainMap`, que por sua vez implementa a interface `IEntityTypeConfiguration<T>`, que recebe um tipo e tem um método chamado `Configure` para mapear as propriedades deste tipo recebido para o contexto do banco de dados. No método `Configure` já são mapeados dados padrão de todas as entidades, como o nome da tabela, `id` e `criado em`

![image](https://user-images.githubusercontent.com/89602176/195501188-527ebd91-aac8-4e5d-9a78-53b9676b3132.png)

<br>

#### Exemplo de classe herdando a classe de mapeamento:

![image](https://user-images.githubusercontent.com/89602176/195500873-4cf2c714-617d-4dfe-9245-a06eeadfa258.png)

<br>

#### Classe BaseRepository
A classe `BaseRepository` é a classe mâe de todas as classes que acessam diretamente o `dbContext` da aplicação, que recebe o `dbContext` da aplicação, e a torna disponível para todos as classes filhas.
![image](https://user-images.githubusercontent.com/89602176/200097213-6d452cb6-8f02-4708-af8a-124ed789221d.png)

<br>

#### Exemplo de função na `PedidoRepository` utilizando o `dbContext`
![image](https://user-images.githubusercontent.com/89602176/200097232-b455fdc2-3393-4f1d-89e9-7821733eea19.png)

<br>
<br>
 
[Curso Udemy](https://www.udemy.com/course/rock-dot-net-entity-framework/)

