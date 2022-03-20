using DomainLayer.Models.Voter;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
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

        public void UpdateConfirmIdentity(IVoterModel voterModel, bool identityConfirmed)        //// needed
        {
            //_adminRepository.Update(loggedInUserId, identityConfirmed);
        }

        //public void Delete(IDepartmentModel departmentModel)
        //{
        //    _departmenRepository.Delete(departmentModel);
        //}
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


        public List<VoterModel> GetDepartmentSelectList()
        {
            List<VoterModel> AllDepartments = (List<VoterModel>)GetAll();
            List<DepartmentSelectDto> departmentMinimumDetailDtoList = new List<DepartmentSelectDto>();

            foreach (DepartmentModel departmentModel in AllDepartments)
            {
                DepartmentSelectDto departmentMinimumDetailDto = new DepartmentSelectDto();
                departmentMinimumDetailDto.DepartmentId = departmentModel.DepartmentId;
                departmentMinimumDetailDto.DepartmentName = departmentModel.DepartmentName;
                departmentMinimumDetailDto.CityLocation = departmentModel.CityLocation;
                departmentMinimumDetailDto.StateLocation = departmentModel.StateLocation;
                departmentMinimumDetailDtoList.Add(departmentMinimumDetailDto);
            }
            return AllDepartments;
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
