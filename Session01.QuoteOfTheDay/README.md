# Session 01: Quote of the day

**Focus:** Minimal APIs, routing, `Results.Ok` / `NotFound`

## Brief

Build a small API that serves quotes from an in-memory list. No database.

| Method | Route | Returns |
|--------|-------|---------|
| GET | `/quotes` | All quotes |
| GET | `/quotes/{id}` | One quote, or 404 if it doesn't exist |
| GET | `/quotes/random` | One random quote |

## Checklist

- [ ] A `Quote` type (id, text, author)
- [ ] A hard-coded list of a few quotes
- [ ] GET all
- [ ] GET by id, returning 404 when it isn't found
- [ ] GET random
- [ ] Test every endpoint in `QuoteOfTheDay.Api.http`

## Stretch

- [ ] Group the routes with `MapGroup("/quotes")`
- [ ] Add a route constraint so `/quotes/abc` doesn't match the id route

## Notes

**What I built:**

**What I learned:**

**What confused me:**
