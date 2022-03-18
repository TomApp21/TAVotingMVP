using DomainLayer.Models.User;

namespace ServiceLayer.Services.LoginServices
{
    public interface IUserServices
    {
        UserModel LoginUser(IUserModel userLoginModel);
        void RegisterUser(IUserModel userModel);
        void ValidateModelDataAnnotations(IUserModel userModel);
        void ValidateMatchingPasswords(IUserModel userModel);
    }
}