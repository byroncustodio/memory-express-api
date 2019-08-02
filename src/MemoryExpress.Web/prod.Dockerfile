FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

COPY *.sln .
COPY . .
WORKDIR /app/src/MemoryExpress.Web

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/src/MemoryExpress.Web/out ./

CMD ASPNETCORE_URLS=http://*:$PORT dotnet MemoryExpress.Web.dll