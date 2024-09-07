FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7198
ENV ASPNETCORE_URLS=http://+:7198


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "PickMeUp/PickMeUp.API.csproj" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY PickMeUp/dataSeed.sql ./
ENTRYPOINT ["dotnet", "PickMeUp.API.dll"]