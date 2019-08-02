#!/bin/bash

set -e
run_cmd="dotnet watch -p MemoryExpress.Web.csproj run"

>&2 echo "DB is starting up"
until dotnet ef database update -p ../MemoryExpress.Infrastructure/MemoryExpress.Infrastructure.csproj -s ./MemoryExpress.Web.csproj;
do
sleep 1
done

>&2 echo "DB is up - executing command"
exec $run_cmd