

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

COPY Services/Comment/MicroServiceShop.Comment.WebAPI/MicroServiceShop.Comment.WebAPI.csproj Services/Comment/MicroServiceShop.Comment.WebAPI/
COPY Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj Core/MicroServiceShop.Core/
RUN dotnet restore Services/Comment/MicroServiceShop.Comment.WebAPI/MicroServiceShop.Comment.WebAPI.csproj
COPY . .

RUN dotnet publish Services/Comment/MicroServiceShop.Comment.WebAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MicroServiceShop.Comment.WebAPI.dll"]





