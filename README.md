# backend-code-challenge



We would like you to create a simple REST API that allows to:

1.get a list of medications

2.create a new medication

3.delete a medication

REQUIREMENTS:

•Each medication must have a name, a quantity and a creation date: 

oThe quantity must be greater than zero

•You can use the database technology of your preference 

•The project must be written in C# using .Net Core

•The project can optionally include an example unit test

•The project can be under a git repository and to deliver it, send us an email with a link to a repo on GitHub, Bitbucket or GitLab

## Testing with `curl`

The API runs on `http://localhost:8080`.
These examples use `jq` to pretty-print the JSON response.
If you want to see the HTTP status code, use `-i` instead.

### Get the medication list

```bash
curl -s http://localhost:8080/api/medication | jq
```

### Create a medication

Request body:

- `name`: medication name
- `quantity`: number of units, must be greater than zero

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
curl -s -X DELETE http://localhost:8080/api/medication/00000000-0000-0000-0000-000000000000 | jq
```

## Updating the database

If you change the entity model, create a new migration and apply it to MySQL:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

If `dotnet ef` is not available yet, install it once:

```bash
dotnet tool install --global dotnet-ef
dotnet add src/Medications.Api package Microsoft.EntityFrameworkCore.Design
```
