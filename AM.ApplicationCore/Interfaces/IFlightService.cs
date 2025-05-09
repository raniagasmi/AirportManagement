using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public  interface IFlightService : IService<Flight>
    {
        public IEnumerable<DateTime> GetFlightdates(string destination);
        
        public void ShowFlightDetails(Plane plane);
        
        public int ProgrammedFlightNumber(DateTime startDate);
        
        public double DurationAverage(string destination);
        
        public IEnumerable<Flight> OrderedDurationFlights();
        
        public IEnumerable<Traveller> SeniorTravellers(Flight flight);
        
        public IEnumerable< IGrouping<string, Flight>> DestinationGroupedFlights();
        
        public void DestinationGroupedF();

        public IEnumerable<Flight> GetFlightOrderedBYDepartureDate(int LastPlane);

        public IEnumerable<Passenger> GetPassengersByPlaneAndDate(Plane plane, DateTime date);

        public bool CanReserveSeats(Flight flight, int seatCount);

        public IEnumerable<Passenger> GetStaffByFlightId(int flightId);

        public int GetPassengerCountByFlightDate(DateTime startDate, DateTime endDate);

        public IEnumerable<Flight> SortFlights();
    }
}
