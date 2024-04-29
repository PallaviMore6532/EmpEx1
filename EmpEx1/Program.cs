using EmpEx1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddDbContext<DemoContext>(
	opt => opt.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("scon"))
	);
var app = builder.Build();


app.UseSession();
app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
