using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Voter
{
    public class VoterSelectDto
    {
        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Postcode { get; set; }

        public string NationalInsurance { get; set; }

        public int ElectionId { get; set; }
    }
}
