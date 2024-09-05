
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

COPY Services/Discount/MicroServiceShop.Discount.WebAPI/MicroServiceShop.Discount.WebAPI.csproj Services/Discount/MicroServiceShop.Discount.WebAPI/
COPY Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj Core/MicroServiceShop.Core/
RUN dotnet restore Services/Discount/MicroServiceShop.Discount.WebAPI/MicroServiceShop.Discount.WebAPI.csproj
COPY . .

RUN dotnet publish Services/Discount/MicroServiceShop.Discount.WebAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MicroServiceShop.Discount.WebAPI.dll"]
