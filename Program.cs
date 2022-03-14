using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RdsPostgreSqlAwsIamAuthenticationDotNet6Demo.Data;
using RdsPostgreSqlAwsIamAuthenticationDotNet6Demo.Extensions;
using RdsPostgreSqlAwsIamAuthenticationDotNet6Demo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DemoDbContext>(options =>
    options.UseNpgsql(connectionString, npgsqlOption => { npgsqlOption.UseAwsIamAuthentication(); }));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<DemoDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MigrateDbOnStartup();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

