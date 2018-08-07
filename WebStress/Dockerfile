FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["WebStress/WebStress.csproj", "WebStress/"]
RUN dotnet restore "WebStress/WebStress.csproj"
COPY . .
WORKDIR "/src/WebStress"
RUN dotnet build "WebStress.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebStress.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebStress.dll"]