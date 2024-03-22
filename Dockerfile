# inicio etapa de build 
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

ARG PORT

# cópia do projeto para o container
WORKDIR /src
COPY . .

# restauração das dependencias e build do projeto
WORKDIR "/src/Hackathon.Manager.Api"
RUN dotnet restore "Hackathon.Manager.Api.csproj" --disable-parallel
RUN dotnet publish "Hackathon.Manager.Api.csproj" -c Release -o /app/publish --no-restore

# inicio da etapa de publicação 
FROM mcr.microsoft.com/dotnet/aspnet:6.0 

# copia a build pronta para o servidor web
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE $PORT
ENTRYPOINT ["dotnet", "Hackathon.Manager.Api.dll"]
