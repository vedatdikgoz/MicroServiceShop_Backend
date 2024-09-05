
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

COPY Services/Message/MicroServiceShop.Message.WebAPI/MicroServiceShop.Message.WebAPI.csproj Services/Message/MicroServiceShop.Message.WebAPI/
COPY Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj Core/MicroServiceShop.Core/
RUN dotnet restore Services/Message/MicroServiceShop.Message.WebAPI/MicroServiceShop.Message.WebAPI.csproj
COPY . .

RUN dotnet publish Services/Message/MicroServiceShop.Message.WebAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MicroServiceShop.Message.WebAPI.dll"]
