using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Election
{
    public class ElectionModel : IElectionModel
    {
        public int ElectionId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Election Name is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Election Name must be between 3 and 20 characters")]
        public string ElectionName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Start Date is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Start Date must be in correct format.")]
        public string StartDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "End Date is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "End Date must be in correct format")]
        public string EndDate { get; set; }
    }
}
