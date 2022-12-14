using Microsoft.EntityFrameworkCore;
using IvyGame.Data;
using Microsoft.AspNetCore.Identity;
using IvyGame.Models.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication()
    .AddJwtBearer(options =>
    {
        var signingKey = Convert.FromBase64String(builder.Configuration["Jwt:SigningSecret"]);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(signingKey)
        };
    });


//var connectionString = builder.Configuration.GetConnectionString("IvyGameContextConnection") ?? throw new InvalidOperationException("Connection string 'IvyGameContextConnection' not found.");

/*builder.Services.AddDbContext<IvyGameContext>(options =>
    options.UseSqlServer(connectionString));;*/

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IvyGameContext>(); ;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IvyGameContext>
    (options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")));

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;

    //options.ApiVersionReader = new HeaderApiVersionReader("X-Version");

    /* options.ApiVersionReader = ApiVersionReader.Combine(
         new HeaderApiVersionReader("X-Version"),
         new QueryStringApiVersionReader("v")
    );*/
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\nExample: 'Bearer abc123'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
         {
            new OpenApiSecurityScheme
               {
                  Reference = new OpenApiReference
                     {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                      },
                      Scheme = "oauth2",
                      Name = "Bearer",
                      In = ParameterLocation.Header,
                },
                new List<string>()
            }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";// Ivy Game.xml

    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
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
app.UseAuthentication(); ;

app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.SwaggerEndpoint(
       "/swagger/v1/swagger.json",
       "IvyGAme API");
});
app.MapControllerRoute(
    name: "highscores",
    pattern: "highscores/new",
    defaults: new { controller = "HighScores", action = "Create" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
