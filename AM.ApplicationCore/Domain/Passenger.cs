using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [DataType(DataType.Date)]
        [DisplayName("date of birth")]
        public DateTime BirthDate { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public FullName fullName { get; set; }
        public int Id { get; set; }


        [Key, StringLength(7)]
        public string PassportNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0,9]{8}$")]
        public int TelNumber { get; set; }
        
        public virtual IList<Flight> Flights { get; set; }

        public virtual IList<ReservationTicket> reservation { get; set; }


        //public bool CheckProfile(string nom, string prenom)
        //{
        //    return LastName == nom && FirstName.Equals(prenom);
        //}
        //public bool CheckProfile(string nom, string prenom,string email)
        //{
        //    return LastName == nom && FirstName.Equals(prenom) && EmailAddress == email;
        //}


        public bool CheckProfile(string nom, string prenom, string email=null)
        {
           if ( email == null )
                return fullName.LastName == nom && fullName.FirstName.Equals(prenom);
            return fullName.LastName == nom && fullName.FirstName.Equals(prenom) && EmailAddress == email;
        }


        public virtual void PassengerType()
            { Console.WriteLine("I am a passenger"); 
        }
    }
}