using DomainLayer.Models.Candidate;
using System.Collections.Generic;

namespace ServiceLayer.Services
{
    public interface ICandidateServices
    {
        void AddCandidate(ICandidateModel candidateModel);

        void CastCandidateVote(int candidateId, int userId);

        IEnumerable<ICandidateModel> GetCandidatesForElection(int electionId);
        void ValidateModelDataAnnotations(ICandidateModel candidateModel);
    }
}