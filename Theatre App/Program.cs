using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Theatre_App.Data;
using Theatre_App.Repository.ItemsRepo;
using Theatre_App.Repository.UserRepo;
using Theatre_App.Service.AuthServices;
using Theatre_App.Service.ItemServices;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Add DI 
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IItemsRepo, ItemsRepo>();

var connectionString = Env.GetString("DB_CONNECTION");

// Configure the database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTravel",
        policy => policy
        .WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        );


});

var app = builder.Build();
app.UseCors("AllowTravel");
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
