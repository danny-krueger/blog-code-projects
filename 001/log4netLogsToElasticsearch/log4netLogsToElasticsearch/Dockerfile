#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY log4netLogsToElasticsearch/log4netLogsToElasticsearch.csproj log4netLogsToElasticsearch/
RUN dotnet restore "log4netLogsToElasticsearch/log4netLogsToElasticsearch.csproj"
COPY . .
WORKDIR "/src/log4netLogsToElasticsearch"
RUN dotnet build "log4netLogsToElasticsearch.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "log4netLogsToElasticsearch.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "log4netLogsToElasticsearch.dll"]
