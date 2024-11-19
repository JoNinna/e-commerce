using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DoorDash.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public required string StoreName { get; set; }
        public required string StoreAddress { get; set; }
        public required string StoreContactNumber { get; set; }

        // Navigation property to Product that creates a one-to-many relationship between Store and Product
        // The many to many relationship is also definded in the Product file, having a store type
        // Relationship is defined in the DbContext file under Data folder
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
