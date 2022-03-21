using DomainLayer.Models.Candidate;

namespace ServiceLayer.Services
{
    public interface ICandidateServices
    {
        void AddCandidate(ICandidateModel candidateModel);
        void ValidateModelDataAnnotations(ICandidateModel candidateModel);
    }
}