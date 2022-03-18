using DomainLayer.Models.User;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.LoginServices
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public UserServices(IUserRepository userRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _userRepository = userRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public UserModel LoginUser(IUserModel userLoginModel)
        {
            ValidateModelDataAnnotations(userLoginModel);
            return _userRepository.LoginUser(userLoginModel);
        }
        public void RegisterUser(IUserModel userModel)
        {
            ValidateModelDataAnnotations(userModel);
            ValidateMatchingPasswords(userModel);

            _userRepository.RegisterUser(userModel);
        }


        public void ValidateModelDataAnnotations(IUserModel userModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(userModel);
        }

        public void ValidateMatchingPasswords(IUserModel userModel)
        {
            StringBuilder errorsStringBuilder = new StringBuilder();


            if (userModel.Password.Count() < 5)
            {
                errorsStringBuilder.Append("Password must be between 5 and 20 characters").AppendLine();
            }

            if (userModel.Password != userModel.ConfirmPassword)
            {
                errorsStringBuilder.Append("Passwords must match").AppendLine();
            }

            if (errorsStringBuilder.Length > 0)
            {
                throw new ArgumentException($"{errorsStringBuilder.ToString()}");
            }
        }
    }
}
