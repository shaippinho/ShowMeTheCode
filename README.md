<h1 align="center">ShowMeTheCode</h1> 
<h4 align="center"> 
	🚧  Projeto em construção...  🚧
</h4>

Inicialmente este projeto foi construído a partir de um processo seletivo para construção de **microsserviços**, utilizando .NET 5.

Após a prova, o objetivo deste projeto passou para, criação de um template de projeto, com todos os recursos que utilizei nos últimos meses.

### 👉 No que se baseia

Cálculo de juros compostos. A aplicação utilizará dois microsserviços. O primeiro irá fornecer a taxa de juros, e o segundo irá consumir o primeiro para calcular o valor final, levando em consideração o os dados fornecidos pelo usuário.

### 🛠 Tecnologias utilizadas

As seguintes ferramentas foram usadas na construção do projeto:

- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Moq](https://github.com/Moq/moq4/wiki/Quickstart)
- [Refit](https://github.com/reactiveui/refit)
- [Swagger](https://swagger.io/)
- [xUnit](https://xunit.net/)
- [Docker](https://www.docker.com/)
- [MediatR](https://github.com/jbogard/MediatR)
- [CQRS](https://martinfowler.com/bliki/CQRS.html)
- [Fluent Validation](https://fluentvalidation.net/)

### 👉 Baixe o código

#### Clone este repositório
$ git clone <https://github.com/shaippinho/ShowMeTheCode.git>

#### Acesse a pasta do projeto no terminal/cmd
```
$ cd ShowMeTheCode
```

#### Instale as dependências
```
$ dotnet restore
```

### 👉 Para execução no Docker

#### Crie a rede de comunicação dos containers
```
$ docker network create --subnet=172.18.0.0/16 rederefit
```

#### Para criar a imagem da API de Taxa de Juros
```
$ docker build -f SMTC.API.TaxaJuros/Dockerfile -t taxajuros:1.0 .
```

#### Execução da API de Taxa de Juros
```
$ docker container run --name TaxaJuros -p 5010:5010 -d --network rederefit --ip 172.18.0.4 taxajuros:1.0
```
#### O servidor inciará na porta:5010 - acesse <http://localhost:5010/swagger> 

#### Para criar a imagem da API de Cálculo
```
$ docker build -f SMTC.API.CalculaJuros/Dockerfile -t calculajuros:1.0 .
```
#### Execução da API de Cálculo
```
$ docker container run --name CalculaJuros -p 5000:5000 -d --network rederefit --ip 172.18.0.5 calculajuros:1.0
```

#### O servidor inciará na porta:5000 - acesse <http://localhost:5000/swagger> 
