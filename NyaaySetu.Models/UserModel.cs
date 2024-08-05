using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyaaySetu.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string MobileNumber { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}
