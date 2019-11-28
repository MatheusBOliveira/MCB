# MCB

### Devops

To see environments structures, conventions and devops process, see [this link.](devops/dockerEnvs.md)

### Globalization

To see globalization code conventions and messages, see  [this link.](docs/globalization/conventions.md)

<b>Este é um projeto de estudos, por isso, ainda está sendo implementado</b>
  
<b>Leia todo o arquivo para compreensão do projeto!</b>

# Este é um projeto de estudos!

O objetivo do projeto é construir um sistema baseado em MicroServices que aplica os conceitos de DDD, CQRS e Hexagonal Domain. Recomendo a leitura do artigo <b>DDD, Hexagonal, Onion, Clean, CQRS, … How I put it all together</b> (https://herbertograca.com/2017/11/16/explicit-architecture-01-ddd-hexagonal-onion-clean-cqrs-how-i-put-it-all-together/) para saber mais sobre Hexagonal Domain.

Por se tratar de um projeto de estudo, alguns conceitos foram implementados manualmente, mesmo que haja pacotes com a implementação pronta, pois o objetivo é fazer um estudo mais profundo dos conceitos.

Ao invés de realizar a implementação dos conceitos de forma individual e em um cenário mais simples, resolvi assumir um cenário de negócio real mais complexos.

# Cenário de Negócio

O cenário de negócio escolhido foi o desenvolvimento de um <b>SSO (Single Sing-On)</b> de alta disponibilidade, escabalidade e que possibilite um grande número de requisições.

Além disso, o projeto deve suportar o controle de autorização

![Alt text](TheBigPicture.png?raw=true "The Big Picture")

# Etapas para criação do projeto

1. Criação das camadas de infra estrutura
2. Criação do domínio
3. Criação das domain models
4. Criação dos diagramas de classes
5. Criação dos commands
6. Criação das queries
7. Criação dos command handlers
8. Criação dos query handlers
