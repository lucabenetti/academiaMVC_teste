# Internacionalização

## O que é?

Internacionalização e localização, em informática, são processos de desenvolvimento e/ou adaptação de um produto, em geral softwares de computadores, para uma língua e cultura de um país.

## Já utilizamos?
No momento ainda não estamos implementando.

## Como nossa API pode lidar com isso?

O ASP.NET Core fornece serviços e middleware para localização em diferentes idiomas e culturas.

A localização de aplicativos envolve o seguinte:

1. Tornar o conteúdo do aplicativo localizável.
2. Fornecer recursos localizados para as culturas e os idiomas aos quais você dá suporte.
3. Implementar uma estratégia para selecionar o idioma e a cultura para cada solicitação.

## Como configurar o projeto para a internacionalização?

Criaremos no projeto um diretório chamado Resources. Dentro dele, criaremos um Resource File com o nome de Language.resx. Este será o arquivo base para a criação dos outros arquivos internacionalizados.

Continuaremos implementando o sistema sempre referenciando Resources.Language. Ao terminar, duplicaremos o arquivo Language.resx variando o sufixo antes da extensão de acordo com a cultura a qual ele se refere. Por exemplo:

```
Language.en.resx [](Inglês)
Language.es.resx [](Espanhol)
Language.pt-BR.resx [](Portugues do Brasil)
Language.jp.resx [](Japonês)
```

## Qual é o custo para a implementação?

Não é tanta, como configuraremos como mostrado acima, tudo funcionará dinâmicamente, e como todos os participantes do projeto possuiem um certo nível em inglês, 
bastaria tirar um tempo de umas 2h, para traduzir todas as string e textos de imagem mais o tempo de revisão, não precisariamos olhar código por código já que usaremos os Resources.

## Quais os impedimentos para a implementação?

Nenhum. Separaremos um tempo para fazer a implementação.