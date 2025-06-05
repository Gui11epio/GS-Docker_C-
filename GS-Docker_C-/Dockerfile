FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN adduser -D appuser
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GS-Docker_C-/GS-Docker_C-.csproj", "GS-Docker_C-/"]
RUN dotnet restore "./GS-Docker_C-/GS-Docker_C-.csproj"
COPY . .
WORKDIR "/src/GS-Docker_C-"
RUN dotnet build "./GS-Docker_C-.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GS-Docker_C-.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER appuser
ENTRYPOINT ["dotnet", "GS-Docker_C-.dll"]