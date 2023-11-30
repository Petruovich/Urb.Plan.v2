using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Application.ComponentModels;
using Urb.Application.IComponentModels;

namespace Urb.Application.Urb.IServices
{
    public interface IJwtService
    {
        public string GenerateToken(IUserAuthenticateModel userauth);
        public int? ValidateToken(string token);
    }
}
