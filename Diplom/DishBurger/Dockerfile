#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["/DishBurger.csproj", "/"]
RUN dotnet restore "/DishBurger.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "DishBurger.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DishBurger.csproj" -c Release -o /app/publish

FROM base AS final

ENV ASPNETCORE_URLS=http://*:8080
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "DishBurger.dll"]

