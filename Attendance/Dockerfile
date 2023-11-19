# Use a imagem oficial do .NET SDK como estágio de construção
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

# Configuração do banco de dados PostgreSQL e aplicação de migrações
RUN apt-get update && \
    apt-get install -y postgresql-client && \
    echo "host all all 0.0.0.0/0 md5" >> /etc/postgresql/12/main/pg_hba.conf && \
    service postgresql start && \
    su postgres -c "psql -c 'CREATE DATABASE attendance;'" && \
    su postgres -c "psql -c 'CREATE USER postgres WITH ENCRYPTED PASSWORD '\''P@ssw0rd2023'\'';'" && \
    su postgres -c "psql -c 'ALTER ROLE postgres SET client_encoding TO '\''utf8'\'';'" && \
    su postgres -c "psql -c 'ALTER ROLE postgres SET default_transaction_isolation TO '\''read committed'\'';'" && \
    su postgres -c "psql -c 'ALTER ROLE postgres SET timezone TO '\''UTC'\'';'" && \
    dotnet ef migrations add InitialMigration --context AppDbContext --output /app/Migrations && \
    dotnet ef database update --context AppDbContext

# Use a imagem oficial do ASP.NET como estágio final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

# Copie a aplicação construída do estágio de construção
COPY --from=build /app/build .

# Configuração do banco de dados PostgreSQL
ENV ConnectionStrings__DefaultConnection "Host=localhost;Port=5432;Database=attendance;Username=postgres;Password=P@ssw0rd2023;"

# Set the environment variables
ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIRONMENT Production

# Exponha a porta
EXPOSE 80

# Execute a aplicação
ENTRYPOINT ["dotnet", "Attendance.Api.dll"]
