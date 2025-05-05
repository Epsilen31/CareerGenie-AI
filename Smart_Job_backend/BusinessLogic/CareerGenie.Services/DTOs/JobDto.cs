namespace CareerGenie.Services.DTOs
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> SkillsRequired { get; set; } = new();
        public DateTime PostedOn { get; set; }
    }
}
