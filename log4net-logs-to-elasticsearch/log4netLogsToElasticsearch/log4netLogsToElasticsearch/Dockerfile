#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base

#supervisor is being used to run multiple processes in the same container
RUN apt-get update && apt-get install -y supervisor
RUN mkdir -p /var/log/supervisord

# Install Filebeat
RUN apt-get update
RUN apt-get install -y wget
RUN apt-get install -y gnupg2
RUN wget -qO - https://artifacts.elastic.co/GPG-KEY-elasticsearch | apt-key add -
RUN echo "deb https://artifacts.elastic.co/packages/7.x/apt stable main" | tee -a /etc/apt/sources.list.d/elastic-7.x.list
RUN apt-get install apt-transport-https
RUN apt-get update && apt-get install filebeat

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

# Copy configs into Docker
COPY log4netLogsToElasticsearch/filebeat.yml /etc/filebeat/filebeat.yml
COPY log4netLogsToElasticsearch/supervisord.conf /etc/supervisor/conf.d/supervisord.conf

COPY --from=publish /app/publish .

ENTRYPOINT ["/usr/bin/supervisord", "-c", "/etc/supervisor/conf.d/supervisord.conf"]
