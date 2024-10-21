# Use the .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY WorkerApp/WorkerApp.csproj WorkerApp/
RUN dotnet restore WorkerApp/WorkerApp.csproj

# Copy the rest of the application code
COPY WorkerApp/. ./WorkerApp/
WORKDIR /src/WorkerApp
RUN dotnet publish -c Release -o /app/publish

# Use the .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WorkerApp.dll"]
