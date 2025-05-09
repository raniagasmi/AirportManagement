﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class FlightService : Service<Flight>, IFlightService
    {
        public List<Flight> Flights = new List<Flight>();

        public FlightService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool CanReserveSeats(Flight flight, int seatCount)
        {
            return flight.Plane.Capacity.HasValue && flight.Plane.Capacity.Value >= seatCount;
        }

        public void DestinationGroupedF()
        {
            var req = Flights.GroupBy(f => f.Destination);
            foreach (var item in req)
            {
                Console.WriteLine("destination: " + item.Key);
                foreach (var a in item)
                { Console.WriteLine("Décollage : " + a.FlightDate); }
            }

        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {

            //var req = from f in Flights
            //          group f by f.Destination;
            var req = Flights.GroupBy(f => f.Destination);
            foreach (var item in req)
            {
                Console.WriteLine("destination: " + item.Key);
                foreach (var a in item)
                { Console.WriteLine("Décollage : " + a.FlightDate); }
            }


            return req;
        }

        public double DurationAverage(string destination)
        {
           //var req = from flight in Flights
           //          where flight.Destination == destination
           //          select flight.EstimatedDuration;
           // return req.Average();
           return Flights.Where(a=> a.Destination == destination)
                .Select(f=>f.EstimatedDuration).Average();
        }

        public IEnumerable<DateTime> GetFlightdates(string destination)
        { 
           // List<DateTime> dates = new List<DateTime>();
            // Boucle For
            //for (int i = 0;i< Flights.Count();i++)
            //{ if (Flights[i].Destination == destination)
            //       dates.Add (Flights[i].FlightDate);

            //}
            // Foreach(var item in collection)
            //foreach( Flight f in Flights)
            //    if (f.Destination == destination)
            //        dates.Add(f.FlightDate);
            //return dates;
            //LinQ 

            // var query= from item in collection
            //where 
            //select
            // return query

            //var dates= from f in Flights
            //           where f.Destination == destination
            //           select f.FlightDate;
            //return dates;
            //Lambda 

          return Flights
                .Where(f => f.Destination == destination).Select(A=> A .FlightDate);
        }

        public IEnumerable<Flight> GetFlightOrderedBYDepartureDate(int LastPlane)
        {
            return GetAll()
                .OrderByDescending(f => f.Departure)
                .Take(LastPlane)
                .OrderBy(f => f.Departure)
                .ToList();
        }

        public int GetPassengerCountByFlightDate(DateTime startDate, DateTime endDate)
        {
            return GetMany(f => f.FlightDate >= startDate && f.FlightDate <= endDate)
                .Count();
        }

        public IEnumerable<Passenger> GetPassengersByPlaneAndDate(Plane plane, DateTime date)
        {
            var f = GetMany(f => f.Plane == plane && f.FlightDate.Date == date.Date);
            return f.SelectMany(f => f.Passengers)
                .Distinct();  
        }

        public IEnumerable<Passenger> GetStaffByFlightId(int flightId)
        {
            var f = GetById(flightId);
            return f.Passengers.OfType<Staff>();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from f in Flights
            //            orderby f.EstimatedDuration descending
            //            select f; 
            //return query;

            return Flights.OrderByDescending(f => f.EstimatedDuration);
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var req = from f in Flights
            //          where  startDate .CompareTo(f.FlightDate)>0 && (startDate - f.FlightDate).TotalDays > 7
            //          select f;
            //return req.Count();
            return Flights.Count(f => startDate.CompareTo(f.FlightDate) > 0 && (startDate - f.FlightDate).TotalDays > 7);
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = from f in  flight.Passengers.OfType<Traveller>()
            //            orderby f.BirthDate descending
            //            select f;
            //return query.Take(3);
            return flight.Passengers.OfType<Traveller>().OrderByDescending(i => i.BirthDate).Take(3);
        }

        public void ShowFlightDetails(Plane plane)
        {
            //var query = from f in Flights
            //            where f.Plane == plane
            //            select new { f.Destination, f.FlightDate };

           var reslt=Flights.Where(f=> f.Plane == plane).Select(f => new { f.Destination, f.FlightDate }) ;

            foreach (var item in reslt)
            {
                Console.WriteLine("Destination :" + item.Destination + " Date: " + item.FlightDate);
            }
        }
        public IEnumerable<Flight> SortFlights()

        {

            return GetAll().OrderByDescending(f => f.FlightDate);

        }
    }

}
