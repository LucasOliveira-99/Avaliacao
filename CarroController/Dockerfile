# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CarroController/Avaliacao.Microservice.WebAPI.csproj", "CarroController/"]
COPY ["Avaliacao.Application/Avaliacao.Application.csproj", "Avaliacao.Application/"]
COPY ["Avaliacao.Infraestructure.CrossCutting/Avaliacao.Infraestructure.CrossCutting.csproj", "Avaliacao.Infraestructure.CrossCutting/"]
COPY ["Avaliacao.Infraestructure/Avaliacao.Infraestructure.csproj", "Avaliacao.Infraestructure/"]
COPY ["Avaliacao.Microservice.Domain/Avaliacao.Microservice.Domain.csproj", "Avaliacao.Microservice.Domain/"]
COPY ["Avaliacao.Infraestructure.CrossCutting.IoC/Avaliacao.Infraestructure.CrossCutting.IoC.csproj", "Avaliacao.Infraestructure.CrossCutting.IoC/"]
RUN dotnet restore "./CarroController/Avaliacao.Microservice.WebAPI.csproj"
COPY . .
WORKDIR "/src/CarroController"
RUN dotnet build "./Avaliacao.Microservice.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Avaliacao.Microservice.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Avaliacao.Microservice.WebAPI.dll"]