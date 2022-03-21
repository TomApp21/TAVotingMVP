using DomainLayer.Models.Election;
using DomainLayer.Models.Voter;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.AdminServices
{
    public class AdminServices : IAdminServices
    {
        private IAdminRepository _adminRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public AdminServices(IAdminRepository adminRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _adminRepository = adminRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        //public void Add(IDepartmentModel departmentModel)
        //{
        //    ValidateModel(departmentModel);
        //    _departmenRepository.Add(departmentModel);
        //}

        public void UpdateConfirmIdentity(VoterSelectDto voterModel, bool identityConfirmed)        //// needed
        {
            _adminRepository.ConfirmVoterIdentity(voterModel, identityConfirmed);
        }

        public void AddElection(IElectionModel electionModel)
        {
            ValidateModelDataAnnotations(electionModel);
            ValidateDateInput(electionModel.StartDate, electionModel.EndDate);

            _adminRepository.AddElection(electionModel);
        }

        //public void Delete(IDepartmentModel departmentModel)
        //{
        //    _departmenRepository.Delete(departmentModel);
        //}lu

        //public void DeleteById(int departmentModelId)
        //{
        //    _departmenRepository.DeleteById(departmentModelId);
        //}



        public IEnumerable<IVoterModel> GetAll()
        {
            return _adminRepository.GetAll();
        }

        //public VoterModel GetById(int id)
        //{
        //    return _adminRepository.GetById(id);
        //}


        public List<VoterSelectDto> GetVoterSelectList()
        {
            List<VoterModel> AllVoters = (List<VoterModel>)GetAll();
            List<VoterSelectDto> voterMinimumDetailDtoList = new List<VoterSelectDto>();

            foreach (VoterModel voterModel in AllVoters)
            {
                VoterSelectDto voterMinimumDetailDto = new VoterSelectDto();
                voterMinimumDetailDto.FirstName = voterModel.FirstName;
                voterMinimumDetailDto.LastName = voterModel.LastName;
                voterMinimumDetailDto.DateOfBirth = voterModel.DateOfBirth;
                voterMinimumDetailDto.AddressLine1 = voterModel.AddressLine1;
                voterMinimumDetailDto.AddressLine2 = voterModel.AddressLine2;
                voterMinimumDetailDto.Postcode = voterModel.Postcode;
                voterMinimumDetailDto.NationalInsurance = voterModel.NationalInsurance;
                voterMinimumDetailDto.ElectionId = voterModel.ElectionId;
                voterMinimumDetailDtoList.Add(voterMinimumDetailDto);
            }
            return voterMinimumDetailDtoList;
        }


        public void ValidateModelDataAnnotations(IElectionModel electionModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(electionModel);
        }


        public void ValidateDateInput(string startDate, string endDate)
        {
            StringBuilder errorsStringBuilder = new StringBuilder();

            DateTime tempDate;
            bool validStartDate = DateTime.TryParseExact(startDate, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out tempDate);
            bool validEndDate = DateTime.TryParseExact(endDate, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out tempDate);


            if (!validStartDate)
                errorsStringBuilder.Append("Start date must be in dd/mm/yyyy format").AppendLine();

            if (!validEndDate)
                errorsStringBuilder.Append("End date must be in dd/mm/yyyy format").AppendLine();

            if (errorsStringBuilder.Length > 0)
            {
                throw new ArgumentException($"{errorsStringBuilder.ToString()}");
            }
        }

        //public void ValidateModel(IDepartmentModel departmentModel)
        //{
        //    _modelDataAnnotationCheck.ValidateModelDataAnnotations(departmentModel);
        //}

        //public void ValidateModelDataAnnotations(IDepartmentModel departmentModel)
        //{
        //    _modelDataAnnotationCheck.ValidateModelDataAnnotations(departmentModel);
        //}

    }
}
