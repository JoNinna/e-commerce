#!/bin/bash

# Install dotnet-ef tool if it's not already installed
echo "Installing dotnet-ef tool..."
dotnet tool install --global dotnet-ef

# Update PATH to include .NET tools
export PATH="$PATH:/root/.dotnet/tools"

# Apply migrations on container start
echo "Running database migrations..."
dotnet ef database update --no-build

# Execute the original command
exec "$@"
