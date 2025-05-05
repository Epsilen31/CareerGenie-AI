namespace CareerGenie.Entities.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public ResumeProfile? ResumeProfile { get; set; }
        public ICollection<JobApplication>? Applications { get; set; }
    }
}
