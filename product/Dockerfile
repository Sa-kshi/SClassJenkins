# Base runtime image
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
WORKDIR /app

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src

# Copy csproj and restore
COPY ["product/product.csproj", "product/"]
RUN dotnet restore "product/product.csproj"

# Copy source code
COPY product/. ./product

# Build project
RUN dotnet build "product/product.csproj" -c $configuration -o /app/build

# Publish stage
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "product/product.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "product.dll"]
