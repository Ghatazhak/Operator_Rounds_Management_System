using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Operator_Rounds_Management_System.Data;
using Operator_Rounds_Management_System.Models;
using Operator_Rounds_Management_System.Services;

var builder = WebApplication.CreateBuilder(args);


// Had to add this so postgresql would accept DateTime.
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var connectionString = builder.Configuration.GetSection("pgSettings")["pgConnection"];

/// Here for the record.
//"pgSettings": {
//    "pgConnection": "Server=localhost;Port=5432;Database=ORMSDB;User Id=postgres;Password=password;"
//}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddDefaultUI().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();


// Original befor adding roles.
//builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

// Register my custom DataService class
builder.Services.AddScoped<DataService>();
builder.Services.AddScoped<IEmailSender, EmailService>();


var app = builder.Build();

// Call my custom data service.
var dataService = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataService>();

await dataService.ManageDataAsync();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();




app.Run();
