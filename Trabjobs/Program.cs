using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trabjobs.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(Options =>
{
    Options.IdleTimeout = TimeSpan.FromSeconds(3600);
    Options.Cookie.HttpOnly = true;
    Options.Cookie.IsEssential = true;
});

//CONECTION DB
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DreamDbaseContext>(opt =>
        opt.UseSqlServer(
            builder.Configuration.GetConnectionString("CONECTA")
    )
);


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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
