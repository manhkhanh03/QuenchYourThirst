using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace QuenchYourThirst.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
     
}