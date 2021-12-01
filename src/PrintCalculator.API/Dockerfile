FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/HHGroup.PrintCalculator.API/HHGroup.PrintCalculator.API.csproj", "HHGroup.PrintCalculator.API/"]
RUN dotnet restore "src/HHGroup.PrintCalculator.API/HHGroup.PrintCalculator.API.csproj"
COPY . .
WORKDIR "/src/HHGroup.PrintCalculator.API"
RUN dotnet build "HHGroup.PrintCalculator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HHGroup.PrintCalculator.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HHGroup.PrintCalculator.API.dll"]
