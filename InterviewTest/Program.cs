using AutoMapper;
using InterviewTest.AutoMapperRules.Profiles;
using InterviewTest.DB;
using InterviewTest.DI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();
//Adding the dependency injection info
builder.Services.AddDependencyInjection();


builder.Services.AddDbContext<InterviewTestDbContext>(OptionalAttribute =>
{
    OptionalAttribute.UseSqlServer(builder.Configuration.GetSection("Database").GetValue<string>("ConnectionString"));
});

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperGlobalProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper.ConfigurationProvider);
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// Configure caching for the List endpoint
app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action}",
    defaults: new { action = "Index" }
).WithMetadata(new ResponseCacheAttribute
{
    Duration = 60,
    VaryByQueryKeys = new[] { "*" } // Cache variant to all query parameters
});

app.Run();
