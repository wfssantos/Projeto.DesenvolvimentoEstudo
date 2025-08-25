# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Projeto.DesenvolvimentoEstudo.WebAPI/Projeto.DesenvolvimentoEstudo.WebAPI.csproj", "Projeto.DesenvolvimentoEstudo.WebAPI/"]
COPY ["Projeto.DesenvolvimentoEstudo.IoC/Projeto.DesenvolvimentoEstudo.IoC.csproj", "Projeto.DesenvolvimentoEstudo.IoC/"]
COPY ["Projeto.DesenvolvimentoEstudo.Application/Projeto.DesenvolvimentoEstudo.Application.csproj", "Projeto.DesenvolvimentoEstudo.Application/"]
COPY ["Projeto.DesenvolvimentoEstudo.Domain/Projeto.DesenvolvimentoEstudo.Domain.csproj", "Projeto.DesenvolvimentoEstudo.Domain/"]
COPY ["Projeto.DesenvolvimentoEstudo.Common/Projeto.DesenvolvimentoEstudo.Common.csproj", "Projeto.DesenvolvimentoEstudo.Common/"]
COPY ["Projeto.DesenvolvimentoEstudo.ORM/Projeto.DesenvolvimentoEstudo.ORM.csproj", "Projeto.DesenvolvimentoEstudo.ORM/"]
RUN dotnet restore "./Projeto.DesenvolvimentoEstudo.WebAPI/Projeto.DesenvolvimentoEstudo.WebAPI.csproj"
COPY . .
WORKDIR "/src/Projeto.DesenvolvimentoEstudo.WebAPI"
RUN dotnet build "./Projeto.DesenvolvimentoEstudo.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Projeto.DesenvolvimentoEstudo.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Projeto.DesenvolvimentoEstudo.WebAPI.dll"]