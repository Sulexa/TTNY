#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TwitchGames.Users.Api/TwitchGames.Users.Api.csproj", "TwitchGames.Users.Api/"]
RUN dotnet restore "TwitchGames.Users.Api/TwitchGames.Users.Api.csproj"
COPY . .
WORKDIR "/src/TwitchGames.Users.Api"
RUN dotnet build "TwitchGames.Users.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TwitchGames.Users.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TwitchGames.Users.Api.dll"]