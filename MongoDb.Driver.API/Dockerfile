FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["MongoDb.Driver.API/MongoDb.Driver.API.csproj", "MongoDb.Driver.API/MongoDb.Driver.API/"]
COPY ["MongoDb.Driver.Core/MongoDb.Driver.Core.csproj", "MongoDb.Driver.Core/MongoDb.Driver.Core/"]
COPY ["MongoDb.Driver.Infrastructure/MongoDb.Driver.Infrastructure.csproj", "MongoDb.Driver.Infrastructure/MongoDb.Driver.Infrastructure/"]
COPY ["MongoDb.Driver.Shared/MongoDb.Driver.Shared.csproj", "MongoDb.Driver.Shared/MongoDb.Driver.Shared/"]

RUN dotnet restore "./MongoDb.Driver.API/MongoDb.Driver.API/MongoDb.Driver.API.csproj"

COPY . MongoDb.Driver.API/

WORKDIR "/src/MongoDb.Driver.API/MongoDb.Driver.API"

RUN dotnet build "./MongoDb.Driver.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MongoDb.Driver.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MongoDb.Driver.API.dll"]