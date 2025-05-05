namespace CareerGenie.Services.DTOs
{
    public class ResumeProfileDto
    {
        public Guid Id { get; set; }
        public string Skills { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public string ResumeUrl { get; set; } = string.Empty;
    }
}
