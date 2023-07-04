using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZigitHub.Domain.Interfaces;
using ZigitHub.Domain.Models;
using ZigitHub.Infra.Data.Context;

namespace ZigitHub.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private UsersDBContext _context;

        public UserRepository(UsersDBContext context)
        {
            this._context = context;
        }

        public void Add(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return this._context.users;
        }
    }
}
