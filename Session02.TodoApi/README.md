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

The .NET 10 project registers and maps controllers in Program.cs. The template weather endpoint has been removed. There are no to-do endpoints yet, so requests currently return 404.

## Steps

- [ ] Read Program.cs: explain AddControllers and MapControllers.
- [ ] Create Models/TodoItem.cs with Id, Title, and IsCompleted.
- [ ] Create Controllers/TodosController.cs; understand ControllerBase, ApiController, and Route.
- [ ] Add in-memory storage and GET all. Decide how data will survive separate requests; controller instances are not persistent storage.
- [ ] Add GET by ID with an integer route constraint and 404 handling.
- [ ] Add a create request model and POST; reject blank titles and assign IDs on the server.
- [ ] Add an update request model and PUT; reject blank titles and handle missing IDs.
- [ ] Add DELETE with 204 on success and 404 for a missing ID.
- [ ] Add and send requests in Todo.Api.http for success, invalid input, and missing IDs.
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
