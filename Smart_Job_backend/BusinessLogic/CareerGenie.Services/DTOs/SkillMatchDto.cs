namespace CareerGenie.Services.DTOs
{
    public class SkillMatchDto
    {
        public Guid Id { get; set; }
        public Guid ResumeProfileId { get; set; }
        public Guid JobId { get; set; }
        public float MatchScore { get; set; }
    }
}
