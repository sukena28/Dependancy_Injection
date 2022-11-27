using Dependency_Injection.Common.Configuration;
using Dependency_Injection.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
//Register DI 
builder.Services.AddServices();
builder.Services.AddFilters();
builder.Services.AddLogging();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler(logger);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
