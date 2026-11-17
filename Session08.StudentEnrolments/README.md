# Session 08 - Student enrolments

Many-to-many this time (students and courses), and split into 4 projects instead of one.

## Projects

- `Enrolments.Domain` - just the entities. no packages
- `Enrolments.Application` - requests, responses, services and the repository interfaces
- `Enrolments.Infrastructure` - DbContext, migrations, the actual repositories (EF stuff lives here)
- `Enrolments.Api` - controllers, Program.cs, appsettings, .http file

Domain doesn't reference anything. Application -> Domain. Infrastructure -> Application. Api -> both.

Did Student first all the way through so I have something to copy for Course.

## What it does

A student can do many courses and a course has many students. The link is an `Enrolment` row which also stores when they enrolled. DB is `EnrolmentsDb` on localhost.

## Todo

Course:
- [x] `Course` entity (Id, Code, Title, Credits)
- [x] `CreateCourseRequest`, `UpdateCourseRequest`, `CourseResponse`
- [ ] `ICourseRepository` + `CourseRepository`
- [ ] `ICourseService` + `CourseService`
- [ ] register them in both `DependencyInjection.cs` files
- [ ] `CourseController` CRUD

Enrolments:
- [x] `Enrolment` entity - StudentId, CourseId, EnrolledOn, no Id
- [x] `Enrolments` list on Student and Course
- [x] DbSets in AppDbContext
- [x] OnModelCreating - composite key (StudentId, CourseId), both relationships, unique Code
- [x] migration InitialCreate
- [ ] database update + check the Enrolments table in SSMS
- [ ] `IEnrolmentRepository` + `EnrolmentRepository`, `IEnrolmentService` + `EnrolmentService`
- [ ] POST `/api/student/{studentId}/courses/{courseId}` - enrol (set EnrolledOn on the server)
- [ ] DELETE `/api/student/{studentId}/courses/{courseId}` - unenrol
- [ ] GET `/api/student/{id}/courses`
- [ ] GET `/api/course/{id}/students`
- [ ] test it all in the .http file

## Stuff that should fail properly

- [ ] enrol a student/course that doesn't exist -> 404
- [ ] enrol the same student on the same course twice -> 409 (not a 500)
- [ ] unenrol someone who isn't enrolled -> 404
- [ ] 2 courses with the same code -> 409
- [ ] missing field -> 400
- [ ] delete a student that has enrolments - went with cascade for now, maybe change to restrict + 409 like session 07

## Questions I should be able to answer

- why does many-to-many need a 3rd table?
- why make Enrolment myself instead of letting EF do the hidden join table?
- why is the repo interface in Application but the class in Infrastructure?
- why is the migration in Infrastructure but the startup project is Api?
- follow a POST to enrol from the controller down to SQL and back
- where is AddDbContext called now and what lifetime is it?
- why is there an index on CourseId but not StudentId?

## Extra if time

- [ ] course list with a student count
- [ ] get one student with their courses
- [ ] MaxStudents on a course, 409 when it's full

## Run

```powershell
dotnet run --project Session08.StudentEnrolments/Enrolments.Api
```

http://localhost:5088

ef commands need both projects now (run from inside Session08.StudentEnrolments):

```powershell
dotnet ef migrations add <Name> --project Enrolments.Infrastructure --startup-project Enrolments.Api
dotnet ef database update --project Enrolments.Infrastructure --startup-project Enrolments.Api
```

## Notes

**Time taken:**

**What I built:**

**What I learned:**

**What confused me:**
