using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Entities
{
    public class MatchStatusConfig
    {
        public int Id { get; set; }
        public string Status { get; set; }

        //CB-10022023 Reference to FightMatch Table Many to One
        public virtual ICollection<FightMatch> FightMatches { get; set; }

        [Column("create_ts")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
