# Build image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR ./

COPY *.sln ./
COPY HackerNewsScraper/HackerNewsScraper.csproj  ./HackerNewsScraper/
COPY HackerNewsScraper.Domain/HackerNewsScraper.Domain.csproj  ./HackerNewsScraper.Domain/
COPY HackerNewScraper.Interfaces/HackerNewScraper.Interfaces.csproj  ./HackerNewScraper.Interfaces/
COPY HackerNewsScraper.Services/HackerNewsScraper.Services.csproj  ./HackerNewsScraper.Services/
COPY HackerNewsScraperTests/HackerNewsScraperTests.csproj  ./HackerNewsScraperTests/
COPY HackerNewsScraper.Services.Tests/HackerNewsScraper.Services.Tests.csproj  ./HackerNewsScraper.Services.Tests/

RUN dotnet restore 

# Copy everything else and build
COPY ./ ./
RUN dotnet build -c Release -o /app

# Build publish image
FROM build AS publish
WORKDIR ./
RUN dotnet publish ./HackerNewsScraper/HackerNewsScraper.csproj -c Release -o /app 

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1

WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "HackerNewsScraper.dll"]
