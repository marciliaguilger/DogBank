#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/DogBank.Api/DogBank.Api.csproj", "src/DogBank.Api/"]
RUN dotnet restore "src/DogBank.Api/DogBank.Api.csproj"
COPY . .
WORKDIR "/src/src/DogBank.Api"
RUN dotnet build "DogBank.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DogBank.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DogBank.Api.dll"]
