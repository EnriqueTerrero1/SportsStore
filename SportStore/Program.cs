using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using SportStore.Controllers;
using SportStore.Models;
using Microsoft.AspNetCore.Identity;
using SportStore.Components;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionForIdentity")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
builder.Services.AddAutoMapper(typeof(Program));






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
app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=List}/{currentPageIndex?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=List}/{currentCategory?}");



app.Run();
