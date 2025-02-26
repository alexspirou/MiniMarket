using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserService.EfCore;

var builder = WebApplication.CreateBuilder(args);
var rabbitMqHost = builder.Configuration["RABBITMQ_HOST"] ?? "localhost";

// Add MassTransit
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host($"rabbitmq://{rabbitMqHost}", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});
// Add services to the container.
// Register AppDbContext with SQL Server
var connectionString = builder.Configuration.GetConnectionString("MiniMarketDb");
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
