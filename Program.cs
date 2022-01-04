using ConsumerCellular.NET.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (builder.Environment.IsDevelopment())
{
    // EF Core Command:
    //scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlServer -connection "Server=localhost\SQLEXPRESS;Database=sqldb-consumercellular;Trusted_Connection=True;” -OutputDir Models
    
    //Connects to local SQL Server db in development mode
    builder.Services.AddDbContext<ConsumerCellularContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConsumerCellularContext")));
}
else
{
    //TODO: Add Azure Key Vault to Store Secrets
    //builder.Configuration.AddAzureKeyVault(new Uri(Environment.GetEnvironmentVariable("VaultUri")), new DefaultAzureCredential());

    //TODO: Connects to prod Azure SQL Database in not development mode
    //builder.Services.AddDbContext<SyndicatorContext>(options =>
    //    options.UseSqlServer(builder.Configuration.GetConnectionString("SyndicatorContext")));
}

// Add API Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();