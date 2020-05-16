#!/usr/bin/sh

# drop database specified in project
dotnet-sdk.dotnet dotnet-ef database drop

# drop backup migrations
dotnet-sdk.dotnet dotnet-ef migrations remove

# recreate project migrations
dotnet-sdk.dotnet dotnet-ef migrations add DesafioDotNetCoreBackEnd.Models.CadastroDbContext

# apply migrations to database
dotnet-sdk.dotnet dotnet-ef database update

# generate new controllers based on entity classes from project
dotnet-sdk.dotnet dotnet-aspnet-codegenerator controller -name PessoasController -m Pessoa -dc CadastroDbContext --relativeFolderPath Controllers -api
