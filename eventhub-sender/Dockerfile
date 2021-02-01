FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["eventhub-sender.csproj", "./"]
RUN dotnet restore "eventhub-sender.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "eventhub-sender.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eventhub-sender.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eventhub-sender.dll"]
