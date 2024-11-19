using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DoorDash.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public required string CustomerFirstName { get; set; }
        public required string CustomerLastName { get; set; }
        public required string CustomerEmail { get; set; }
        public required string CustomerPhoneNumber { get; set; }
        public required string CustomerAddress { get; set; }

        // Navigation property, Establishes a one-to-many relationship, where a customer can have multiple orders.
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
