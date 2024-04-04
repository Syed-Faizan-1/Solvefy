using System;
using System.ComponentModel.DataAnnotations;

namespace ProductInventory.Models
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
        [Display(Name = "Product Price")]
        [Range(0.01, double.MaxValue, ErrorMessage ="Price must be 0.01 or greater")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Available Quantity")]
        [Range(0, int.MaxValue, ErrorMessage ="Quantity must be zero or greater")]
        public int Quantity { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
