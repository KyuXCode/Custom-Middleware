namespace Web;
using Web.Middleware;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Not Authorized!");

        app.UseMyMiddleware();

        app.Run(async context => {
            await context.Response.WriteAsync("Authorized!");
        });

        app.Run();
    }
}
