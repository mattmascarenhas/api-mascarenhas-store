//IMPORTANTE
***Lá pro final da aplicação, ao fazer os testes, deve-se usar abstração, pois iremos testar sem o uso de banco de dados***
***O folder.shared compartilha algumas interfaces comum entre todos, ajudando na abstração e facilitando os testes***
***Iremos usar interfaces ao invés de implementar, assim definiremos apenas a regra***

//criacao das pastas da api, essa a maneira mais organizada

	folder.api -> dotnet new web
	folder.domain -> dotnet new classlib
	folder.infra -> dotnet new classlib
	folder.shared -> dotnet new classlib
	folder.tests -> dotnet new mstest


//na pasta raiz
//precisa inicar o sln para poder trabalhar no visual studio

	folder -> dotnet new sln


//adicionar as pastas da pasta raiz no projeto
//dica apertar TAB para autocompletar o nome da pasta

	folder -> dotnet sln add .\MascarenhasStore.Api\MascarenhasStore.Api.csproj
		 -> dotnet sln add MascarenhasStore.Domain\MascarenhasStore.Domain.csproj
	 	 -> dotnet sln add MascarenhasStore.Infra\MascarenhasStore.Infra.csproj
		 -> dotnet sln add MascarenhasStore.Shared\MascarenhasStore.Shared.csproj
		 -> dotnet sln add MascarenhasStore.Tests\MascarenhasStore.Tests.csproj


//depois do projeto aberto no visual studio usar o seguinte comando

	 -> dotnet restore


//entrar na pasta de tests e adicionar o Domain como referencia

	folder.tests -> dotnet add reference ..\MascarenhasStore.Domain\MascarenhasStore.Domain.csproj


//instalar o pacote de validacao
//IMPORTANTE -> INSTALAR NO folder.Domaim
//ele adiciona as notificacoes

	PM> NuGet\Install-Package FluentValidator -Version 2.0.2
		ou	
	dotnet add package FluentValidator --version 2.0.2

//instalar tambem o fluent validator na api

	PM> NuGet\Install-Package FluentValidator -Version 2.0.2
		ou	
	dotnet add package FluentValidator --version 2.0.2


//referenciar o que for utilizado no domain
	
	folder.domain -> dotnet add reference ..\MascarenhasStore.Domain\MascarenhasStore.Shared.csproj

	
//referenciar o que for utlizador na api

	folder.api -> dotnet add reference ..\MascarenhasStore.Domain\MascarenhasStore.Shared.csproj
	folder.api -> dotnet add reference ..\MascarenhasStore.Domain\MascarenhasStore.Domain.csproj
	folder.api -> dotnet add reference ..\MascarenhasStore.Infra\MascarenhasStore.Infra.csproj


// ir em folder.infra e instalar o dapper, pois é la que vamos interagir com o Banco de dados
	
	folder.infra -> dotnet add package Dapper

//na api instalar o Microsoft.AspNetCore na api

	folder.api -> dotnet add package Microsoft.AspNetCore

