using NuGet.Frameworks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("UsersMatches")]
    public class UsersMatches
    {
        [Key]
        public int UsersMatchesId { get; set; }
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public int BetScoreTeamA { get; set; }
        public int BetScoreTeamB { get; set; }
        public string MatchScore { get; set; }
        
    }
}
