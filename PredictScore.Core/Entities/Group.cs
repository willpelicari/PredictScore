using System.ComponentModel.DataAnnotations.Schema;

namespace PredictScore.Core.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        [ForeignKey("OwnerId")]
        public required Player Owner { get; set; }
        public int OwnerId { get; set; }

        public ICollection<PredictionSeason>? Seasons { get; set; }
        public ICollection<Player>? Players { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastModificationDateTime { get; set; } = DateTime.Now;
    }
}
