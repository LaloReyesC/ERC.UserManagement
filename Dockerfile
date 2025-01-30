FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

EXPOSE 80
EXPOSE 443

COPY ["ERC.UserManagement.API/ERC.UserManagement.API.csproj", "ERC.UserManagement.API/"]
COPY ["ERC.UserManagement.Core/ERC.UserManagement.Core.csproj", "ERC.UserManagement.Core/"]
COPY ["ERC.UserManagement.Application/ERC.UserManagement.Application.csproj", "ERC.UserManagement.Application/"]
COPY ["ERC.UserManagement.Infrastructure/ERC.UserManagement.Infrastructure.csproj", "ERC.UserManagement.Infrastructure/"]
RUN dotnet restore ERC.UserManagement.API/ERC.UserManagement.API.csproj

COPY . ./
RUN dotnet publish ERC.UserManagement.API/ERC.UserManagement.API.csproj -c Release -o out

FROM  mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "ERC.UserManagement.API.dll" ]