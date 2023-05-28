using System.Collections.Generic;
using DataAccess;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UseCases;
using UseCases.Interfaces;
using UseCases.UseCaseInterface;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Dependency Injection for DataAccess
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//Dependency Injection for UseCases and repositories
builder.Services.AddTransient<IViewCategories, ViewCategories>();
builder.Services.AddTransient<IAddCategory, AddCategory>();
builder.Services.AddTransient<IEditCategory, EditCategory>();
builder.Services.AddTransient<IGetCategoryById, GetCategoryById>();
builder.Services.AddTransient<IDeleteCategory, DeleteCategory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
