namespace CareerGenie.Services.DTOs
{
    public class ResumeEmbeddingDto
    {
        public Guid Id { get; set; }
        public Guid ResumeProfileId { get; set; }
        public string VectorId { get; set; } = string.Empty;
    }
}
