#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FonRadar.Api/FonRadar.Api.csproj", "FonRadar.Api/"]
COPY ["FonRadar.Infrastructure/FonRadar.Infrastructure.csproj", "FonRadar.Infrastructure/"]
COPY ["FonRadar.Application/FonRadar.Application.csproj", "FonRadar.Application/"]
RUN dotnet restore "FonRadar.Api/FonRadar.Api.csproj"
COPY . .
WORKDIR "/src/FonRadar.Api"
RUN dotnet build "FonRadar.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FonRadar.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FonRadar.Api.dll"]
