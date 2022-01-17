using System.Collections.Generic;

namespace TravelApp.Domain.Entities
{
    public class TransportType : BaseEntity
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public List<TransportTypeDetails> TransportTypeDetails { get; set; }
    }
}
