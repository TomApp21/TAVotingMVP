using DomainLayer.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface ICandidateRepository
    {
        void AddCandidate(ICandidateModel candidateModel);

    }
}
