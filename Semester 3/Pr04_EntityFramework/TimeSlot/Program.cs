using Microsoft.EntityFrameworkCore;
using TimeSlot.Data;
using TimeSlot.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TimeSlotContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection"));
});

builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<RoomRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Bookings}/{action=Index}/{id?}");

app.Run();
