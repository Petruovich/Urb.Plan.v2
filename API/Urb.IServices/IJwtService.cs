using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urb.Application.Urb.IServices
{
    public interface IJwtService
    {
        public string GenerateToken(IdentityUser user);
        public int? ValidateToken(string token);
    }
}
