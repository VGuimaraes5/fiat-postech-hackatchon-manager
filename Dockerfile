# inicio etapa de build 
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ARG PORT

# cópia do projeto para o container
WORKDIR /src
COPY . .

# restauração das dependencias e build do projeto
WORKDIR "/src/API"
RUN dotnet restore "API.csproj" --disable-parallel
RUN dotnet publish "API.csproj" -c Release -o /app/publish --no-restore

# inicio da etapa de publicação 
FROM mcr.microsoft.com/dotnet/aspnet:6.0 

# copia a build pronta para o servidor web
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE $PORT
ENTRYPOINT ["dotnet", "API.dll"]
