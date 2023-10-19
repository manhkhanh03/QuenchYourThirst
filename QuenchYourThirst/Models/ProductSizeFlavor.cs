using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("product_size_flavors")]
    public class ProductSizeFlavor
    {
        [Key]
        public long id { get; set; }
        [ForeignKey("Product")]
        public long product_id { get; set; }
        [ForeignKey("Size")]
        public long size_id { get; set; }
        [ForeignKey("Flavor")]
        public long flavor_id { get; set; }
        public decimal price { get; set; }
    }
}
