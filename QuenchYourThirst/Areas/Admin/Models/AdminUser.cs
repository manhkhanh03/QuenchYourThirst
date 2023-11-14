using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using QuenchYourThirst.Utilities;
using System.Globalization;

namespace QuenchYourThirst.Areas.Admin.Models
{
    [Table("users")]
    public class AdminUser
    {
        public AdminUser()
        {
            created_at = DateTime.ParseExact(Functions.getCurrentDate(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }
        [Key]
        public long id { get; set; }
        public string login_name { get; set; }
        public string? user_name { get; set; }
        [ForeignKey("Role")]
        public long role_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
        public string? img_user { get; set; }
        public DateTime? created_at { get; set; }
    }
}
