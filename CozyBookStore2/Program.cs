using CozyBookStore2.Data;
using CozyBookStore2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add Controllers & Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // ✅ Required for Identity UI

// ✅ Configure Database
builder.Services.AddDbContext<ApplicationDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("mydb")));

// ✅ Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDb>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

var app = builder.Build();

// ✅ Middleware Configuration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// ✅ Enable Razor Pages & Controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");
app.MapRazorPages(); // ✅ This allows Razor Pages to work

app.Run();
