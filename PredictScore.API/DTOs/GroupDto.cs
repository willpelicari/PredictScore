namespace PredictScore.API.DTOs
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public string GroupCreationDate { get; set; }
        public IEnumerable<SimplePlayerDto>  Members { get; set; }
    }
}
