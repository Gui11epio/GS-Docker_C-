FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN adduser -D appuser
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Fase de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GS-Docker_C-.csproj", "."]
RUN dotnet restore "GS-Docker_C-.csproj"
COPY . .
RUN dotnet build "GS-Docker_C-.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Fase de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GS-Docker_C-.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Fase final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER appuser
ENTRYPOINT ["dotnet", "GS-Docker_C-.dll"]
