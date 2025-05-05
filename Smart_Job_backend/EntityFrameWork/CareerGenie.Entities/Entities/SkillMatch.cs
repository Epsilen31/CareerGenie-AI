namespace CareerGenie.Entities.Entities
{
    public class SkillMatch
    {
        public Guid Id { get; set; }
        public Guid ResumeProfileId { get; set; }
        public Guid JobId { get; set; }
        public float MatchScore { get; set; }

        public ResumeProfile? ResumeProfile { get; set; }
        public Job? Job { get; set; }
    }
}
