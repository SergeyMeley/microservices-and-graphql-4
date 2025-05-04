# Stage 1: Restore
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
WORKDIR /src

# Copy project files
COPY InventoryService/InventoryService.csproj ./InventoryService/
RUN dotnet restore ./InventoryService/InventoryService.csproj \
    --runtime linux-x64

# Stage 2: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy from restore stage
COPY --from=restore /src .
COPY --from=restore /root/.nuget /root/.nuget

# Copy source code
COPY InventoryService ./InventoryService/

# Publish
WORKDIR /src/InventoryService
RUN dotnet publish -c Release -o /app/publish \
    --no-restore \
    -p:UseAppHost=false

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
COPY InventoryService/appsettings.json .
ENTRYPOINT ["dotnet", "InventoryService.dll"]