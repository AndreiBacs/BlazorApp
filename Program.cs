global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

using BlazorApp.Data;
using BlazorApp.Hubs;
using BlazorApp.Authentication;
using BlazorApp.Services;

using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddDbContext<HAMMERContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMudServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
    endpoints.MapHub<ChatHub>(ChatHub.HubUrl);
});

app.Run();
