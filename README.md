# Medications API

A simple REST API built with C# and ASP.NET Core for managing medications.

## Overview

This project was created for a backend code challenge and provides the following capabilities:

- List all medications
- Create a new medication
- Delete an existing medication

Each medication includes:

- `id`
- `name`
- `quantity`
- `creationDate`

The API persists data in MySQL through Entity Framework Core.

## Tech Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Docker and Docker Compose
- NUnit for tests

## Project Structure

- `src/Medications.Api` - main API project
- `tests/Medications.Api.Tests` - unit test project

## Requirements

- .NET SDK 10
- Docker and Docker Compose
- Optional: `curl` and `jq` for quick manual checks

## How To Run

From the repository root:

```bash
docker compose up --build
```

The API will be available at `http://localhost:8080`, and MySQL is started automatically by Compose.

## API Endpoints

### Get all medications

```bash
GET /api/medication
```

Example:

```bash
curl -s http://localhost:8080/api/medication | jq
```

### Create a medication

```bash
POST /api/medication
```

Request body:

```json
{
  "name": "Paracetamol",
  "quantity": 10
}
```

Example:

```bash
curl -s -X POST http://localhost:8080/api/medication \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Paracetamol",
    "quantity": 10
  }' | jq
```

### Delete a medication

```bash
DELETE /api/medication/{id}
```

Example:

```bash
curl -s -X DELETE http://localhost:8080/api/medication/00000000-0000-0000-0000-000000000000 | jq
```

## Tests

Run the test suite from the repository root:

```bash
dotnet test Medications.slnx
```

Run only the unit test project:

```bash
dotnet test tests/Medications.Api.Tests/Medications.Api.Tests.csproj
```

## Database Migrations

If you change the entity model, create and apply a new migration from the repository root:

```bash
dotnet ef migrations add <MigrationName> --project src/Medications.Api
dotnet ef database update --project src/Medications.Api
```

If `dotnet ef` is not installed yet:

```bash
dotnet tool install --global dotnet-ef
dotnet add src/Medications.Api package Microsoft.EntityFrameworkCore.Design
```

## Notes

- The API validates that medication quantity is greater than zero.
- Creation dates are stored automatically when a medication is created.
