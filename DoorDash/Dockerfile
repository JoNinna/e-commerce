# Use the official ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
EXPOSE 5074

COPY . .
RUN dotnet restore DoorDash.csproj
RUN dotnet tool install --global dotnet-ef  
RUN export PATH="${PATH}:/root/.dotnet/tools"  
RUN dotnet publish -c Release -o /app/publish

# Final stage: Use the base image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
WORKDIR /app
COPY --from=base /app/publish .
ENTRYPOINT ["dotnet", "DoorDash.dll"]
