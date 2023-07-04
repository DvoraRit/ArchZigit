using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZigitHub.Application.ViewModels;

namespace ZigitHub.Application.Interfaces
{
    public interface IUserService
    {
        //the implementation of this interface will be in the Application\Services\UserService.cs
        UserViewModel GetUsers();
        void Create(UserViewModel userViewModel);

    }
}
