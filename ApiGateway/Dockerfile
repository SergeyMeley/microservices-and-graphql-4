# Stage 1: Restore (только ApiGateway)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
WORKDIR /src

# Копируем ТОЛЬКО нужные .csproj файлы
COPY ["ApiGateway/ApiGateway.csproj", "./ApiGateway/"]
RUN dotnet restore "ApiGateway/ApiGateway.csproj" \
    --runtime linux-x64 \
    --verbosity normal \
    --no-dependencies

# Stage 2: Publish (изолированная сборка)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /src

# Копируем восстановленные зависимости
COPY --from=restore /src .
COPY --from=restore /root/.nuget /root/.nuget

# Копируем ТОЛЬКО файлы ApiGateway
COPY ["ApiGateway/", "./ApiGateway/"]

# Публикация с явными параметрами
WORKDIR "/src/ApiGateway"
RUN dotnet publish "ApiGateway.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore \
    -p:UseAppHost=false \
    -p:ErrorOnDuplicatePublishOutputFiles=false \
    /p:ValidateProjects=false

# Stage 3: Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["ApiGateway/ocelot.json", "./"]
ENTRYPOINT ["dotnet", "ApiGateway.dll"]