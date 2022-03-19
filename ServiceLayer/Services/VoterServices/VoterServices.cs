using DomainLayer.Models.Voter;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.VoterServices
{
    public class VoterServices : IVoterServices
    {
        private IVoterRepository _voterRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public VoterServices(IVoterRepository voterRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _voterRepository = voterRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }


        public void RegisterVoter(IVoterModel voterModel, int loggedInUserId)
        {
            ValidateModelDataAnnotations(voterModel);

            _voterRepository.RegisterVoter(voterModel, loggedInUserId);
        }

        public VoterModel GetVoterById(int loggedInUserId)
        {
            return _voterRepository.GetVoterById(loggedInUserId);
        }

        public void ValidateModelDataAnnotations(IVoterModel voterModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(voterModel);
        }

    }
}
