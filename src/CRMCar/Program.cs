using CRMCar;
using CRMCar.Data;
using CRMCar.Repository;
using DocnetCorePractice;
using Microsoft.EntityFrameworkCore;
using Serilog;

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .WriteTo.File("logs/crmCar/log-.log", 
//        outputTemplate: "{Timestamp:o} [{Level:u3}] ({SourceContext}) {Message}{NewLine}{Exception}",
//        rollingInterval:RollingInterval.Day)
//    .MinimumLevel.Debug()
//    .CreateLogger();

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnectStrings");
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(connectionString);
//});

//builder.Services.AddScoped<IDbContext, AppDbContext>();

//DI
//builder.Services.AddScoped<ICarRepo, CarRepo>();

// Add services to the container.
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(option =>
//{
//    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "CRMCar.API", Version = "v2" });
//});

//var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//Car car = new Car();

//app.Run();

// new

var builder = WebApplication.CreateBuilder(args);

_ = builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
   _ = loggerConfiguration.ReadFrom.Configuration(builder.Configuration));

var startup = new Startup(builder, builder.Environment);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, builder.Environment);
app.Run();
