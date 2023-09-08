using StudentAttendanceManagement.Repositories;
using StudentAttendanceManagement.Helpers;
using StudentAttendanceManagement.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//=============SETUP CONNECTION DB========================
// Add services to the container.
var services = builder.Services;
var env = builder.Environment;

services.AddCors();
services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    // ignore omitted parameters on models to enable optional params (e.g. User update)
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// configure strongly typed settings object
services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

// configure DI for application services
services.AddSingleton<DataContext>();

//Configure Service
services.AddScoped<IStudentRepository, StudentsRepository>();
services.AddScoped<IStudentsService, StudentsService>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ensure database and tables exist
// SETUP CONNECT
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    await context.Init();
}

{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.MapControllers();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
