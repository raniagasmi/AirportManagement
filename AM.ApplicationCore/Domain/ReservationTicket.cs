using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class ReservationTicket
    {
        public DateTime dateRes { get; set; }
        
        public float prix { get; set; }

        public virtual Passenger passenger { get; set; }

        public virtual Ticket ticket { get; set; }
        
        [ForeignKey("ticket")]
        public int TicketFK { get; set; }

        [ForeignKey("passenger")]
        public string PassengerFK { get; set; }


    }
}
