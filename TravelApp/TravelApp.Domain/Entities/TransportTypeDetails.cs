using System.Collections.Generic;

namespace TravelApp.Domain.Entities
{
    public class TransportTypeDetails : BaseEntity
    {
        public string TransportNumber { get; set; }

        public bool IsActive { get; set; }

        public List<FareDetails> FareDetails { get; set; }

        public TransportType TransportType { get; set; }
    }
}
