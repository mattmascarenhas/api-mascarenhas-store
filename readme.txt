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
PM> NuGet\Install-Package FluentValidation -Version 2.0.2