using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigitHub.Domain.Core.Commands
{
    public class CreateUserCommand : UserCommand
    {
        public CreateUserCommand(string full_name, string email, bool is_admin = false)
        {

            this.Full_Name = full_name;
            this.Email = email;
            this.Is_admin = is_admin;
            this.Registration_date = DateTime.Now;
        }
    }
}
