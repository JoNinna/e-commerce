#!/bin/bash
set -e

# Apply migrations
dotnet ef database update --no-build

# Start the application
dotnet DoorDash.dll
