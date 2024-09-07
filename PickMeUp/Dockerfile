#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

# Base image with .NET runtime for production
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image with SDK for compilation and publishing
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies for all projects
COPY ["PickMeUp.API/PickMeUp.API.csproj", "PickMeUp.API/"]
COPY ["PickMeUp.DTO/PickMeUp.DTO.csproj", "PickMeUp.DTO/"]
COPY ["PickMeUp.Repository/PickMeUp.Repository.csproj", "PickMeUp.Repository/"]
COPY ["PickMeUp.Service/PickMeUp.Service.csproj", "PickMeUp.Service/"]

# Restore all the projects
RUN dotnet restore "PickMeUp.API/PickMeUp.API.csproj"

# Copy the rest of the application files
COPY . .

# Build the project
WORKDIR "/src/PickMeUp.API"
RUN dotnet build "PickMeUp.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "PickMeUp.API.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PickMeUp.API.dll"]
