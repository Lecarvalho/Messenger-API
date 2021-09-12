# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MessengerApi.Business/*.csproj ./MessengerApi.Business/
COPY MessengerApi.DAL/*.csproj ./MessengerApi.DAL/
COPY MessengerApi.Services/*.csproj ./MessengerApi.Services/
COPY MessengerApi.Webapi/*.csproj ./MessengerApi.Webapi/
RUN dotnet restore

# copy everything else and build app
COPY MessengerApi.Business/. ./MessengerApi.Business/
COPY MessengerApi.DAL/. ./MessengerApi.DAL/
COPY MessengerApi.Services/. ./MessengerApi.Services/
COPY MessengerApi.Webapi/. ./MessengerApi.Webapi/
WORKDIR /app/MessengerApi.Webapi
RUN dotnet publish -c release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/MessengerApi.Webapi/out ./
ENTRYPOINT ["dotnet", "MessengerApi.Webapi.dll"]