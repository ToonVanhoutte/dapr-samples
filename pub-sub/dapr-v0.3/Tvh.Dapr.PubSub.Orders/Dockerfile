#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Tvh.Dapr.PubSub.Orders.csproj", "Tvh.Dapr.PubSub.Orders/"]
RUN dotnet restore "Tvh.Dapr.PubSub.Orders/Tvh.Dapr.PubSub.Orders.csproj"
COPY . "Tvh.Dapr.PubSub.Orders/"
WORKDIR "/src/Tvh.Dapr.PubSub.Orders"
RUN dotnet build "Tvh.Dapr.PubSub.Orders.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tvh.Dapr.PubSub.Orders.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tvh.Dapr.PubSub.Orders.dll"]