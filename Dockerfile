FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
# Copy csproj files to restore dependencies
COPY ["Api/Api.csproj", "Api/"]
COPY ["biblioteca/biblioteca.csproj", "biblioteca/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "Api/Api.csproj"

# Copy all the source code
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
