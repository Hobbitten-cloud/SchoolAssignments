using MudBlazor.Services;
using Pr13_SignalR.Components;
using Pr13_SignalR.Components.Hubs;

namespace Pr13_SignalR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
            builder.Services.AddMudServices(); // Add MudBlazor services
            builder.Services.AddSignalR(); // Add SignalR services

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
            app.MapHub<ChatHub>("/chathub"); // Map the SignalR hub

            app.Run();
        }
    }
}
