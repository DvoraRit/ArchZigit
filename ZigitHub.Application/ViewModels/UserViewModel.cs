using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZigitHub.Domain.Models;

namespace ZigitHub.Application.ViewModels
{
    public class UserViewModel
    {
        public string Full_name { get; set; }
        public string Email { get; set; }
        public bool Is_admin { get; set; }
        public DateTime Registration_date { get; set; }
        public IEnumerable<User> Users { get; set; }

    }
}
