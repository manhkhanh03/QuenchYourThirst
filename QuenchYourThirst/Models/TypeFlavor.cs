using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("type_flavors")]
    public class TypeFlavor
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
    }
}
