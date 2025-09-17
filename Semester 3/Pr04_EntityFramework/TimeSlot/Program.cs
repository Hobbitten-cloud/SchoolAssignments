using Microsoft.EntityFrameworkCore;
using TimeSlot.Data;
using TimeSlot.Models;
using TimeSlot.Persistence;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TimeSlotContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection"));
});

builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<RoomRepository>();

builder.Services.AddDefaultIdentity<ApplicationUser>
    (
        options => options.SignIn.RequireConfirmedAccount = false
    )
    .AddEntityFrameworkStores<TimeSlotContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Bookings}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
