FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /src
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
COPY ["Chain.csproj", "src/"]
RUN dotnet restore "src/Chain.csproj"
WORKDIR /src
COPY . .
WORKDIR "/src"
RUN dotnet build "Chain.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Chain.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "Chain.dll"]