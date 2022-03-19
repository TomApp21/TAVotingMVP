using DomainLayer.Models.Voter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.VoterServices
{
    public interface IVoterRepository
    {
        void RegisterVoter(IVoterModel voterModel, int loggedInUserId);
        VoterModel GetVoterById(int loggedInUserId);
    }
}
