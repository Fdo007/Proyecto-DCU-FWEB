using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proyecto_DCU_FWEB.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_DCU_FWEB.Helpers;
using Proyecto_DCU_FWEB.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AplicacionDBContextConnection") ?? throw new InvalidOperationException("Connection string 'AplicacionDBContextConnection' not found.");

builder.Services.AddDbContext<AplicacionDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AplicacionUsuario>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AplicacionDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<PathProvider>();
builder.Services.AddSingleton<HelperUploadFiles>();
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
