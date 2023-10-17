﻿namespace PredictScore.API.DTOs
{
    public class CreateGroupDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public IEnumerable<int>  MemberIds { get; set; }
    }
}
