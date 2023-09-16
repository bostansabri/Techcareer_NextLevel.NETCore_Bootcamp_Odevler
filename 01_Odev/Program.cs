using Microsoft.EntityFrameworkCore;
using Odev1.AutoMapperProfile;
using Odev1.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NorthwindContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind")));

builder.Services.AddAutoMapper(typeof(Odev1Profile));

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
	pattern: "{controller=Employees}/{action=Index}/{id?}");

app.Run();
