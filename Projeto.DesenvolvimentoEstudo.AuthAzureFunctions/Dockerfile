FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
WORKDIR /src/Projeto.DesenvolvimentoEstudo.AuthAzureFunctions
RUN dotnet publish Projeto.DesenvolvimentoEstudo.APIAuthAzureFunctions.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/azure-functions/dotnet:4
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*
WORKDIR /home/site/wwwroot
COPY --from=build /app/publish/ ./
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true