using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        public long id { get; set; }
        [ForeignKey("StatusProduct")]
        public long status_product_id { get; set; }
        public string name { get; set; }
        public string? description {  get; set; }
        public long quantity { get; set; }
        public DateTime created_at { get; set; }
    }
}
