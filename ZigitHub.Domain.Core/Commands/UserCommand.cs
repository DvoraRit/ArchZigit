using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigitHub.Domain.Core.Commands
{
    public abstract class UserCommand : Command
    {
        public string Full_Name { get; protected set; }
        public string Email { get; protected set; }
        public bool Is_admin { get; protected set; }
        public DateTime Registration_date { get; protected set; }

    }
}
