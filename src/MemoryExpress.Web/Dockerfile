FROM microsoft/dotnet:2.2-sdk AS base
LABEL stage=intermediate
WORKDIR /app

COPY *.sln .
COPY . .

WORKDIR /app/src/MemoryExpress.Web

RUN dotnet publish -c Release -o out


# Build for dev environment
FROM base AS dev
WORKDIR /app/src/MemoryExpress.Web

# RUN dotnet ef database update -p ../MemoryExpress.Infrastructure/MemoryExpress.Infrastructure.csproj -s ./MemoryExpress.Web.csproj

CMD ["/bin/bash", "-c", "dotnet watch run"]

# RUN if [ "$ASPNETCORE_ENVIRONMENT" = "Development" ]; then \
#         echo "Db starting up" && \
#         # dotnet ef database update -p ../MemoryExpress.Infrastructure/MemoryExpress.Infrastructure.csproj -s ./MemoryExpress.Web.csproj && \
#         echo "Db updated" && \
#         dotnet watch run; \
#     fi


# Build for prod environment
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS prod
WORKDIR /app
COPY --from=base /app/src/MemoryExpress.Web/out ./

ENTRYPOINT ["dotnet", "MemoryExpress.Web.dll"]

# Set permissions for entrypoint.sh
# RUN sed -i 's/\r//' ./entrypoint.sh && chmod +x ./entrypoint.sh
# CMD /app/src/MemoryExpress.Web/entrypoint.sh ${ASPNETCORE_ENVIRONMENT}