using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("status_products")]
    public class StatusProduct
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        //public ICollection<Product> Product { get; set; }
    }
}
