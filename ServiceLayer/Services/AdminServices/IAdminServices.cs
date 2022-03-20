using DomainLayer.Models.Voter;
using System.Collections.Generic;

namespace ServiceLayer.Services.AdminServices

{
    public interface IAdminServices
    {
        IEnumerable<IVoterModel> GetAll();
        //VoterModel GetById(int id);
        List<VoterModel> GetDepartmentSelectList();
        void UpdateConfirmIdentity(IVoterModel voterModel, bool identityConfirmed);
    }
}