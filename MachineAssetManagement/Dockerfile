# Step 1: Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy csproj and restore
COPY . ./
RUN dotnet restore

# Copy everything else

RUN dotnet publish -c Release -o /app/publish

# Step 2: Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

EXPOSE 8080
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MachineAssetManagement.dll"]
