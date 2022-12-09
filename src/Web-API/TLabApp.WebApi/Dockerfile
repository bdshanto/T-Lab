#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TLabApp.WebApi/TLabApp.WebApi.csproj", "TLabApp.WebApi/"]
COPY ["TLabApp.Application/TLabApp.Application.csproj", "TLabApp.Application/"]
COPY ["TLabApp.Domain/TLabApp.Domain.csproj", "TLabApp.Domain/"]
COPY ["TLabApp.Infrastructure/TLabApp.Infrastructure.csproj", "TLabApp.Infrastructure/"]
RUN dotnet restore "TLabApp.WebApi/TLabApp.WebApi.csproj"
COPY . .
WORKDIR "/src/TLabApp.WebApi"
RUN dotnet build "TLabApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TLabApp.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TLabApp.WebApi.dll"]