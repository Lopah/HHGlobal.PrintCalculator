FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/PrintCalculator.API/", "PrintCalculator.API/"]
COPY ["src/PrintCalculator.Core/", "PrintCalculator.Core/"]
RUN dotnet restore "PrintCalculator.API/PrintCalculator.API.csproj"
COPY . .
WORKDIR /src/PrintCalculator.API
RUN dotnet build "PrintCalculator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PrintCalculator.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrintCalculator.API.dll"]
