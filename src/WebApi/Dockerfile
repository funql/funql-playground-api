# Use Microsoft's official build .NET image
# https://hub.docker.com/_/microsoft-dotnet-sdk
FROM mcr.microsoft.com/dotnet/sdk:9.0.304-alpine3.21 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY Directory.*.props /
COPY src/Directory.*.props src/
COPY src/WebApi/*.csproj src/WebApi/
COPY src/Application/*.csproj src/Application/
COPY src/Domain/*.csproj src/Domain/
COPY src/Infrastructure/*.csproj src/Infrastructure/
# Restore projects
RUN dotnet restore "src/WebApi/FunQL.Playground.WebApi.csproj"

# Copy all files for building
COPY src/WebApi/ src/WebApi/
COPY src/Application/ src/Application/
COPY src/Domain/ src/Domain/
COPY src/Infrastructure/ src/Infrastructure/
# Build projects
RUN dotnet build "src/WebApi/FunQL.Playground.WebApi.csproj" -c Release --no-restore

# Publish WebApi
FROM build AS publish
RUN dotnet publish "src/WebApi/FunQL.Playground.WebApi.csproj" -c Release -o /publish --no-build /p:UseAppHost=false

# Use Microsoft's official runtime .NET image
# https://hub.docker.com/_/microsoft-dotnet-aspnet
FROM mcr.microsoft.com/dotnet/aspnet:9.0.9-alpine3.21 AS runtime
WORKDIR /app
COPY --from=publish /publish ./

# Run the web service on container startup
ENTRYPOINT ["dotnet", "FunQL.Playground.WebApi.dll"]
