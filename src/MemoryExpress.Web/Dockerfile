FROM microsoft/dotnet:2.2-sdk AS base
WORKDIR /app

COPY *.sln .
COPY . .
WORKDIR /app/src/MemoryExpress.Web

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh ${ASPNETCORE_ENVIRONMENT}

# RUN dotnet publish -c Release -o out


# Build for prod environment
# FROM microsoft/dotnet:2.2-aspnetcore-runtime AS prod
# WORKDIR /app
# COPY --from=base /app/src/MemoryExpress.Web/out ./

# ENTRYPOINT ["dotnet", "MemoryExpress.Web.dll"]