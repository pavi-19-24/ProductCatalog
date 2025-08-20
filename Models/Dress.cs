using System.ComponentModel.DataAnnotations;

namespace Catalog.Web.Models
{
    public class Dress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Size { get; set; }

        [Range(0, 99999)]
        public decimal Price { get; set; }

        [StringLength(200)]
        public string Color { get; set; }
    }
}
