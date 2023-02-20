namespace DevListSyncQueueWorker.Models
{
    public class Developer : Model
    {
        public string? Name { get; set; }
        public string? Avatar { get; set; }
        public string? Squad { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Linguagem { get; set; }

        public override void UpdateModel()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}