using DomainLayer.Models.Election;
using System.Collections.Generic;

namespace ServiceLayer.Services
{
    public interface IElectionServices
    {
        IEnumerable<IElectionModel> GetAllValidElections();
        void ValidateModelDataAnnotations(IElectionModel electionModel);
    }
}