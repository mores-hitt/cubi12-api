# FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
# WORKDIR /src
# COPY *.csproj .
# RUN dotnet restore
# COPY . .
# RUN dotnet publish -c Release -o /publish
# FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
# WORKDIR /publish
# COPY --from=build-env /publish .
# ENV ASPNETCORE_URLS=http://+:5000
# EXPOSE 5000
# ENTRYPOINT ["dotnet", "Cubitwelve.dll"]

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App
# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "Cubitwelve.dll"]