using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Candidate
{
    public class CandidateModel : ICandidateModel
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int VoteCount { get; set; }
        public int ElectionId { get; set; }

    }
}
