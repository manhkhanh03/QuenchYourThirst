using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("Services")]
    public class Services
    {
        [Key]
        public int MenuID { get; set; }
        public int Level { get; set; }
        public int MenuOrder { get; set; }
        public string? Contents { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Color { get; set; }
    }
}
