FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/api/VeggieLink.Api.csproj", "src/api/"]
RUN dotnet restore "src/api/VeggieLink.Api.csproj" 
COPY . .
WORKDIR "/src/src/api"
RUN dotnet build "VeggieLink.Api.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "VeggieLink.Api.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet VeggieLink.Api.dll
