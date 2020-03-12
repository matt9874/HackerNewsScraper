## HackerNewsScraper
A console application that scrapes information about posts from the Hacker News website

## Installation
Requires .NET Core 3.1 which can be downloaded [here](https://dotnet.microsoft.com/download/dotnet-core/3.1)

Open a command prompt.

Clone the repo fom github by executing:

	 git clone https://github.com/matt9874/HackerNewsScraper.git
Change folder:

	cd HackerNewsScraper

## Tests
To run tests, from the command prompt, execute:

	dotnet test HackerNewsScraper.sln

## Execute
To build the application, from the command prompt, execute:

	dotnet build HackerNewsScraper/HackerNewsScraper.csproj -c Release

Once you've changed folders by executing

	cd HackerNewsScraper\bin\Release\netcoreapp3.1
you can run it by executing:

	HackerNewsScraper --posts n
where n is an integer between 1 and 100 that defines the number of posts you wish to scrape. 
