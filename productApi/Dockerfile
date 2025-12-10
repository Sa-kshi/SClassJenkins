FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src

COPY ["productApi/productApi.csproj", "productApi/"]
RUN dotnet restore "productApi/productApi.csproj"

COPY productApi/. ./productApi
RUN dotnet build "productApi/productApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "productApi/productApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "productApi.dll"]
