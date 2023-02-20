using DevListSyncQueueWorker.Interfaces;
using DevListSyncQueueWorker.Models;

namespace DevListSyncQueueWorker.Services
{
    public class DevListSyncService : IDevListSyncService
    {
        private readonly IExternalApi _externalApi;

        public DevListSyncService(IExternalApi externalApi)
        {
            _externalApi = externalApi;
        }

        public async void CreateDev(Developer developer)
        {
            try
            {
                await _externalApi.CreateDev(developer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void UpdateDev(Developer developer)
        {
            try
            {
                await _externalApi.UpdateDev(developer);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
