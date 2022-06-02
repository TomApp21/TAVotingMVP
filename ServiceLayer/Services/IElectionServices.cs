using DomainLayer.Models.Election;
using System.Collections.Generic;

namespace ServiceLayer.Services
{
    public interface IElectionServices
    {
        IEnumerable<IElectionModel> GetAllValidElections();

        ElectionModel GetElectionById(int electionId);
        void ValidateModelDataAnnotations(IElectionModel electionModel);
    }
}