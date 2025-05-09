using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public int id { get; set; }
        public string destination { get; set; }
        public string classe { get; set; }

        public virtual IList <ReservationTicket> reservation { get; set; }

    }
}
