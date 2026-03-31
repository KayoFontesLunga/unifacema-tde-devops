# Estágio de Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# COPIAR O PROJETO (Ajustado para a pasta atual)
# Como você já está na pasta do projeto, copiamos o .csproj diretamente
COPY ["unifacema-tde-devops.csproj", "./"]
RUN dotnet restore "unifacema-tde-devops.csproj"

# COPIAR TUDO E COMPILAR
COPY . .
RUN dotnet build "unifacema-tde-devops.csproj" -c $BUILD_CONFIGURATION -o /app/build

# PUBLICAR
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "unifacema-tde-devops.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# FINAL
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "unifacema-tde-devops.dll"]