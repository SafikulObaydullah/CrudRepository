using DirdGroupTest.Models;
using DirdGroupTest.Service.Repository;
using DirdGroupTest.Service.ServiceRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
//builder.Services.AddControllers();
builder.Services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
{
   builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));


//builder.RegisterType<Bonus>().As<IBonus>();
//builder.
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();

app.Run();
