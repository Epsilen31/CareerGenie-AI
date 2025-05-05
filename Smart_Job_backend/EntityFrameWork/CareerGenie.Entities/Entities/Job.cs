namespace CareerGenie.Entities.Entities
{
    public class Job
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Company { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public ICollection<string>? SkillsRequired { get; set; }
        public DateTime PostedOn { get; set; }

        public ICollection<JobApplication>? Applications { get; set; }
    }
}
