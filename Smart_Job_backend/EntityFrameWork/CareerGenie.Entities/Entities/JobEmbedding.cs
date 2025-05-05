namespace CareerGenie.Entities.Entities
{
    public class JobEmbedding
    {
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public string? VectorId { get; set; }
        public Job? Job { get; set; }
    }
}
