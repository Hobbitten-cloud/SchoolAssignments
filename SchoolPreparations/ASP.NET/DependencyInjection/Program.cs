using DependencyInjection.Services;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();

            var app = builder.Build();

            app.Run();
        }
    }
}
