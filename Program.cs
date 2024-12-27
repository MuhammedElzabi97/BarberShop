using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebProjesi;
using WebProjesi.Data;
using WebProjesi.Data.Services;
using WebProjesi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database context.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

builder.Services.AddScoped<ICalisanServices, CalisanService>();
builder.Services.AddScoped<IHizmetServices, HizmetService>();
builder.Services.AddScoped<IRandevuServices, RandevuService>();


// Configure Identity with password and user settings.
builder.Services.AddIdentity<Kullanici, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = true; // Require at least one digit
    options.Password.RequireNonAlphanumeric = true; // Require at least one special character
    options.Password.RequiredLength = 3; // Minimum password length
    options.Password.RequiredUniqueChars = 1; // Require unique characters in the password

    // User settings
    options.User.RequireUniqueEmail = true; // Ensure email uniqueness
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

// Seed roles, users, and initial data.

AddDbInitializer.Seed(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Use HTTP Strict Transport Security
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Ensure authentication is enabled
app.UseAuthorization();

// Map routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hizmet}/{action=Index}/{id?}");

app.Run();
 