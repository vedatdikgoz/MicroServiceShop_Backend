FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

COPY Services/PhotoStock/MicroServiceShop.PhotoStock.WebAPI/MicroServiceShop.PhotoStock.WebAPI.csproj Services/PhotoStock/MicroServiceShop.PhotoStock.WebAPI/
COPY Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj Core/MicroServiceShop.Core/
RUN dotnet restore Services/PhotoStock/MicroServiceShop.PhotoStock.WebAPI/MicroServiceShop.PhotoStock.WebAPI.csproj
COPY . .

RUN dotnet publish Services/PhotoStock/MicroServiceShop.PhotoStock.WebAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MicroServiceShop.PhotoStock.WebAPI.dll"]