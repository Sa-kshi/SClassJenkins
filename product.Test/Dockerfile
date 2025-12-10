# Base runtime image
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src

# Copy csproj and restore
COPY ["product.Test/product.Test.csproj", "product.Test/"]
RUN dotnet restore "product.Test/product.Test.csproj"

# Copy source code
COPY product.Test/. ./product.Test

# Build project
RUN dotnet build "product.Test/product.Test.csproj" -c $configuration -o /app/build

# Optional: Publish if needed
RUN dotnet publish "product.Test/product.Test.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Final image (optional)
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "product.Test.dll"]