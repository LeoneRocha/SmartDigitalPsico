#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# Imagem base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /myapi
EXPOSE 80
EXPOSE 443  


# Copia dos arquivos do projeto
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /myapisrc
COPY ["SmartDigitalPsico.WebAPI/SmartDigitalPsicoWebAPI.csproj", "SmartDigitalPsico.WebAPI/"]
COPY ["SmartDigitalPsico.Model/SmartDigitalPsico.Model.csproj", "SmartDigitalPsico.Model/"]
COPY ["SmartDigitalPsico.Dominio/SmartDigitalPsico.Domains.csproj", "SmartDigitalPsico.Dominio/"]
COPY ["SmartDigitalPsico.Services/SmartDigitalPsico.Services.csproj", "SmartDigitalPsico.Services/"]
COPY ["SmartDigitalPsico.Bussines/SmartDigitalPsico.Business.csproj", "SmartDigitalPsico.Bussines/"]
COPY ["SmartDigitalPsico.Data/SmartDigitalPsico.Repository.csproj", "SmartDigitalPsico.Data/"]
# Restaura as dependências do projeto
RUN dotnet restore "SmartDigitalPsico.WebAPI/SmartDigitalPsicoWebAPI.csproj"
# Copia do código fonte
COPY . .
WORKDIR "/myapisrc/SmartDigitalPsico.WebAPI"
# Build da aplicação
RUN dotnet build "SmartDigitalPsicoWebAPI.csproj" -c Release -o /myapi/build

# Publicação da aplicação
FROM build AS publish
RUN dotnet publish "SmartDigitalPsicoWebAPI.csproj" -c Release -o /myapi/publish /p:UseAppHost=false

# Execução da aplicação
FROM base AS final
WORKDIR /myapi
COPY --from=publish /myapi/publish .
# Define o comando de entrada
ENTRYPOINT ["dotnet", "SmartDigitalPsicoWebAPI.dll"]