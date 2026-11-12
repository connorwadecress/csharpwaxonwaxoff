# Session 05: Library (EF Core + SQL Server)

## Starting point

Open Session05.Library.slnx in Visual Studio. Library.Api is an empty .NET 10 web project on port 5085. Program.cs only builds and runs the app. There are no NuGet packages, models, controllers, DbContext or connection string yet. You write all of that.

## Goal

Books CRUD, with the data saved in SQL Server instead of a list in memory. Restart the app and your books are still there.

Concepts: `DbContext`, `DbSet<T>`, migrations, connection strings in `appsettings.json`, and why `AddDbContext` registers the context as **scoped**.

Keep it to **one entity: `Book`**. Authors and relationships come in Session 06.

## Steps

- [ ] Add NuGet packages `Microsoft.EntityFrameworkCore.SqlServer` and `Microsoft.EntityFrameworkCore.Design`. Explain what each one is for.
- [ ] Create `Models/Book.cs`: Id, Title, Isbn, PublishedYear. Decide which fields are required.
- [ ] Create `Data/LibraryDbContext.cs` with a `DbSet<Book>`. How does it receive its options?
- [ ] Add a `ConnectionStrings` section to `appsettings.json` pointing at `(localdb)\MSSQLLocalDB`, database `LibraryDb`.
- [ ] In Program.cs, register the context with `AddDbContext` and read the connection string from configuration. Add controllers too.
- [ ] Run `dotnet ef migrations add InitialCreate`, then open the generated files and explain what they contain.
- [ ] Run `dotnet ef database update`. Find the table in SQL Server Object Explorer or SSMS.
- [ ] Build `BooksController`: GET all, GET by id, POST, PUT, DELETE. Use async EF calls and the right status codes (200, 201 with `CreatedAtAction`, 204, 404).
- [ ] Write the requests in `Library.Api.http`. Restart the app and confirm the data survived.
- [ ] Add a second migration: a new column, such as `Genre`. What does that migration's `Up` and `Down` do?

## Experiments (from the 12 Nov call)

Try each one, write down what happens, then put it back to scoped.

- [ ] Register the context as a singleton (`AddDbContext(..., ServiceLifetime.Singleton)`). Do two requests at the same time break anything? Why?
- [ ] Register it as transient. What changes, and what doesn't?
- [ ] Restart the app fully after each change. Hot reload does not re-run Program.cs.

## Questions to be able to answer

- What is the difference between a migration and `database update`?
- What does `SaveChangesAsync` actually do? What happens to an entity you `Add` but never save?
- Why is `DbContext` scoped by default?
- Where should the connection string live in production, if not `appsettings.json`?

## Run

From the repo root:

```powershell
dotnet run --project Session05.Library/Library.Api
```

Development URL: http://localhost:5085

Run `dotnet ef` commands from inside `Session05.Library/Library.Api`.

## Notes

**What I built:**

**What I learned:**

**What confused me:**
