# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /source

# Copy csproj and restore as distinct layers
# COPY *.csproj ./sample_ms/
# RUN dotnet restore

# Copy everything else and build
COPY . ./sample_ms/
WORKDIR /source/sample_ms
RUN dotnet publish -c Release -o /app 

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app ./
ENTRYPOINT ["dotnet", "sample_ms.dll"]