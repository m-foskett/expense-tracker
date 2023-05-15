using expense_tracker.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();
//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1lQ1NGaV1CX2BZfFl1QWlafk4BCV5EYF5SRHNeR11hSnpQd0diUXg=");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
