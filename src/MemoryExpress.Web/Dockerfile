FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

COPY *.sln .
COPY . .
WORKDIR /app/src/MemoryExpress.Web

RUN chmod +x ./entrypoint.sh
RUN sed -i 's/\r$//' ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh