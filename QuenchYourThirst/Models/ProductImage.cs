using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("product_images")]
    public class ProductImage
    {
        [Key]
        public long id { get; set; }
        [ForeignKey("Product")]
        public long product_id { get; set; }
        public string url { get; set; }
    }
}
