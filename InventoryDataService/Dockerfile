# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 1. Создаем и переходим в рабочую директорию
WORKDIR /src

# 2. Копируем ТОЛЬКО файлы проектов (для кэширования)
COPY ["InventoryDataService/InventoryDataService.csproj", "InventoryDataService/"]

# 3. Восстанавливаем зависимости
RUN dotnet restore "InventoryDataService/InventoryDataService.csproj"

# 4. Копируем ВЕСЬ остальной код
COPY . .

# 5. Собираем проект
WORKDIR "/src/InventoryDataService"
RUN dotnet build "InventoryDataService.csproj" -c Release -o /app/build

# Этап публикации
FROM build AS publish
RUN dotnet publish "InventoryDataService.csproj" -c Release -o /app/publish

# Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Копируем только необходимые файлы из этапа publish
COPY --from=publish /app/publish .

# Точка входа
ENTRYPOINT ["dotnet", "InventoryDataService.dll"]