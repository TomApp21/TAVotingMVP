using DomainLayer.Models.Candidate;
using DomainLayer.Models.Election;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CandidateServices : ICandidateServices
    {
        private ICandidateRepository _candidateRepository;
        private IElectionRepository _electionRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        private IElectionModel _electionModel;

        public CandidateServices(ICandidateRepository candidateRepository, IElectionRepository electionRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _candidateRepository = candidateRepository;
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

        public void AddCandidate(ICandidateModel candidateModel)
        {
            ValidateModelDataAnnotations(candidateModel);
            ValidateElectionHasNotStarted(candidateModel.ElectionId);

            _candidateRepository.AddCandidate(candidateModel);
        }

        public IEnumerable<ICandidateModel> GetCandidatesForElection(int electionId)
        {
            return _candidateRepository.GetCandidatesForElection(electionId);
        }

        public void CastCandidateVote(int candidateId, int userId)
        {
            _candidateRepository.CastCandidateVote(candidateId, userId);
        }

        public void ValidateModelDataAnnotations(ICandidateModel candidateModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(candidateModel);
        }

        public void ValidateElectionHasNotStarted(int electionId)
        {
            _electionModel = _electionRepository.GetElectionById(electionId);

            StringBuilder errorsStringBuilder = new StringBuilder();

            DateTime dtStart = DateTime.ParseExact(_electionModel.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEnd = DateTime.ParseExact(_electionModel.EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            if (dtStart > DateTime.Now && DateTime.Now < dtEnd)
            {
                errorsStringBuilder.Append("Election has already finished").AppendLine();
            }
            if (DateTime.Now > dtEnd)


            if (errorsStringBuilder.Length > 0)
            {
                throw new ArgumentException($"{errorsStringBuilder.ToString()}");
            }

        }

    }
}
