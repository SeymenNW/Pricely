# Use .NET SDK for building
#Usage: docker build -t x2 . -f PricelyWeb/PricelyWeb/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copy Entire Soluton
COPY . .

# Restore dependencies for the project and build
RUN dotnet restore "PricelyWeb/PricelyWeb/PricelyWeb.csproj"

# Build the main project (PricelyWeb)
RUN dotnet build "PricelyWeb/PricelyWeb/PricelyWeb.csproj" -c Release -o /build

# Publish the main project to the /publish folder
FROM build-env AS publish
RUN dotnet publish "PricelyWeb/PricelyWeb/PricelyWeb.csproj" -p:PublishSingleFile=false -r linux-musl-x64 --self-contained -c Release -o /publish

ENV BACKEND__URL=https://localhost:7036
ENV ASPNETCORE_ENVIRONMENT=Production

# Runtime environment
FROM alpine:latest
RUN apk upgrade --no-cache && apk add --no-cache libgcc libstdc++ icu-libs
WORKDIR /src
COPY --from=publish /publish /src
EXPOSE 5000
CMD ["./PricelyWeb", "--urls", "http://0.0.0.0:5000"]
