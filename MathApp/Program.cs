var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    if (context.Request.Method == "GET")
    {
        if(context.Request.Query.ContainsKey("firstNumber"))
        {
            if(context.Request.Query.ContainsKey("secondNumber"))
            {
                if(context.Request.Query.ContainsKey("operation"))
                {
                    string operation = context.Request.Query["operation"];

                    if(operation == "+")
                    {
                        string strNum1 = context.Request.Query["firstNumber"];
                        string strNum2 = context.Request.Query["secondNumber"];

                        int num1 = Convert.ToInt32(strNum1);
                        int num2 = Convert.ToInt32(strNum2);

                        await context.Response.WriteAsync($"{num1 + num2}");

                    }

                    else if (operation == "-")
                    {
                        string strNum1 = context.Request.Query["firstNumber"];
                        string strNum2 = context.Request.Query["secondNumber"];

                        int num1 = Convert.ToInt32(strNum1);
                        int num2 = Convert.ToInt32(strNum2);

                        await context.Response.WriteAsync($"{num1 - num2}");

                    }

                    else if (operation == "*")
                    {
                        string strNum1 = context.Request.Query["firstNumber"];
                        string strNum2 = context.Request.Query["secondNumber"];

                        int num1 = Convert.ToInt32(strNum1);
                        int num2 = Convert.ToInt32(strNum2);

                        await context.Response.WriteAsync($"{num1 * num2}");

                    }

                    else if (operation == "/")
                    {
                        string strNum1 = context.Request.Query["firstNumber"];
                        string strNum2 = context.Request.Query["secondNumber"];

                        int num1 = Convert.ToInt32(strNum1);
                        int num2 = Convert.ToInt32(strNum2);



                        await context.Response.WriteAsync($"{num1 / num2}");

                    }

                    else if (operation == "%")
                    {
                        string strNum1 = context.Request.Query["firstNumber"];
                        string strNum2 = context.Request.Query["secondNumber"];

                        int num1 = Convert.ToInt32(strNum1);
                        int num2 = Convert.ToInt32(strNum2);



                        await context.Response.WriteAsync($"{num1 % num2}");

                    }
                }
            }
        }
    }
});

app.Run();
