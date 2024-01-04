FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["Attendance.Api/Attendance.Api.csproj", "Attendance.Api/"]
COPY ["Attendance.Application/Attendance.Application.csproj", "Attendance.Application/"]
COPY ["Attendance.Domain/Attendance.Domain.csproj", "Attendance.Domain/"]
COPY ["Attendance.Infra.Data/Attendance.Infra.Data.csproj", "Attendance.Infra.Data/"]
COPY ["Attendance.Infra.Ioc/Attendance.Infra.Ioc.csproj", "Attendance.Infra.Ioc/"]
COPY ["Attendance.Infra.Integration/Attendance.Infra.Integration.csproj", "Attendance.Infra.Integration/"]

RUN dotnet restore "Attendance.Api/Attendance.Api.csproj"

COPY . .
WORKDIR "/src/Attendance.Api"
RUN dotnet build "Attendance.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Attendance.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Attendance.Api.dll"]
