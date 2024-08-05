using NyaaySetu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyaaySetu.Authentication
{
    public interface IJwtToken
    {
        public string GeneratJwtToken(UserModel userModel);
        public string RefreshJwtToken(UserModel userModel);
    }
}
