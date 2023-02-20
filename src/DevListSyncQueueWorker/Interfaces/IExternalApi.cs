using DevListSyncQueueWorker.Models;
using Refit;

namespace DevListSyncQueueWorker.Interfaces
{
    public interface IExternalApi
    {
        [Post("/DevTest/Dev")]
        Task CreateDev(Developer developer);

        [Put("/DevTest/Dev")]
        Task UpdateDev(Developer developer);
    }
}
