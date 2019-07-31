#!/bin/bash

set -e
echo "Test"
echo $1
#dotnet restore

# until dotnet ef database update -p ../MemoryExpress.Infrastructure/MemoryExpress.Infrastructure.csproj -s ./MemoryExpress.Web.csproj; do
# >&2 echo "DB is starting up"
# sleep 1
# done

#>&2 echo "DB is up - executing command"
#exec $run_cmd

if [[ "$1" = "Development" ]]; then
    echo "Dev"
    dotnet watch -p MemoryExpress.Web.csproj run
fi

if [[ "$1" = "Production" ]]; then
    echo "Prod"
    dotnet MemoryExpress.Web.dll 
fi