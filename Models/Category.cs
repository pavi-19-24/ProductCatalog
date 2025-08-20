using ProductCatalog.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Web.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Slug { get; set; }

        public ICollection<AttributeDefinition> Attributes { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
