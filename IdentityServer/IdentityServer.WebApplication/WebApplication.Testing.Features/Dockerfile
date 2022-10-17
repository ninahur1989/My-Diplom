#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ENV ASPNETCORE_URLS=http://*:59001
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /src
COPY ["/WebApplication.Testing.Features.csproj", "/"]
RUN dotnet restore "/WebApplication.Testing.Features.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "WebApplication.Testing.Features.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication.Testing.Features.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


EXPOSE 80
ENTRYPOINT ["dotnet", "WebApplication.Testing.Features.dll"]

