using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{

    [Table("menu")]
    public class Menu
    {
        [Key]
        public int id { get; set; }
        public string? menuName { get; set; }
        public bool? isActive { get; set; }
        public string? controllerName { get; set; }
        public string? actionName { get; set; }
        public int levels { get; set; }
        public int parentID { get; set; }
        public string? link { get; set; }
        public int menuOrder { get; set; }
        public int position { get; set; }
    }

}

