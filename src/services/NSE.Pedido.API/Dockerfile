#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 4005
EXPOSE 5005

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/services/NSE.Pedido.API/NSE.Pedido.API.csproj", "src/services/NSE.Pedido.API/"]
RUN dotnet restore "src/services/NSE.Pedido.API/NSE.Pedido.API.csproj"
COPY . .
WORKDIR "/src/src/services/NSE.Pedido.API"
RUN dotnet build "NSE.Pedido.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Pedido.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Pedido.API.dll"]