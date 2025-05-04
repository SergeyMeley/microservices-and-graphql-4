# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Копируем ТОЛЬКО файлы проектов (для кэширования)
COPY ["InventoryService/InventoryService.csproj", "InventoryService/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]

# 2. Восстанавливаем зависимости
RUN dotnet restore "InventoryService/InventoryService.csproj" \
    --runtime linux-x64 \
    --verbosity normal

# 3. Копируем ВЕСЬ остальной код
COPY . .

# 4. Собираем проект
WORKDIR "/src/InventoryService"
RUN dotnet build "InventoryService.csproj" -c Release -o /app/build \
    -p:ErrorOnDuplicatePublishOutputFiles=false

# Этап публикации
FROM build AS publish
WORKDIR "/src/InventoryService"
RUN dotnet publish "InventoryService.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore \
    -p:UseAppHost=false

# Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InventoryService.dll"]