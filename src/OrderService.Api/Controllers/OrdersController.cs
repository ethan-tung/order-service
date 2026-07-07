using Microsoft.AspNetCore.Mvc;
using OrderService.Domain;
using OrderService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderDbContext _db;
    public OrdersController(OrderDbContext db) => _db = db;

    [HttpGet]
    public async Task<IEnumerable<Order>> Get() => await _db.Orders.ToListAsync();

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto dto)
    {
        var order = new Order { Id = Guid.NewGuid(), CustomerId = dto.CustomerId, Status = "Created", CreatedAt = DateTime.UtcNow };
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }
}

public record CreateOrderDto(Guid CustomerId);
