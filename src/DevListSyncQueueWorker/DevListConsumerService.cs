using Azure.Messaging.ServiceBus;
using DevListSyncQueueWorker.DTOs;
using DevListSyncQueueWorker.Services;
using DevListSyncQueueWorker.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DevListSyncQueueWorker
{
    public class DevListConsumerService : IHostedService
    {
        private readonly ServiceBusProcessor _processor;
        private readonly IDevListSyncService _syncService;
        private readonly IConfiguration _configuration;


        public DevListConsumerService(IDevListSyncService syncService, IConfiguration configuration)
        {
            _configuration = configuration;
            var serviceBusSettings = _configuration.GetSection("ServiceBusSettings").Get<ServiceBusSettings>();
            var client = new ServiceBusClient(serviceBusSettings.ConnectionString);
            _processor = client.CreateProcessor(serviceBusSettings.QueueName, new ServiceBusProcessorOptions());
            _processor.ProcessMessageAsync += ProcessMessageAsync;
            _processor.ProcessErrorAsync += args => Task.CompletedTask;
            _syncService = syncService;
        }

        private async Task ProcessMessageAsync(ProcessMessageEventArgs args)
        {
            try
            {
                var body = args.Message.Body.ToString();

                var message = JsonConvert.DeserializeObject<JObject>(body);

                var desearilizedMessage = JsonConvert.DeserializeObject<Message>(message.ToString());

                var action = message.SelectToken("Action");

                if (message != null &&
                    desearilizedMessage.developer != null && 
                    action != null)
                {
                    switch (action.ToString().ToUpper())
                    {
                        case "POST":
                            _syncService.CreateDev(desearilizedMessage.developer);
                            break;
                        case "PUT":
                            _syncService.UpdateDev(desearilizedMessage.developer);
                            break;
                    }
                }

                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return _processor.StartProcessingAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _processor.StopProcessingAsync(cancellationToken);
        }


    }
}
