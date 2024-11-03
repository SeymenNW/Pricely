# Use the SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build-env

WORKDIR /app
EXPOSE 5000

# Copy the entire solution and project files
COPY . .
RUN dotnet restore "PricelyAPI/PricelyAPI.csproj"

# Copy the rest of the application and publish it
RUN dotnet publish "PricelyAPI/PricelyAPI.csproj" -c Release -o /app/publish

# Use a runtime image as the final base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
COPY --from=build-env /app/publish .

# Set the ASP.NET Core URLs environment variable
ENV ASPNETCORE_URLS=http://+:5000

# Set proxy environment variables

# Set the entry point for the application
ENTRYPOINT ["dotnet", "PricelyAPI.dll"]
