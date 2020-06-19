#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["DockerTest3/DockerTest3.csproj", "DockerTest3/"]
#RUN dotnet restore "DockerTest3/DockerTest3.csproj"
#COPY . .
#WORKDIR "/src/DockerTest3"
#RUN dotnet build "DockerTest3.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "DockerTest3.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "DockerTest3.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

#Work dir
WORKDIR /app
EXPOSE 80
COPY ./bin/Release/netcoreapp3.1/publish .
ENTRYPOINT ["dotnet", "DockerTest3.dll"]


