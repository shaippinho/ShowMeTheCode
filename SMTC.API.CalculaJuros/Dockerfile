#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SMTC.API.CalculaJuros/SMTC.API.CalculaJuros.csproj", "SMTC.API.CalculaJuros/"]
RUN dotnet restore "SMTC.API.CalculaJuros/SMTC.API.CalculaJuros.csproj"
COPY . .
WORKDIR "/src/SMTC.API.CalculaJuros"
RUN dotnet build "SMTC.API.CalculaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SMTC.API.CalculaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SMTC.API.CalculaJuros.dll", "--environment=Development"]