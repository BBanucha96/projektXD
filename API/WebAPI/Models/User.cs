using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("UserId")]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAdress { get; set; }
        public string Rank { get; set; }
        public string Type { get; set; }

    }
}
