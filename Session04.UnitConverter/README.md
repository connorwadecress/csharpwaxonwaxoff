# Session 04: Unit converter

**Focus:** Query strings vs route values, enums, `switch` expressions, returning 400

## Brief

Build a minimal API that converts lengths. No storage at all: every request is worked out from its inputs.

| Method | Route | Returns |
|--------|-------|---------|
| GET | `/convert?from=km&to=mi&value=5` | The converted value, or 400 for bad input |
| GET | `/convert/{from}/{to}/{value}` | The same result, using route values instead |

Units: `km`, `mi`, `m`, `ft`.

## Starting point

An empty minimal API (`dotnet new web`). `Program.cs` builds and runs the app and maps no endpoints, so every request returns 404.

## Checklist

- [ ] A `LengthUnit` enum with the four units
- [ ] Decide how to convert any unit to any other without writing 12 separate cases (hint: pick one unit to go through)
- [ ] Use a `switch` expression for the per-unit factor
- [ ] GET `/convert` reading `from`, `to` and `value` from the query string
- [ ] Return a small result object (from, to, value, result), not just a bare number
- [ ] Send an unknown unit like `from=parsecs` and see what happens without any code of yours. Then decide whether to return your own 400 with a clearer message
- [ ] Return 400 when `value` is missing or isn't a number
- [ ] Add the route-values version and compare: which feels right for this endpoint, and why?
- [ ] Test every case in `UnitConverter.Api.http`: a good conversion, same unit to same unit, an unknown unit, a missing value, a non-number value, and different casing (`KM` vs `km`)

## Things to be able to explain

- When you'd use a query string and when you'd use a route value
- What a `switch` expression gives you over a `switch` statement, and what happens if no arm matches
- How the framework turns `"km"` in the URL into your enum
- How this minimal API compares with the controllers you wrote in Sessions 2 and 3

## Stretch

- [ ] Use `MapGroup("/convert")` for both routes
- [ ] Add temperature (C, F, K). Why doesn't the "multiply by a factor" approach work here?

## Run

From the repo root:

```powershell
dotnet run --project Session04.UnitConverter/UnitConverter.Api
```

Development URL: http://localhost:5084

## Notes

**What I built:**

**What I learned:**

**What confused me:**
