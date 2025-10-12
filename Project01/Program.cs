using System.Xml.Linq;

namespace Project01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();

            //app.MapGet("/", () => "Hello World!");
            //app.MapGet("/{name}", async(context) =>
            //{
            //    var name = context.GetRouteValue("name");
            //    await context.Response.WriteAsync($"Hello {name}");
            //}); //dynamic segment

            app.MapControllerRoute(
                name: "default",
                pattern: "{Controller=Home}/{Action=Index}/{id?}"
                //defaults: new {Controller= "Home", Action = "Index"}
                );
            app.Run();
        }
    }
}  
