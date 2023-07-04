using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigitHub.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Email { get; set; }
        public bool Is_admin { get; set; }
        public DateTime Registration_date { get; set; }
    }
}
