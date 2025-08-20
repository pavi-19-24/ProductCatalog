namespace Catalog.Web.Models
{
    public class ProductAttributeValue
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AttributeDefinitionId { get; set; }

        public string ValueString { get; set; }
        public int? ValueInt { get; set; }
        public decimal? ValueDecimal { get; set; }
        public bool? ValueBool { get; set; }
        public DateTime? ValueDate { get; set; }
        public string ValueJson { get; set; }

        public Product Product { get; set; }
        public AttributeDefinition AttributeDefinition { get; set; }
    }
}
