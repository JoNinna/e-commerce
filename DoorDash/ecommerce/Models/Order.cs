using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DoorDash.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public required string Status { get; set; } // e.g., Pending, Completed, Cancelled
        public decimal TotalPrice { get; set; }
        
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
