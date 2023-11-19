# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Attendance.Api/Attendance.Api.csproj", "Attendance.Api/"]
RUN dotnet restore "Attendance.Api/Attendance.Api.csproj"

# Copy the remaining source code
COPY . .

# Build the application
WORKDIR "/src/Attendance.Api"
RUN dotnet build "Attendance.Api.csproj" -c Release -o /app/build

# Use the official ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

# Copy the built application
COPY --from=build /app/build .

# Set the environment variables
ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIRONMENT Production

# Expose the port
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "Attendance.Api.dll"]
