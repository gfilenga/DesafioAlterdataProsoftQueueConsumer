using DevListSyncQueueWorker.Models;

namespace DevListSyncQueueWorker.DTOs
{
    public class Message
    {
        public string Action { get; set; }
        public Developer developer { get; set; }
    }
}
