# Interview Assignment

## Project structure

The main CLI interface is in `ConsoleInterface`. The `LibraryService` project provides the business logic and the `DataAccess` project provides data access through the repository pattern.

Unit tests are projects sit alongside the projects they are testing.

## Run application

Install dotnet version 8.0.303. Change directory to ConsoleInterface and run the command `dotnet build` and then `dotnet run`

## Use application

The application runs as an interactive terminal interface. Because of the in memory database data is only persisted while running. The available commands are 

- add
- list
- update
- delete
- details
- exit

Each command will ask for further details in the terminal that is required. e.g. book title/author/ISBN

## Tests

To run all tests run `dotnet build` then `dotnet test` in the root directory (next to the .sln file)



