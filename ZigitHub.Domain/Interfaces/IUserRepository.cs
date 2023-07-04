using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZigitHub.Domain.Models;

namespace ZigitHub.Domain.Interfaces
{
    public interface IUserRepository
    {
        //implementation of this interface is in Arch.Infra.Data\Repository\UserRepository.cs
        IEnumerable<User> GetUsers();
        void Add(User user);
    }
}
