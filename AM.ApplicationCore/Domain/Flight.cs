using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public DateTime Departure { get; set; }

        [Required(ErrorMessage = "Le champ Destination est requis.")]
        public string Destination { get; set; }


        public DateTime EffectiveArrival { get; set; }
        
        public int EstimatedDuration { get; set; }
        
        public DateTime FlightDate { get; set; }
        
        public int FlightId { get; set; }
        
        public virtual Plane Plane { get; set; }
        
        public string AirlineLogo { get; set; }
        
        public virtual IList<Passenger> Passengers { get; set; }

        [ForeignKey("Plane")]
        public int PlaneFk { get; set; }

        public string Pilot { get; set; }
    }
}