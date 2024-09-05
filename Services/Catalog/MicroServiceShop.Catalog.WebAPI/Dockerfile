#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

COPY Services/Catalog/MicroServiceShop.Catalog.WebAPI/MicroServiceShop.Catalog.WebAPI.csproj Services/Catalog/MicroServiceShop.Catalog.WebAPI/
COPY Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj Core/MicroServiceShop.Core/
RUN dotnet restore Services/Catalog/MicroServiceShop.Catalog.WebAPI/MicroServiceShop.Catalog.WebAPI.csproj
COPY . .

RUN dotnet publish Services/Catalog/MicroServiceShop.Catalog.WebAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MicroServiceShop.Catalog.WebAPI.dll"]


