using System.ComponentModel.DataAnnotations;

namespace Catalog.Web.Models
{
    public class AttributeDefinition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string DataType { get; set; } // e.g. "string", "number", etc.

        // FIXED: Changed from `object` to `int`
        public int SortOrder { get; set; }
    }
}
