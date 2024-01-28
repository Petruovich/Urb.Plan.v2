using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Urb.Plan.v2;
using Microsoft.AspNetCore.Hosting;
using Urb.Plan.v2.Mapper;
using Urb.Persistance.Urb.DataConext;
using Urb.Application.Urb.IServices;
using Urb.Plan.v2.Controllers;
using Urb.Infrastructure.Urb.Services;
using Urb.Application.App.Settings;
using Urb.Application.ComponentModels;
using Urb.Application.IComponentModels;
using Microsoft.AspNetCore.Authentication;
using Urb.Domain.Urb.Models;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<UserTokenDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddDbContext<MainDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
builder.Services.AddIdentityCore<User/*IdentityUser*//*, IdentityRole*/>(options =>
    {
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-.";
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 6;
        //options.SignIn.RequireConfirmedEmail = true;
        options.User.RequireUniqueEmail = true;
    })
    
    //.AddEntityFrameworkStores<MainDataContext>()
    .AddEntityFrameworkStores<UserTokenDataContext>()
    .AddSignInManager<SignInManager<User/*IdentityUser*/>>()
    .AddDefaultTokenProviders();
//builder.Services.AddControllers().
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
//builder.Services.AddSignInManager<IdentityUser, SignInManager<IdentityUser>>();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "MVCCallWebAPI", Version = "v2" });
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Pinus",
                      builder =>
                      {
                          builder.WithOrigins("https://red-pebble-049af5603.4.azurestaticapps.net/",
                              "http://localhost:5173/")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Urb.API", Version = "Test" });
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
            new string[] {}
        }
    });
});



builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserRegisterModel, UserRegisterModel>();
builder.Services.AddSingleton<ISystemClock, SystemClock>();
builder.Services.AddScoped<IBordService, BordService>();
builder.Services.AddScoped<User>();
//builder.Services.AddScoped<SignInManager<IdentityUser>>();
//builder.Services.AddScoped<UserService, IUserRegisterModel>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
    }
app.UseSwagger();
app.UseCors("Pinus");
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "MVCCallWebAPI");
});
app.UseStaticFiles();

    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();


