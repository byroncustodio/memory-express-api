#!/bin/bash

set -e
run_cmd="dotnet watch -p MemoryExpress.Web.csproj run"

if [[ "$1" = "Production" ]]; then
    run_cmd="dotnet run -p MemoryExpress.Web.csproj"
fi

>&2 echo "DB is starting up"
until dotnet ef database update -p ../MemoryExpress.Infrastructure/MemoryExpress.Infrastructure.csproj -s ./MemoryExpress.Web.csproj;
do
sleep 1
done

>&2 echo "DB is up - executing command"
exec $run_cmd