using System.Collections.Generic;
using DataAccess;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UseCases;
using UseCases.Interfaces;
using UseCases.Repository;
using UseCases.UseCaseInterface;
using UseCases.UseCaseProduct;
using UseCases.UsecaseProductInterface;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Dependency Injection for DataAccess
//Category
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//Transaction
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

//Dependency Injection for UseCases and repositories
//Category
builder.Services.AddTransient<IViewCategories, ViewCategories>();
builder.Services.AddTransient<IAddCategory, AddCategory>();
builder.Services.AddTransient<IEditCategory, EditCategory>();
builder.Services.AddTransient<IGetCategoryById, GetCategoryById>();
builder.Services.AddTransient<IDeleteCategory, DeleteCategory>();
//Product
builder.Services.AddTransient<IViewProducts, ViewProducts>();
builder.Services.AddTransient<IAddProduct, AddProduct>();
builder.Services.AddTransient<IEditProduct, EditProduct>();
builder.Services.AddTransient<IGetProductById, GetProductById>();
builder.Services.AddTransient<IDeleteProduct, DeleteProduct>();

builder.Services.AddTransient<IViewProductsByCategoryId, ViewProductsByCategoryId>();
builder.Services.AddTransient<ISellProduct, SellProduct>();

builder.Services.AddTransient<IRecordTransaction, RecordTransaction>();
builder.Services.AddTransient<IGetTodayTransaction, GetTodayTransaction>();





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
