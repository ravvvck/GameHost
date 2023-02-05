using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Participant
{
    public class Participant
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
