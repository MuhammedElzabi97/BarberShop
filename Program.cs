using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebProjesi;
using WebProjesi.Data;
using WebProjesi.Data.Services;
using WebProjesi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register controllers with views.
builder.Services.AddControllersWithViews();

// Configure the database context.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

// Register application services.
builder.Services.AddScoped<ICalisanServices, CalisanService>();
builder.Services.AddScoped<IHizmetServices, HizmetService>();
builder.Services.AddScoped<IRandevuServices, RandevuService>();

// Configure Identity for authentication and authorization.
builder.Services.AddIdentity<Kullanici, IdentityRole>(options =>
{
    // Password options
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 0;

    // User sign-in options
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Build the application.
var app = builder.Build();

// Seed roles, users, and initial data.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<Kullanici>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await Rol.InitializeAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error seeding roles and users: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Use HTTP Strict Transport Security
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add authentication and authorization middleware.
app.UseAuthentication();
app.UseAuthorization();

// Configure endpoint routing.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application.
app.Run();
