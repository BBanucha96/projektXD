using NuGet.Frameworks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("UsersMatches")]
    public class UsersMatches
    {
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public int BetScoreTeamA { get; set; }
        public int BetScoreTeamB { get; set; }
        public int MatchScore { get; set; }
        
    }
}
