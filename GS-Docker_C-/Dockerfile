# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
#Cria Usario não root
RUN adduser -D appuser
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY GS-Docker_C-/GS-Docker_C-.csproj GS-Docker_C-/
RUN dotnet restore "GS-Docker_C-/GS-Docker_C-.csproj"
COPY GS-Docker_C-/ GS-Docker_C-/
WORKDIR /src/GS-Docker_C-
RUN dotnet build "GS-Docker_C-.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GS-Docker_C-.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#Usa o usuario não root
USER appuser
ENTRYPOINT ["dotnet", "GS-Docker_C-.dll"]
