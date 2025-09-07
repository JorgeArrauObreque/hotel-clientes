# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia csproj y restaura paquetes
COPY *.csproj ./
RUN dotnet restore

# Copia el resto del código
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Puerto expuesto (ajústalo si usas otro)
EXPOSE 8080

ENTRYPOINT ["dotnet", "hotel-clientes.dll"]