# Session 06: Authors and books (one-to-many)

**Focus:** Relationships in EF Core, foreign keys, navigation properties, `Include`, response DTOs

## Starting point

Open `Session06.AuthorsAndBooks.slnx`. `Bookshelf.Api` is an empty .NET 10 web project on port 5086. `Program.cs` only builds and runs the app. There are no packages, models, services, controllers, `DbContext` or connection string. You write all of it, the way you did in Session 05.

## Goal

Two entities, `Author` and `Book`. One author has many books, and every book has exactly one author. Both are saved in SQL Server in a new database, `BookshelfDb`.

## Steps

- [ ] Add `Microsoft.EntityFrameworkCore.SqlServer` and `Microsoft.EntityFrameworkCore.Design`. **Pin them to 10.x** (`--version 10.0.15`), because the latest is EF Core 11, which needs .NET 11.
- [ ] `Models/Author.cs`: Id, Name, and a collection of books.
- [ ] `Models/Book.cs`: Id, Title, Isbn, PublishedYear, plus `AuthorId` and an `Author` navigation property.
- [ ] `Data/AppDbContext.cs` with a `DbSet` for each entity.
- [ ] Connection string in `appsettings.json` (`localhost`, database `BookshelfDb`), then `AddDbContext` and `AddControllers`/`MapControllers` in `Program.cs`.
- [ ] Migration `InitialCreate`, then `database update`. Open the migration: find the foreign key and the index EF created on `AuthorId`.
- [ ] `IAuthorService`/`AuthorService` and `IBookService`/`BookService`, registered as scoped.
- [ ] `AuthorsController`: CRUD, plus `GET /api/authors/{id}/books`.
- [ ] `BooksController`: CRUD. Creating a book needs an `AuthorId`.
- [ ] Response DTOs, for example a `BookResponse` that includes `AuthorName`. Don't return entities directly.
- [ ] Test everything in `Bookshelf.Api.http`.

## Things that will break (on purpose)

Hit each one, read the error, then fix it.

- [ ] GET a book and look at `Author`. Why is it `null`? (Look up `Include`.)
- [ ] Return a `Book` entity that has its `Author` loaded, which has its `Books` loaded… What does the JSON serializer do?
- [ ] POST a book with an `AuthorId` that doesn't exist. What does SQL Server do? What should your API return instead?
- [ ] Delete an author who has books. What happened to the books? Is that what you want? (Look up `OnDelete` and `DeleteBehavior.Restrict`.)

## Questions to be able to answer

- Which properties on `Book` become columns, and which exist only in C#?
- How does EF know `AuthorId` is the foreign key without you telling it?
- What is eager loading, and why doesn't EF load related data by default?
- What is an N+1 query, and how would you spot one?
- Why return DTOs instead of entities?

## Stretch

- [ ] Many-to-many: a book can have several authors. What does the join table look like in SQL?
- [ ] `GET /api/authors` returns each author with a count of their books, in one query.

## Run

From the repo root:

```powershell
dotnet run --project Session06.AuthorsAndBooks/Bookshelf.Api
```

Development URL: http://localhost:5086

Run `dotnet ef` commands from inside `Session06.AuthorsAndBooks/Bookshelf.Api`.

## Notes

**What I built:**

**What I learned:**

**What confused me:**
