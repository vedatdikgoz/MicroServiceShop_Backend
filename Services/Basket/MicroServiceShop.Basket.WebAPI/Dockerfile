
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

COPY Services/Basket/MicroServiceShop.Basket.WebAPI/MicroServiceShop.Basket.WebAPI.csproj Services/Basket/MicroServiceShop.Basket.WebAPI/
COPY Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj Core/MicroServiceShop.Core/
RUN dotnet restore Services/Basket/MicroServiceShop.Basket.WebAPI/MicroServiceShop.Basket.WebAPI.csproj
COPY . .
RUN dotnet publish Services/Basket/MicroServiceShop.Basket.WebAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MicroServiceShop.Basket.WebAPI.dll"]
