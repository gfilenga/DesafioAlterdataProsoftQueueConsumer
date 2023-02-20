using DevListSyncQueueWorker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevListSyncQueueWorker.Models
{
    public abstract class Model : IModel
    {
        protected Model()
        {
            Id = Guid.NewGuid();
            CreatedAt= DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual void UpdateModel()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
