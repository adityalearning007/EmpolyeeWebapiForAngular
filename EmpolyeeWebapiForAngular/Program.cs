using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CompanydbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("CompanyconnectionString")
        )
    );

var MyAllocationOrigins = "_nyAllocationOrigins";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(MyAllocationOrigins,
//        builder =>
//        {
//            alloAny
//             //builder.WithOrigins("http://localhost:4200", "https://localhost:7001")                         
//            .AllowAnyMethod()
//            .AllowCredentials()
//            .AllowAnyMethod();
//        });
//});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options=>options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
