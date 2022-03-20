using DomainLayer.Models.Election;
using DomainLayer.Models.Voter;
using System.Collections.Generic;

namespace ServiceLayer.Services.AdminServices

{
    public interface IAdminServices
    {
        IEnumerable<IVoterModel> GetAll();
        //VoterModel GetById(int id);
        List<VoterSelectDto> GetVoterSelectList();
        void UpdateConfirmIdentity(VoterSelectDto voterModel, bool identityConfirmed);
        void AddElection(IElectionModel electionModel);

    }
}