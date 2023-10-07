FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY ["./.certs","/certs"]
WORKDIR /src
COPY ["Backend/Backend.API/Backend.API.csproj", "Backend/"]
RUN dotnet restore "Backend/Backend.API.csproj"
COPY ["Backend/Backend.API/", "Backend/"]
WORKDIR "/src/Backend"
RUN dotnet build "Backend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM publish AS dev
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "watch", "run", "--no-launch-profile", "--filter", "**/*.cs"]

FROM publish AS prod
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "/app/Backend.API.dll" ]