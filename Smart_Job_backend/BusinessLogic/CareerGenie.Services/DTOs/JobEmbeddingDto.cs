namespace CareerGenie.Services.DTOs
{
    public class JobEmbeddingDto
    {
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public string VectorId { get; set; } = string.Empty;
    }
}
