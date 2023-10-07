using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WEBAPI.Authorization;
using WEBAPI.Helpers;
using WEBAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}


app.Run();
