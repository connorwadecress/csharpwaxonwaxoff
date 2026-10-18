# Session 03: Dependency injection

## Starting point

This independent .NET 10 solution starts with a copy of the completed Session 02 models and CRUD controller. Storage is still a static list inside the controller. No service or dependency-injection registration has been implemented yet.

## Goal

Keep the same HTTP behaviour while moving storage behind an injected service. Understand interfaces, constructor injection, and singleton, scoped, and transient lifetimes.

## Steps

- [ ] Explain AddControllers and MapControllers in Program.cs.
- [ ] Create Services/ITodoService.cs. Start with a GetAll method returning IReadOnlyList<TodoItem>.
- [ ] Create Services/InMemoryTodoService.cs implementing that interface, with an instance list of two starter tasks.
- [ ] Register ITodoService and InMemoryTodoService using AddSingleton before builder.Build(). Explain why this lifetime preserves in-memory data across requests.
- [ ] Inject ITodoService through the controller constructor and use it in GET all.
- [ ] Move lookup, creation, update, and deletion into the service one action at a time; keep HTTP responses in the controller.
- [ ] Remove the controller's static list once all actions use the service.
- [ ] Repeat Session 02's HTTP checks against port 5083.
- [ ] Compare transient, scoped, and singleton lifetimes. Explain why per-request in-memory storage loses changes between requests.
- [ ] Discuss synchronization of shared mutable storage before supporting concurrent writes. Singleton lifetime does not make a List thread-safe.

No database in this session. Data still disappears on restart.

## Run

From the repo root:

```powershell
dotnet run --project Session03.DependencyInjection/Todo.Api
```

Development URL: http://localhost:5083

After refactoring, repeat the HTTP checks while this API is running:

```powershell
./Session02.TodoApi/Verify-Api.ps1 -BaseUrl http://localhost:5083
```

## Notes

**What I built:**

**What I learned:**

**What confused me:**
