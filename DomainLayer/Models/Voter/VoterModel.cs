using DomainLayer.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Voter
{
    public class VoterModel : IVoterModel
    {
        //[Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        //[StringLength(20, MinimumLength = 1, ErrorMessage = "First Name must be between 1 and 20 characters")]
        public string FirstName { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        //[StringLength(20, MinimumLength = 1, ErrorMessage = "Last Name must be between 1 and 20 characters")]
        public string LastName { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Date of Birth is required")]
        //[StringLength(10, MinimumLength = 10, ErrorMessage = "Postcode must be in the correct format.")]
        public string DateOfBirth { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        //[StringLength(20, MinimumLength = 1, ErrorMessage = "First Name must be between 1 and 20 characters")]
        public string AddressLine1 { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        //[StringLength(20, MinimumLength = 1, ErrorMessage = "First Name must be between 1 and 20 characters")]
        public string AddressLine2 { get; set; }

        //[Required(ErrorMessage = "Postcode is a Required field.")]
        //[StringLength(20, MinimumLength = 1, ErrorMessage = "First Name must be between 2 and 10 characters")]

        public string Postcode { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "National Insurance number is required")]
        //[StringLength(9, MinimumLength = 9, ErrorMessage = "National Insurance number must be 9 characters in length")]
        public string NationalInsurance { get; set; }

        public int ElectionId { get; set; }

        public bool VoterIdentityConfirmed { get; set; }

        public bool CastVote { get; set; }



    }
}
