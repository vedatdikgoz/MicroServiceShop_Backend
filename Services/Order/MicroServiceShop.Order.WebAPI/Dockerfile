FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Services/Order/MicroServiceShop.Order.WebAPI/MicroServiceShop.Order.WebAPI.csproj Services/Order/MicroServiceShop.Order.WebAPI/
COPY Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj Core/MicroServiceShop.Core/
COPY Services/Order/MicroServiceShop.Order.Application/MicroServiceShop.Order.Application.csproj Services/Order/MicroServiceShop.Order.Application/
COPY Services/Order/MicroServiceShop.Order.Domain/MicroServiceShop.Order.Domain.csproj Services/Order/MicroServiceShop.Order.Domain/
COPY Services/Order/MicroServiceShop.Order.Infrastructure/MicroServiceShop.Order.Infrastructure.csproj Services/Order/MicroServiceShop.Order.Infrastructure/
RUN dotnet restore /Services/Order/MicroServiceShop.Order.WebAPI/MicroServiceShop.Order.WebAPI.csproj
COPY . .

RUN dotnet publish Services/Order/MicroServiceShop.Order.WebAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MicroServiceShop.Order.WebAPI.dll"]