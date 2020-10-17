using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Matches")]
    public class Matches
    {
        [Key]
        public int MatchId { get; set; }
        public string MatchLink { get; set; }
        public string DataStart { get; set; }
        public string DataEnd { get; set; }
    }
}
