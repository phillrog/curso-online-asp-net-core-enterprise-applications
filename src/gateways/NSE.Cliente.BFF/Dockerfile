#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 6000
EXPOSE 7000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/gateways/NSE.Cliente.BFF/NSE.Cliente.BFF.csproj", "src/gateways/NSE.Cliente.BFF/"]
RUN dotnet restore "src/gateways/NSE.Cliente.BFF/NSE.Cliente.BFF.csproj"
COPY . .
WORKDIR "/src/src/gateways/NSE.Cliente.BFF"
RUN dotnet build "NSE.Cliente.BFF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Cliente.BFF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Cliente.BFF.dll"]