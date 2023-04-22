#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SmartDigitalPsico.WebAPI/SmartDigitalPsicoWebAPI.csproj", "SmartDigitalPsico.WebAPI/"]
COPY ["SmartDigitalPsico.Model/SmartDigitalPsico.Model.csproj", "SmartDigitalPsico.Model/"]
COPY ["SmartDigitalPsico.Dominio/SmartDigitalPsico.Domains.csproj", "SmartDigitalPsico.Dominio/"]
COPY ["SmartDigitalPsico.Services/SmartDigitalPsico.Services.csproj", "SmartDigitalPsico.Services/"]
COPY ["SmartDigitalPsico.Bussines/SmartDigitalPsico.Business.csproj", "SmartDigitalPsico.Bussines/"]
COPY ["SmartDigitalPsico.Data/SmartDigitalPsico.Repository.csproj", "SmartDigitalPsico.Data/"]
RUN dotnet restore "SmartDigitalPsico.WebAPI/SmartDigitalPsicoWebAPI.csproj"
COPY . .
WORKDIR "/src/SmartDigitalPsico.WebAPI"
RUN dotnet build "SmartDigitalPsicoWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartDigitalPsicoWebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartDigitalPsicoWebAPI.dll"]