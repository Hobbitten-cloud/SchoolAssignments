using mvcRickAndMorty.Interfaces;
using mvcRickAndMorty.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Add the IHttpClientFactory service
        builder.Services.AddHttpClient();

        // You can also configure named clients
        builder.Services.AddHttpClient("RickAndMortyApi", client =>
        {
            client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
            // You can set other settings here (timeouts, headers, etc.)
        });

        builder.Services.AddScoped<IRickAndMortyHttpService, RickAndMortyHTTPService>();
        builder.Services.AddScoped<NasaHttpService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
