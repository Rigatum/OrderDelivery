FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

RUN apt-get update && \
    apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_lts.x | bash - && \
    apt-get install -y nodejs && \
    npm install -g grunt-cli

WORKDIR /src

COPY ["OrderDelivery.csproj", "package.json", "package-lock.json", "./"]

RUN npm install && \
    dotnet restore

COPY . .

RUN rm -rf obj bin && \
    dotnet build "OrderDelivery.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderDelivery.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderDelivery.dll"]