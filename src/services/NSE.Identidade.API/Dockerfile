#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 4001
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

RUN dotnet tool install --ignore-failed-sources --global dotnet-ef

WORKDIR /src
COPY ["src/services/NSE.Identidade.API/NSE.Identidade.API.csproj", "src/services/NSE.Identidade.API/"]
RUN dotnet restore "src/services/NSE.Identidade.API/NSE.Identidade.API.csproj" 

COPY . .

RUN ls
RUN ls src/services/NSE.Identidade.API/

WORKDIR "/src/src/services/NSE.Identidade.API/"
RUN dotnet build "NSE.Identidade.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Identidade.API.csproj" -c Release -o /app/publish

ENV PATH="${PATH}:/root/.dotnet/tools"



FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

COPY --from=build ./src/src/services/NSE.Identidade.API/docker-entrypoint.sh .

WORKDIR /app

RUN chmod +x ./docker-entrypoint.sh

ENTRYPOINT ["dotnet", "NSE.Identidade.API.dll"]
