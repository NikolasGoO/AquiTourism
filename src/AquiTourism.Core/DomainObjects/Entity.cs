using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new int();
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = null;
            IsActive = true;
        }

        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
