using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("flavors")]
    public class Flavor
    {
        [Key]
        public long id {  get; set; }
        public string name { get; set; }
        [ForeignKey("TypeFlavor")]
        public long type_flavor_id { get; set; }
        //public ICollection<ProductSizeFlavor> ProductSizeFlavor { get; set; }

    }
}
