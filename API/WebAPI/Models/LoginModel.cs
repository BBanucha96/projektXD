using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class LoginModel
    {
        [Required]
        public string EmailAdress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
