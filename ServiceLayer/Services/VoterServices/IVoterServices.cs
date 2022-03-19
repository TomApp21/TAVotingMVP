using DomainLayer.Models.Voter;

namespace ServiceLayer.Services.VoterServices
{
    public interface IVoterServices
    {
        void RegisterVoter(IVoterModel voterModel, int loggedInUserId);
        VoterModel GetVoterById(int loggedInUserId);
        void ValidateModelDataAnnotations(IVoterModel voterModel);
    }
}