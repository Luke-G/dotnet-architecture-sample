# dotnet-architecture-sample

Sample project using architecture discussed in this [Pluralsight course.](https://app.pluralsight.com/library/courses/architecting-asp-dot-net-core-applications-best-practices/).

Separated layers: API, Application, Domain, Infrastructure.

Using CQRS with MediatR.

This is an abstraction heavy approach and can be cut down to the needs of the application. The clean communication from the API to the application, exception handling and infrastructure injection would be great for any project, though abstracting data access into repositories may be an over-abstraction and create more work depending on the projects scale.

![image](https://user-images.githubusercontent.com/8474126/120468419-1d110780-c399-11eb-891a-16ecaee58f78.png)
