namespace CareerGenie.Services.DTOs
{
    public class JobApplicationDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
        public DateTime AppliedOn { get; set; }
    }
}
