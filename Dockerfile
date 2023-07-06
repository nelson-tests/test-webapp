FROM mcr.microsoft.com/dotnet/sdk:7.0.302 AS build-env

EXPOSE 80
WORKDIR /src

COPY "./src/*.csproj" .

RUN dotnet restore /src/*.csproj

COPY "./src/" .

RUN dotnet build -c Release -o /app
RUN dotnet publish /src/*.csproj --configuration Release --no-build --no-restore -o /app


FROM mcr.microsoft.com/dotnet/aspnet:7.0.5 AS final-env

WORKDIR /app

# Froce application to run in Production
ENV ASPNETCORE_ENVIRONMENT Production

COPY --from=build-env /app .

ENTRYPOINT ["dotnet", "Demo.dll"]
