using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("UsersRanks")]
    public class UsersRanks
    {
        [Key]
        public int UsersRanksId { get; set; }
        public int UserId { get; set; }
        public int CurrentRank { get; set; }
        public int LastRank { get; set; }
    }
}
