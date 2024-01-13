

#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
##COPY ["SalesNet.csproj", "."]
#COPY . .
#RUN dotnet restore "./SalesNet.csproj"
##COPY . .
##WORKDIR "/src/."
##RUN dotnet build "SalesNet.csproj" -c Release -o /app/build
##
##FROM build AS publish
#RUN dotnet publish "SalesNet.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0
#
##FROM base AS final
#WORKDIR /app
#COPY --from=build /app ./
#EXPOSE 5000
#ENTRYPOINT ["dotnet", "run"]


#FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
#WORKDIR /app
#
## Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore
#
## Copy everything else and build
#COPY . ./
#RUN dotnet publish "SalesNet.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "SalesNet.dll"]

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "SalesNet.dll"]