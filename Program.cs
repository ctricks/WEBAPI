using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WEBAPI.Authorization;
using WEBAPI.Helpers;
using WEBAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{   // for development only
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"]
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWT Auth Sample",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer jhfdkj.jkdsakjdsa.jkdsajk\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    // use sql server db in production and sqlite db in development
    //if (env.IsProduction())
    //    services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase")));
    //else
    //    services.AddDbContext<DataContext, SqliteDataContext>();

    //For AzureConnection
    services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase")));

    services.AddCors();
    services.AddControllers();

    // configure automapper with all automapper profiles from this assembly
    services.AddAutoMapper(typeof(Program));

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IUserAdminService,UserAdminService>();
    services.AddScoped<IWalletTransactionsService, WalletTransactionsService>();
    services.AddScoped<IValidation, Validation>();
    services.AddScoped<IColorConfigService, ColorConfigService>();
    services.AddScoped<IMatchResultService, MatchResultService>();
    services.AddScoped<IMatchStatusService, MatchStatusService>();
    services.AddScoped<IFightMatchService, FightMatchService>();
    services.AddScoped<ITokenService, TokenService>();
    services.AddScoped<IBetTransactionService, BetTransactionService>();


    services.AddSwaggerGen(options =>
    {
        options.CustomSchemaIds(type => type.ToString());
    });
}


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    //dataContext.Database.EnsureDeleted();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//    app.UseDeveloperExceptionPage();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// configure HTTP request pipeline

// global cors policy
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000").AllowAnyMethod());

    // global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

    // custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();



app.Run();
