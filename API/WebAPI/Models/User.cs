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
        [Column("EmailAdress")]
        public string EmailAddress { get; set; }
        public string Rank { get; set; }
        public string Type { get; set; }

    }
}
