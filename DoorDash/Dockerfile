# Use the official ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5074

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "DoorDash.csproj"
RUN dotnet build "DoorDash.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "DoorDash.csproj" -c Release -o /app/publish

# Final stage: Use the base image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apt-get update && apt-get install -y curl
ENTRYPOINT ["dotnet", "DoorDash.dll"]

