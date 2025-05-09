using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AM.ApplicationCore.Domain
{
    //method 1 
    //[Owned]
    public class FullName
    {
        [MinLength(3, ErrorMessage = "First name is at least 3 characters")]
        [MaxLength(25, ErrorMessage = "First name is at most 25 characters")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
