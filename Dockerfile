# Use a imagem oficial do .NET Runtime como base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use a imagem oficial do .NET SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie o arquivo de projeto e restaure dependências
COPY ["ApiScp/ApiScp.csproj", "ApiScp/"]
RUN dotnet restore "ApiScp/ApiScp.csproj"

# Copie todo o código-fonte e compile a aplicação
COPY . .
WORKDIR "/src/ApiScp"
RUN dotnet build "ApiScp.csproj" -c Release -o /app/build

# Publique a aplicação
FROM build AS publish
RUN dotnet publish "ApiScp.csproj" -c Release -o /app/publish

# Use a imagem base para rodar a aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiScp.dll"]
