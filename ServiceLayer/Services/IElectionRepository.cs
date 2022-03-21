using DomainLayer.Models.Election;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IElectionRepository
    {
        IEnumerable<IElectionModel> GetAllValidElections();
        ElectionModel GetElectionById(int electionId);

    }
}
