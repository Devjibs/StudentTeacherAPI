using NLog;
using StudentTeacher.Extensions;
using StudentTeacher.Service.Services;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
LoggerManager logger = new LoggerManager();

builder.Services.ConfigureResponseCaching();

// Add services to the container.
builder.Services.RegisterDependencies();
builder.Services.ConfigureMapping();
builder.Services.ConfigureLoggerService();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();

builder.Services.ConfigureControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();   

app.UseAuthorization();

app.MapControllers();

app.Run();
