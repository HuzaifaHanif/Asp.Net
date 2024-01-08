using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace LoginUsingMiddleware.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Method == "POST" )
            {
                StreamReader reader = new StreamReader(httpContext.Request.Body);
                string body = await reader.ReadToEndAsync();

                Dictionary<string, StringValues> QueryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

                if(QueryDict.ContainsKey("email"))
                {
                    string email = QueryDict["email"][0];

                    if(email == "admin@example.com")
                    {
                        if (QueryDict.ContainsKey("password"))
                        {
                            string password = QueryDict["password"][0];

                            if(password == "admin1234")
                            {
                                httpContext.Response.StatusCode = 200;
                                await httpContext.Response.WriteAsync("Successful Login!");
                            }

                            else
                            {
                                httpContext.Response.StatusCode = 400;
                                await httpContext.Response.WriteAsync("Invalid Login...");
                            }

                         }

                        else
                        {
                            httpContext.Response.StatusCode = 400;
                            await httpContext.Response.WriteAsync("Invalid input for password...");

                        }

                    }

                    else
                    {
                        httpContext.Response.StatusCode = 400;
                        await httpContext.Response.WriteAsync("Invalid Login...");
                    }
                }

                else
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid input for email...");
                    await httpContext.Response.WriteAsync("\nInvalid input for password...");
                }
            }

            else
            {
                await _next(httpContext);
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
