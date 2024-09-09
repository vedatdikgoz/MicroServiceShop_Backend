#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Comment/MicroServiceShop.Comment.WebAPI/MicroServiceShop.Comment.WebAPI.csproj", "Services/Comment/MicroServiceShop.Comment.WebAPI/"]
COPY ["Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj", "Core/MicroServiceShop.Core/"]
RUN dotnet restore "./Services/Comment/MicroServiceShop.Comment.WebAPI/MicroServiceShop.Comment.WebAPI.csproj"
COPY . .
WORKDIR "/src/Services/Comment/MicroServiceShop.Comment.WebAPI"
RUN dotnet build "./MicroServiceShop.Comment.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MicroServiceShop.Comment.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroServiceShop.Comment.WebAPI.dll"]