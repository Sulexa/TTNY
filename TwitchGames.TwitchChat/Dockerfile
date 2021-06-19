#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TwitchGames.TwitchChat/TwitchGames.TwitchChat.csproj", "TwitchGames.TwitchChat/"]
RUN dotnet restore "TwitchGames.TwitchChat/TwitchGames.TwitchChat.csproj"
COPY . .
WORKDIR "/src/TwitchGames.TwitchChat"
RUN dotnet build "TwitchGames.TwitchChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TwitchGames.TwitchChat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TwitchGames.TwitchChat.dll"]