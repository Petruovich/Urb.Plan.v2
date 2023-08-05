using Microsoft.EntityFrameworkCore;
using Urb.Domain.Urb.DataConext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Urb.Plan.v2;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<UserTokenDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
builder.Services.AddDbContext<MainDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
builder.Services.AddIdentityCore<IdentityUser/*, IdentityRole*/>(options =>
    {
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 8;
        options.SignIn.RequireConfirmedEmail = true;
        options.User.RequireUniqueEmail = true;
    })

    .AddEntityFrameworkStores<MainDataContext>()
    .AddEntityFrameworkStores<UserTokenDataContext>();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "MVCCallWebAPI", Version = "v2" });
});
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));







var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
    }
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "MVCCallWebAPI");
});
app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapRazorPages();

    app.Run();


