
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

COPY Gateway/MicroServiceShop.Gateway/MicroServiceShop.Gateway.csproj Gateway/MicroServiceShop.Gateway/
RUN dotnet restore Gateway/MicroServiceShop.Gateway/MicroServiceShop.Gateway.csproj
COPY . .

RUN dotnet publish Gateway/MicroServiceShop.Gateway/MicroServiceShop.Gateway.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MicroServiceShop.Gateway.dll"]