using Pr06_API.Services;

namespace Pr06_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IRickAndMortyHttpService, RickAndMortyHttpService>();

            builder.Services.AddHttpClient("RickAndMortyJSON", (httpClient) =>
            {
                httpClient.BaseAddress = new Uri("https://rickandmortyapi.com/api");
            });

            //builder.Services.AddSingleton((ServiceProvider) => new HttpClient
            //(
            //    new SocketsHttpHandler
            //    {
            //        PooledConnectionLifetime = TimeSpan.FromMinutes(5)
            //    }
            //));

            var app = builder.Build();

            app.UseRouting();

            app.UseStaticFiles();

            app.MapControllerRoute(name: "default", pattern: "{controller=RickAndMorty}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
