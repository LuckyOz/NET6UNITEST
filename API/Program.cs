
using API.Config;
using API.Dao;
using API.Helper;
using API.Models.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Config Env
string env = builder.Environment.EnvironmentName;
var appconfig = ConfigHelper.loadConfig<AppConfig>(new ConfigurationBuilder(), env);
builder.Services.AddSingleton<AppConfig>(appconfig);

//Config IP
builder.WebHost.UseUrls("http://*:" + appconfig.port);

//Config PostgreSQL Connection
builder.Services.AddDbContext<MahasiswaContext>(options =>
{
    options.UseNpgsql(appconfig.pgsql_url);
});

//Config Dependecy Injection
builder.Services.AddScoped<IMahasiswaServices, MahasiswaServices>();
builder.Services.AddScoped<IMahasiswaDao, MahasiswaDao>();

//Config Controller
builder.Services.AddControllers();

//Config Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
