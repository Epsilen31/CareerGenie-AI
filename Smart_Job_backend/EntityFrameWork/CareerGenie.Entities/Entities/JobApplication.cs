namespace CareerGenie.Entities.Entities
{
    public class JobApplication
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
        public DateTime AppliedOn { get; set; } = DateTime.UtcNow;
        public User? User { get; set; }
        public Job? Job { get; set; }
    }
}
