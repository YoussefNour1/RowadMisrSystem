using Microsoft.EntityFrameworkCore;
using RowadMisrSystem.Contexts;
using RowadMisrSystem.Extensions;
using RowadMisrSystem.Interfaces;
using RowadMisrSystem.Repositories;
using RowadMisrSystem.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddDbContext<RowadDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddServicesAndRepositories();
var app = builder.Build();

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
