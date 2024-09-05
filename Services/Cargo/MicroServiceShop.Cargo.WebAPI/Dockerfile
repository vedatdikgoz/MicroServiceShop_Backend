

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Services/Cargo/MicroServiceShop.Cargo.WebAPI/MicroServiceShop.Cargo.WebAPI.csproj Services/Cargo/MicroServiceShop.Cargo.WebAPI/
COPY Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj Core/MicroServiceShop.Core/
RUN dotnet restore Services/Cargo/MicroServiceShop.Cargo.WebAPI/MicroServiceShop.Cargo.WebAPI.csproj
COPY . .

RUN dotnet publish Services/Cargo/MicroServiceShop.Cargo.WebAPI/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MicroServiceShop.Cargo.WebAPI.dll"]
