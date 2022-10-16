#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApplication.Testing.Features/WebApplication.Testing.Features.csproj", "WebApplication.Testing.Features/"]
RUN dotnet restore "WebApplication.Testing.Features/WebApplication.Testing.Features.csproj"
COPY . .
WORKDIR "/src/WebApplication.Testing.Features"
RUN dotnet build "WebApplication.Testing.Features.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication.Testing.Features.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication.Testing.Features.dll"]