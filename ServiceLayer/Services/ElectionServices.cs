using DomainLayer.Models.Election;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ElectionServices : IElectionServices
    {
        private IElectionRepository _electionRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ElectionServices(IElectionRepository electionRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _electionRepository = electionRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        //public void Add(IDepartmentModel departmentModel)
        //{
        //    ValidateModel(departmentModel);
        //    _departmenRepository.Add(departmentModel);
        //}

        //public void UpdateConfirmIdentity(VoterSelectDto voterModel, bool identityConfirmed)        //// needed
        //{
        //    _adminRepository.ConfirmVoterIdentity(voterModel, identityConfirmed);
        //}



        public IEnumerable<IElectionModel> GetAllValidElections()
        {

            return _electionRepository.GetAllValidElections();
        }

        public void ValidateModelDataAnnotations(IElectionModel electionModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(electionModel);
        }

    }
}
