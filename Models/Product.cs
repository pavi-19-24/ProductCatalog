using System.ComponentModel.DataAnnotations;

namespace Catalog.Web.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Range(0, 99999)]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; } // "Dress" or "Shoe"

        [StringLength(200)]
        public string ImageUrl { get; set; }
    }
}
