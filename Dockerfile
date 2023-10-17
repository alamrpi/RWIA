#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RWIA.API/RWIA.API.csproj", "RWIA.API/"]
COPY ["RWIA.Service/RWIA.Service.csproj", "RWIA.Service/"]
COPY ["RWIA.Persistence/RWIA.Persistence.csproj", "RWIA.Persistence/"]
COPY ["RWIA.Entities/RWIA.Entities.csproj", "RWIA.Entities/"]
COPY ["RWIA.Utility/RWIA.Utility.csproj", "RWIA.Utility/"]
RUN dotnet restore "RWIA.API/RWIA.API.csproj"
COPY . .
WORKDIR "/src/RWIA.API"
RUN dotnet build "RWIA.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RWIA.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RWIA.API.dll"]