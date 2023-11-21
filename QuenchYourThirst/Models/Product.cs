using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using QuenchYourThirst.Utilities;
using System.Globalization;

namespace QuenchYourThirst.Models
{
    [Table("products")]
    public class Product
    {
        public Product() {
			created_at = DateTime.ParseExact(Functions.getCurrentDate(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
		}
        [Key]
        public long id { get; set; }
        [ForeignKey("StatusProduct")]
        public long status_product_id { get; set; }
        [ForeignKey("ProductCategory")]
        public long product_category_id { get; set; }
        public string name { get; set; }
        public string? description {  get; set; }
        public long quantity { get; set; }
        public DateTime? created_at { get; set; }


        //[JsonIgnore]
        //public ICollection<ProductSizeFlavor> ProductSizeFlavor { get; set; }
        //public ICollection<ProductImage> ProductImage { get; set; }
        //public StatusProduct StatusProduct { get; set; }
        //public ProductCategory ProductCategory { get; set; }

    }
}
