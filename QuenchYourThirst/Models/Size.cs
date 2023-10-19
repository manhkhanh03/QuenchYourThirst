using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("sizes")]
    public class Size
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string size { get; set; }
    }
}
