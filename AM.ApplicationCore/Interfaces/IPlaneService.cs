using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Interfaces
{
    public interface IPlaneService : IService<Plane>
    {
        //public void addPlanes(Plane p);
        
        IEnumerable<Passenger> GetPlassenger(Plane p);

        public void RemoveOldPlanes();

    }
}
