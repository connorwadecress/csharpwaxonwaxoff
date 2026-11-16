# Session 07: Teams and players (one-to-many, at speed)

**Focus:** Rebuild the Session 06 shape from memory, faster. Same layers, new domain.

## Starting point

Open `Session07.TeamsAndPlayers.slnx`. `League.Api` is an empty .NET 10 web project on port 5087. `Program.cs` only builds and runs the app. There are no packages, models, services, controllers, `DbContext` or connection string. You write all of it.

Try not to open Session 06 until you're stuck. Time yourself.

## Goal

Two entities, `Team` and `Player`. One team has many players, and every player belongs to exactly one team. Both are saved in SQL Server in a new database, `LeagueDb`.

## Steps

- [x] Add `Microsoft.EntityFrameworkCore.SqlServer` and `Microsoft.EntityFrameworkCore.Design`, pinned to `--version 10.0.15`.
- [ ] `Models/Team.cs`: Id, Name, City, and a collection of players.
- [ ] `Models/Player.cs`: Id, Name, ShirtNumber, Position, plus `TeamId` and a `Team` navigation property.
- [ ] `Data/AppDbContext.cs` with a `DbSet` for each entity.
- [ ] Connection string in `appsettings.json` (`localhost`, database `LeagueDb`), then `AddDbContext` and `AddControllers`/`MapControllers` in `Program.cs`.
- [ ] Migration `InitialCreate`, then `database update`. Find the foreign key and the index on `TeamId`.
- [ ] `ITeamService`/`TeamService` and `IPlayerService`/`PlayerService`, registered as scoped.
- [ ] `TeamsController`: CRUD, plus `GET /api/teams/{id}/players`.
- [ ] `PlayersController`: CRUD. Creating a player needs a `TeamId`.
- [ ] Request models for create and update, and response DTOs (for example a `PlayerResponse` with `TeamName`). Don't return entities.
- [ ] Test everything in `League.Api.http`, including the failure cases below.

## Failure cases your API must handle

- [ ] Create or update a player with a `TeamId` that doesn't exist → 400, not a 500 from SQL Server.
- [ ] Missing required field (no name) → 400.
- [ ] Team or player that doesn't exist → 404.
- [ ] `GET /api/teams/999/players` → 404, not an empty list.
- [ ] Delete a team that still has players. Decide what should happen this time. Last session it cascaded. Try `DeleteBehavior.Restrict` and return 409 Conflict instead.

## New this session

- [ ] **Transfer a player:** `PUT /api/players/{id}` with a different `TeamId` moves them. Check `GET /api/teams/{id}/players` for both teams afterwards.
- [ ] **Unique shirt number per team:** two players on the same team can't share a number. Add a composite unique index on `(TeamId, ShirtNumber)` in `OnModelCreating`, and return 409 if it's broken.

## Questions to be able to answer

- Where does the foreign key live, on `Team` or `Player`? Why?
- What does `Include` do to the SQL EF sends?
- What's the difference between `Cascade` and `Restrict`, and which did you pick?
- Why is the shirt-number rule an index and not just a check in the service?

## Stretch

- [ ] `GET /api/teams` returns each team with a player count, in one query.
- [ ] `GET /api/players?position=Goalkeeper` filters with a query string.

## Run

From the repo root:

```powershell
dotnet run --project Session07.TeamsAndPlayers/League.Api
```

Development URL: http://localhost:5087

Run `dotnet ef` commands from inside `Session07.TeamsAndPlayers/League.Api`.

## Notes

**Time taken:**

**What I built:**

**What I learned:**

**What confused me:**
