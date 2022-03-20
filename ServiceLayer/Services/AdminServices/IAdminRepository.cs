using DomainLayer.Models.Election;
using DomainLayer.Models.Voter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.AdminServices
{
    public interface IAdminRepository
    {
        IEnumerable<IVoterModel> GetAll();
        void ConfirmVoterIdentity(VoterSelectDto voterModel, bool identityConfirmed);
        void AddElection(IElectionModel electionModel);


    }
}
