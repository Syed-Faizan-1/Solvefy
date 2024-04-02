using System;
using System.ComponentModel.DataAnnotations;

namespace Product_Inventory.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Available Quantity")]
        public int Quantity { get; set; }
    }
}
