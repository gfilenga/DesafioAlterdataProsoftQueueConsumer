using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevListSyncQueueWorker.Settings
{
    public class ServiceBusSettings
    {

        public ServiceBusSettings(){}

        public ServiceBusSettings(string queueName, string connectionString)
        {
            QueueName = queueName;
            ConnectionString = connectionString;
        }

        public string QueueName { get; set; }
        public string ConnectionString { get; set; }
    }
}
