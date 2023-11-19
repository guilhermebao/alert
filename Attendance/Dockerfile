# Estágio de construção
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copie o arquivo do projeto e restaure as dependências
COPY ["Attendance.Api/Attendance.Api.csproj", "Attendance.Api/"]
RUN dotnet restore "Attendance.Api/Attendance.Api.csproj"

# Copie o restante do código-fonte
COPY . .

# Construa a aplicação
WORKDIR "/src/Attendance.Api"
RUN dotnet build "Attendance.Api.csproj" -c Release -o /app/build

# Estágio final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

# Copie a aplicação construída do estágio de construção
COPY --from=build /app/build .

# Set the environment variables
ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIRONMENT Production

# Expor a porta para o Nginx
EXPOSE 80

# Execute a aplicação
ENTRYPOINT ["dotnet", "Attendance.Api.dll"]
