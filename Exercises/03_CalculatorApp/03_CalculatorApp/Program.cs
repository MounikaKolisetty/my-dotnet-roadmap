var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    string firstNumber = "";
    string secondNumber = "";
    string operation = "";
    int val = 0;
    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("firstNumber"))
        {
            firstNumber = context.Request.Query["firstNumber"];
        }
        else
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'firstNumber'");
        }

        if (context.Request.Query.ContainsKey("secondNumber"))
        {
            secondNumber = context.Request.Query["secondNumber"];
        }
        else
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'secondNumber'");
        }

        if (context.Request.Query.ContainsKey("operation"))
            operation = context.Request.Query["operation"];

        switch (operation)
        {
            case "add":
                val = int.Parse(firstNumber) + int.Parse(secondNumber);
                break;
            case "subtract":
                val = int.Parse(firstNumber) - int.Parse(secondNumber);
                break;
            case "multiply":
                val = int.Parse(firstNumber) * int.Parse(secondNumber);
                break;
            case "divide":
                val = int.Parse(firstNumber) / int.Parse(secondNumber);
                break;
            case "reminder":
                val = int.Parse(firstNumber) % int.Parse(secondNumber);
                break;
            default:
                if (context.Response.StatusCode == 200)
                    context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'operation'");
                return;

        }
        await context.Response.WriteAsync(val.ToString());
    }
});


app.Run();
