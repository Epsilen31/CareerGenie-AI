namespace CareerGenie.Entities.Entities
{
    public class ResumeEmbedding
    {
        public Guid Id { get; set; }
        public Guid ResumeProfileId { get; set; }
        public string? VectorId { get; set; }
        public ResumeProfile? ResumeProfile { get; set; }
    }
}
