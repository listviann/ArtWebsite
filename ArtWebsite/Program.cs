using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ArtWebsite.Service;
using ArtWebsite.Domain;
using ArtWebsite.Domain.Entities;
using ArtWebsite.Domain.Repositories.Abstract;
using ArtWebsite.Domain.Repositories.EntityFramework;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Bind("Project", new Config());

builder.Services.AddTransient<IAuthorRepository, EFAuthorRepository>();
builder.Services.AddTransient<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddTransient<IPaintingRepository, EFPaintingRepository>();
builder.Services.AddTransient<IPageTextFieldRepository, EFPageTextFieldRepository>();
builder.Services.AddTransient<DataManager>();

builder.Services.AddDbContext<ArtWebsiteDbContext>(options => options.UseSqlServer(Config.ConnectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<ArtWebsiteDbContext>().AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "artWebsiteAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
}).AddSessionStateTempDataProvider();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "admin", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
