using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

Dictionary<string,StringValues> countries = new Dictionary<string,StringValues>();

countries.Add("1","Pakistan");
countries.Add("2","Canada");
countries.Add("3","United Kingdom");
countries.Add("4","United States");
countries.Add("5","India");

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("countries", async (context) =>
    {
        context.Response.StatusCode = 200;

        foreach (var country in countries)
        {
            await context.Response.WriteAsync($"{country.Key}, {country.Value}\n"); 
        }

    });
    
    endpoints.MapGet("countries/{countryId:range(1,5):max(100)}", async (context) =>
    {
        
        string? countryId = Convert.ToString(context.Request.RouteValues["countryId"]);

        if (countries.ContainsKey(countryId))
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(countries[countryId]);
        }

        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Couldnot find the Desired Country");
        }
        
    });
    
    endpoints.MapGet("countries/{countryId}", async (context) =>
    {
        string? countryId = Convert.ToString(context.Request.RouteValues["countryId"]);
        int id = Convert.ToInt32(countryId);

        if(id <= 0 )
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("[ No Country ]");
        }

        else if(id >5 && id < 100 )
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("[ No Country ]");
        }
        
        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("The CountryID should be between 1 and 100");
        }

    });

});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request Recieved at {context.Request.Path}");
});

app.Run();
