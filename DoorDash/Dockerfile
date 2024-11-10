# Use the official ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/sdk:8.@sha256:35792ea4ad1db051981f62b313f1be3b46b1f45cadbaa3c288cd0d3056eefb83 AS base
WORKDIR /app
EXPOSE 5074

COPY . ./
RUN dotnet restore 
RUN dotnet tool install --global dotnet-ef  
RUN export PATH="${PATH}:/root/.dotnet/tools"  
RUN dotnet publish -c Release -o /app/publish

# Final stage: Use the base image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0@sha256:6c4df091e4e531bb93bdbfe7e7f0998e7ced344f54426b7e874116a3dc3233ff AS build
WORKDIR /app
COPY --from=base /app/publish .
ENTRYPOINT ["dotnet", "DoorDash.dll"]
