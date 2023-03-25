using Microsoft.EntityFrameworkCore;
using Cars_Catalog_Projekt.Data;
using Cars_Catalog_Projekt.Repositories;
using Cars_Catalog_Projekt.Repositories.Interfaces;
using Cars_Catalog_Projekt.Services;
using Cars_Catalog_Projekt.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("ApplicationContextConnection") ??
    throw new InvalidOperationException("Connection string 'ApplicationContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

//
builder.Services.AddDbContext<ApplicationContext>(c => c.UseMySQL(connectionString));

builder.Services.AddScoped<IVechicleRepository, VechicleRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

builder.Services.AddScoped<IVechicleService, VechicleService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IBrandService, BrandService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
