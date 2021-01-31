# AspNetCore-WebApiTemplate
## Tools and Frameworks Used
.NET Core 3.1  
ASP.NET Core - For building RESTful APIs  
Dapper - For data access  
AutoMapper - For mapping entity models to DTOs  
AutoWrapper - For handling request exceptions and consistent Http response format  
AutoWrapper.Server - For unwrapping the Result attribute from AutoWrapper's ApiResponse output  
Swashbuckle.AspNetCore - For secured API documentation  
FluentValidation.AspNetCore - For DTO validations  
Serilog.AspNetCore - For logging capabilities  
IdentityServer4.AccessTokenValidation - For JWT Authentication and Authorization handling  
Microsoft.Extensions.Http.Polly - For implementing HttpClient Resilience and Transient fault-handling  
AspNetCoreRateLimit - For controlling the rate of requests that clients can make to an external API based on IP address or client ID  
AspNetCore.Diagnostics.HealthChecks - For performing health checks  
Microsoft.AspNetCore.Diagnostics.HealthChecks - For getting the results of Health Checks in the application  
AspNetCore.HealthChecks.UI - For Health Status visualization  
xUnit and Moq - For unit testing

## Key Takeaways 
Configured Sample Code for database CRUD operations  
Configured Basic Data Access using Dapper  
Configured Logging using Serilog  
Configured AutoMapper for mapping entity models to DTOs  
Configured FluentValidation for DTO validations  
Configured AutoWrapper for handling request exceptions and consistent Http response format  
Configured AutoWrapper.Server for unwrapping the Result attribute from AutoWrapper's ApiResponse output  
Configured Swagger API Documentation  
Configured CORS  
Configured JWT Authorization and Validation  
Configured Sample Code for Requesting Client Credentials Token  
Configured Swagger to secure API documentation with Bearer Authorization  
Configured Sample Code for connecting Protected External APIs  
Configured Sample Code for implementing custom API Pagination  
Configured HttpClient Resilience and Transient fault-handling  
Configured Http Request Rate Limiter  
Configured HealthChecks and HealthChecksUI  
Configured Unit Test Project  
