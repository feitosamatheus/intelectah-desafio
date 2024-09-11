using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Infrastructure.Services;
using ConcessionariaApp.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddHttpClient<ICepService, CepService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Define o caminho para a página de login
        options.LogoutPath = "/Account/Logout"; // Define o caminho para logout
        options.Cookie.HttpOnly = true; // Torna o cookie HttpOnly para maior segurança
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Usa cookies seguros em HTTPS
        options.Cookie.HttpOnly = true;
        options.Cookie.MaxAge = TimeSpan.FromDays(1);
    });

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
