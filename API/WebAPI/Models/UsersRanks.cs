using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("UsersRanks")]
    public class UsersRanks
    {
        public int UserId { get; set; }
        public int CurrentRank { get; set; }
        public int LastRank { get; set; }
    }
}
