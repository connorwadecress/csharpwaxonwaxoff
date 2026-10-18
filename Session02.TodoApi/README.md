# Session 02: To-do API

Build a controller-based API with in-memory storage. Write the model and endpoints yourself, one step at a time.

## Focus

Controllers, attribute routing, request models, validation, and HTTP responses.

| Method | Route | Purpose |
|---|---|---|
| GET | `/todos` | Return all tasks |
| GET | `/todos/{id}` | Return a task or 404 |
| POST | `/todos` | Create a task; return 201 and its location |
| PUT | `/todos/{id}` | Update a task or return 404 |
| DELETE | `/todos/{id}` | Delete a task or return 404 |

## Starting point

The .NET 10 project registers and maps controllers in Program.cs. All five CRUD actions are implemented in TodosController using a shared in-memory list.

## Steps

- [ ] Read Program.cs: explain AddControllers and MapControllers.
- [x] Create Models/TodoItem.cs with Id, Title, and IsCompleted.
- [ ] Create Controllers/TodosController.cs; understand ControllerBase, ApiController, and Route.
- [x] Add in-memory storage and GET all. Decide how data will survive separate requests; controller instances are not persistent storage.
- [x] Add GET by ID with an integer route constraint and 404 handling.
- [x] Add a create request model and POST; reject blank titles and assign IDs on the server.
- [x] Add an update request model and PUT; reject blank titles and handle missing IDs.
- [x] Add DELETE with 204 on success and 404 for a missing ID.
- [x] Add and send requests in Todo.Api.http for success, invalid input, and missing IDs.
- [ ] Record what you learned below.

Storage is for this learning exercise only: added tasks disappear on restart. Discuss shared-state concurrency before treating the API as ready for multiple clients.

## Run

From the repository root:

```powershell
dotnet run --project Session02.TodoApi/Todo.Api
```

Development URL: http://localhost:5082

## Notes

**What I built:**

**What I learned:**

**What confused me:**

## Verified completion

Build passed with zero warnings and errors. On 2026-10-18, Verify-Api.ps1 passed against a fresh local process: GET all and by ID (200), POST (201 with Location and server-assigned ID), PUT (204 with changes confirmed by GET), blank titles (400 without changing stored data), missing IDs (404), DELETE (204 followed by GET 404), and a non-integer route (404).

To repeat, start the API, then run this in a separate PowerShell 7 terminal from the repo root:

```powershell
./Session02.TodoApi/Verify-Api.ps1
```

The script creates and deletes its own task. The .http file also contains manual requests; its delete request removes seeded task 1. Personal learning notes above are left for Connor to fill in.

