using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DoorDash.Models
{
    public class Product //once the customer make the selection of items we wants to buy from the app
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductInStock { get; set; }

        // Navigation property that links the Product entity to the Store entity
        // Defines a property Store of type store
        // Many-to-Many relationship: A product can belong to many stores
        public List<Store> Stores { get; set; } = new List<Store>();
    }
}
