FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["src/API/EventHub.API.csproj", "src/API/"]
COPY ["src/Application/EventHub.Application.csproj", "src/Application/"]
COPY ["src/Domain/EventHub.Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/EventHub.Infrastructure.csproj", "src/Infrastructure/"]
RUN dotnet restore "src/API/EventHub.API.csproj"
COPY . .
WORKDIR "/src/src/API"
RUN dotnet publish "EventHub.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EventHub.API.dll"]
