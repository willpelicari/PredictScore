using System.ComponentModel.DataAnnotations.Schema;

namespace PredictScore.Core.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Acronym { get; set; }

        public Sport? Sport { get; set; }
        public int? SportId { get; set;}
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastModificationDateTime { get; set; } = DateTime.Now;
    }
}
