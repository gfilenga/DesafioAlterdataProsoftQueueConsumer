using DevListSyncQueueWorker.Models;

namespace DevListSyncQueueWorker.Services
{
    public interface IDevListSyncService
    {
        void CreateDev(Developer developer);
        void UpdateDev(Developer developer);
    }
}
