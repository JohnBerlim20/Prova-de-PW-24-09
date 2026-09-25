using Microsoft.EntityFrameworkCore;
using ProjetoCadastroMVC.Data;
using ProjetoCadastroMVC.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = 
    builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(
        connectionString, 
        ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<ILivroRepository, LivroRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
