FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

COPY *.sln .
COPY . .
WORKDIR /app/src/MemoryExpress.Web

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/src/MemoryExpress.Web/out ./
#COPY --from=build /app/src/MemoryExpress.Web/entrypoint.prod.sh ./

CMD ASPNETCORE_URLS=http://*:$PORT dotnet MemoryExpress.Web.dll
# RUN chmod +x ./entrypoint.prod.sh
# CMD /bin/bash -c "source ./entrypoint.prod.sh && dotnet MemoryExpress.Web.dll"