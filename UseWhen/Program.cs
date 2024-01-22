

var builder = WebApplication.CreateBuilder();
var app = builder.Build();


app.UseWhen(
    context => context.Request.Path == "/time",
    appBuilder =>
    {
        var time = DateTime.Now.ToShortTimeString();


        appBuilder.Use(async(context, next) =>
        {
            var time = DateTime.Now.ToShortTimeString();
            Console.WriteLine($"Time now: {time}");
            await next();
        });

        appBuilder.Run(async context => {
            await context.Response.WriteAsync($"Time req: {time}");
        }); 

    });
app.Run(async context =>
{
    await context.Response.WriteAsync("Default");
});
app.Run();
