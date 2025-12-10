# Base runtime image
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
WORKDIR /app

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src

# Copy csproj and restore (no 'product/' prefix)
COPY product.csproj ./
RUN dotnet restore "product.csproj"

# Copy all source code
COPY . ./

# Build project
RUN dotnet build "product.csproj" -c $configuration -o /app/build

# Publish stage
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "product.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "product.dll"]
