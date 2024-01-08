using LoginUsingMiddleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseLoginMiddleware();

app.Run(async (HttpContext httpContext) =>
{
    httpContext.Response.StatusCode = 200;
    await httpContext.Response.WriteAsync("No response.");
});

app.Run();