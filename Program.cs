using Microsoft.EntityFrameworkCore;
using ManagerPeople.Data;
using ManagerPeople.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ManagerPeopleContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ManagerPeopleContext") ?? throw new InvalidOperationException("Connection string 'ManagerPeopleContext' not found.")));

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddCustomService();

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