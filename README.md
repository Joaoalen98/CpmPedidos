<br>

# CpmPedidos

Projeto em desenvolvimento para estudo do uso e implementação do Entity Framework Core com C#, seguindo as boas práticas de desenvolvimento.

<br>

## Descrição

O projeto constitui em um conjunto de outros projetos, separados cada um por função. 

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

### CpmPedidos.Repository

<br>

Esta biblioteca de classes tem a função de salvar o nosso contexto do banco de dados, e o mapeamento das nossas entidades.

<br>

#### DbContext do projeto
![image](https://user-images.githubusercontent.com/89602176/195498878-21c64f0d-186c-4dbc-897a-4f7dcaf8ec60.png)

<br>

#### Classe BaseDomainMap
As classes de mapeamento das entidades herdam da classe `BaseDomainMap`, que por sua vez implementa a interface `IEntityTypeConfiguration<T>`, que recebe um tipo e tem um método chamado `Configure` para mapear as propriedades deste tipo recebido para o contexto do banco de dados. No método `Configure` já são mapeados dados padrão de todas as entidades, como o nome da tabela, `id` e `criado em`
![image](https://user-images.githubusercontent.com/89602176/195501188-527ebd91-aac8-4e5d-9a78-53b9676b3132.png)

<br>

#### Exemplo de classe herdando a classe de mapeamento:

![image](https://user-images.githubusercontent.com/89602176/195500873-4cf2c714-617d-4dfe-9245-a06eeadfa258.png)

<br>

[Curso Udemy](https://www.udemy.com/course/rock-dot-net-entity-framework/)

