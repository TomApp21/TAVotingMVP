using DomainLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.UserServices
{
    public interface IUserRepository
    {
        UserModel LoginUser(IUserModel userLoginModel);
        void RegisterUser(IUserModel userModel);


    }
}
