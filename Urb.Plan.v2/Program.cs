using Microsoft.EntityFrameworkCore;
using Urb.Domain.Urb.DataConext;
using Microsoft.AspNetCore.Identity;

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
//builder.Services
    .AddEntityFrameworkStores<MainDataContext>()
    .AddEntityFrameworkStores<UserTokenDataContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
