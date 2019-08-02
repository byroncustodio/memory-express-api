#!/bin/bash

set -e
ASPNETCORE_URLS=http://0.0.0.0:\$PORT
DOTNET_RUNNING_IN_CONTAINER=true

# >&2 echo "DB is starting up"
# until dotnet ef database update -p ../MemoryExpress.Infrastructure/MemoryExpress.Infrastructure.csproj -s ./MemoryExpress.Web.csproj;
# do
# sleep 1
# done

# >&2 echo "DB is up"