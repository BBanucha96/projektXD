using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Matches")]
    public class Matches
    {
        public int MatchId { get; set; }
        public int MatchLink { get; set; }
        public int DataStart { get; set; }
        public int DataEnd { get; set; }
    }
}
