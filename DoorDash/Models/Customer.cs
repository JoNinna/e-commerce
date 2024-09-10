using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DoorDash.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }

        // Navigation property, Establishes a one-to-many relationship, where a customer can have multiple orders.
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
