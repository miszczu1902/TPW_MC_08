FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Prezentacja/Prezentacja.csproj", "Prezentacja/"]
RUN dotnet restore "Prezentacja/Prezentacja.csproj"
COPY . .
WORKDIR "/src/Prezentacja"
RUN dotnet build "Prezentacja.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prezentacja.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prezentacja.dll"]
