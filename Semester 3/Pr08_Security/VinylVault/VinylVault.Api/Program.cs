using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using VinylVault.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add controllers and configure JSON options
builder.Services.AddControllers();

//.AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.PropertyNamingPolicy = null;
//});

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Configure EF Core DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection"));
});

// Configure Identity and Authentication
builder.Services.AddAuthentication();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<DataContext>();

// Configure a specific CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy
        // Only allow these origins
        .WithOrigins("https://localhost:7280")
        // Only allow these request headers
        .WithHeaders("Content-Type", "Authorization", "Accept")
        // Only allow these HTTP methods
        .WithMethods("GET", "POST", "PUT", "DELETE");
    });
});
var app = builder.Build();

// Enable Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

// Identity and Authentication
app.MapIdentityApi<IdentityUser>();

// Apply the named CORS policy globally
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
app.MapControllers();
app.Run();