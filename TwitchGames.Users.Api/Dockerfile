#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TwitchGames.Users.Api/TwitchGames.Users.Api.csproj", "TwitchGames.Users.Api/"]
COPY ["TwitchGames.Shared.Bus/TwitchGames.Shared.Bus.csproj", "TwitchGames.Shared.Bus/"]
COPY ["TwitchGames.Users.Domain/TwitchGames.Users.Domain.csproj", "TwitchGames.Users.Domain/"]
COPY ["TwitchGames.Users.Dal/TwitchGames.Users.Dal.csproj", "TwitchGames.Users.Dal/"]
COPY ["TwitchGames.Shared.BaseRepository/TwitchGames.Shared.BaseRepository.csproj", "TwitchGames.Shared.BaseRepository/"]
COPY ["TwitchGames.Shared.UnitOfWork/TwitchGames.Shared.UnitOfWork.csproj", "TwitchGames.Shared.UnitOfWork/"]
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
