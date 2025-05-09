using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;

namespace AM.ApplicationCore.Service
{
    public class PlaneService : Service<Plane>, IPlaneService
    {
        //UnitOfWork ux;
        //AMContext context = new AMContext(); //cnx

        /*
        public void addPlanes(ApplicationCore.Domain.Plane p)
        {
            context.Planes.Add(p); //crud
            context.SaveChanges(); //commit
        }
        */
        public PlaneService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Passenger> GetPlassenger(Plane p)
        {
            return p.Flights.SelectMany(p => p.Passengers);
        }

        public void RemoveOldPlanes() 
        {
            var date = DateTime.Now.AddYears(-10);
            Delete(f => f.ManufactureDate < date);
        }
    }
}
