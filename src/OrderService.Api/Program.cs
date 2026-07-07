using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using OrderService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// EF Core DbContext
var connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? "server=host.docker.internal;port=3306;user=root;password=devpass;database=orders_db;";
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

// Add MassTransit (RabbitMQ)
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetValue<string>("RabbitMQ:Host") ?? "rabbitmq", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

var app = builder.Build();
app.MapControllers();
app.Run();
