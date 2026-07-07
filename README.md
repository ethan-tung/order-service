# OrderService

Scaffold for OrderService (.NET 10) with Docker, docker-compose, Flowable8, MySQL, Redis, RabbitMQ, and VS Code devcontainer.

This branch contains a minimal scaffold to get started. After cloning:

1. Install .NET 10 SDK.
2. From repo root run `dotnet restore` and `dotnet build` in each project folder or create a solution with `dotnet new sln` and `dotnet sln add`.
3. Start dependencies: `docker-compose up -d`
4. Run the Api project locally or build the Docker images with `docker-compose up --build`.

See docker-compose.yml and README for more details.
