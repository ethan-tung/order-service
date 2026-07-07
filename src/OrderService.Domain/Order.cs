using System;

namespace OrderService.Domain;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string Status { get; set; } = "New";
    public DateTime CreatedAt { get; set; }
}
