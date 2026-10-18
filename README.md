# EventHub

A full-stack event discovery and management platform. Users can view local events or create their own.

## 🏗️ Architecture
This project follows **Clean Architecture** principles:
- **Domain:** Core entities (Event, Organizer).
- **Application:** Use cases and interfaces.
- **Infrastructure:** Database context (EF Core) and PostgreSQL.
- **API:** ASP.NET Core Web API.
- **Client:** React + TypeScript + Tailwind CSS.

## 🛠️ Tech Stack
- **Frontend:** React 19, TypeScript, Vite, Tailwind CSS
- **Backend:** .NET 10, ASP.NET Core, Entity Framework Core
- **Database:** PostgreSQL 16 (Dockerized)

## 🏃‍♂️ How to Run Locally
1. Start the database: `docker run --name eventhub-db -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=eventhub -p 5433:5432 -d postgres:16`
2. Run the backend: `dotnet run --project src/API`
3. Run the frontend: `cd src/Client && npm install && npm run dev`
