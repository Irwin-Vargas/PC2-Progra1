
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app


COPY . ./


RUN dotnet restore practica2.csproj
RUN dotnet publish practica2.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "practica2.dll"]
