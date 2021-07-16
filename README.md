<h1 align="center">ShowMeTheCode</h1> 

<p align="center">Projeto de cálculo de juros compostos.</p> 


### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [.net 5](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Moq](https://github.com/Moq/moq4/wiki/Quickstart)
- [Refit](https://github.com/reactiveui/refit)
- [Swagger](https://swagger.io/)
- [Xunit](https://xunit.net/)
- [Docker](https://www.docker.com/)



### Clone este repositório
$ git clone <https://github.com/shaippinho/ShowMeTheCode.git>

#### Acesse a pasta do projeto no terminal/cmd
$ cd ShowMeTheCode

#### Instale as dependências
$ dotnet restore

## Para execução no Docker

#### Crie a rede de comunicação dos containers
$ docker network create rederefit

#### Para criar a imagem da API de Taxa de Juros
$ docker build -f SMTC.API.TaxaJuros/Dockerfile -t taxajuros:1.0 .

#### Execução da API de Taxa de Juros
$ docker container run --name TaxaJuros -p 5010:80 -d --network rederefit taxajuros:1.0
#### O servidor inciará na porta:5010 - acesse <http://localhost:5010/swagger> 

#### Para criar a imagem da API de Cálculo
$ docker build -f SMTC.API.CalculaJuros/Dockerfile -t calculajuros:1.0 .

#### Execução da API de Cálculo
$ docker container run --name CalculaJuros -p 5000:80 -d --network rederefit calculajuros:1.0
#### O servidor inciará na porta:5000 - acesse <http://localhost:5000/swagger> 
