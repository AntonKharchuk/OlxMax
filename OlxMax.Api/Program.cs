using Microsoft.EntityFrameworkCore;

using OlxMax.Api.Middleware;
using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Mapper;

using OlxMax.Dal.Configs;
using OlxMax.Business.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<DefaultAppDbContext>(options =>
//    options.UseSqlServer(connectionString));

var connectionString = builder.Configuration.GetConnectionString("OnStartupCreation");

builder.Services.AddDbContext<DbContexOnStartUpCreation>(options =>
    options.UseSqlite(connectionString)); 


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();

builder.Services.AddCustomServices();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();


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
