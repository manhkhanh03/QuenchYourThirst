using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("product_category")]
    public class ProductCategory
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public ICollection<Product> Product { get; set; }

    }
}
