# syntax=docker/dockerfile:1

# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# PORT will be set by Render at runtime
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["MoviesBackend/MoviesBackend.csproj", "MoviesBackend/"]
RUN dotnet restore "MoviesBackend/MoviesBackend.csproj"

# Copy everything and publish
COPY MoviesBackend/ MoviesBackend/
WORKDIR "/src/MoviesBackend"
RUN dotnet publish "MoviesBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Connection string is provided via environment variable:
#   ConnectionStrings__DefaultConnection="Host=...;Port=5432;Database=...;Username=...;Password=..."
# On Render, this is set automatically when you link a PostgreSQL database.

ENTRYPOINT ["dotnet", "MoviesBackend.dll"]

