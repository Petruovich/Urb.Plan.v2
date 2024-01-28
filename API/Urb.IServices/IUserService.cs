using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Application.ComponentModels;
using Urb.Application.IComponentModels;
using Urb.Domain.Urb.Models;

namespace Urb.Application.Urb.IServices
{
    public interface IUserService
    {
        public Task<object> Register(IUserRegisterModel userRegisterModel);
        public Task<IActionResult> AuthenticateUser(IUserAuthenticateModel authenticateUser);
        //public IActionResult AuthenticateUser();
        public  Task<User> GetUser(string email);
        //public IEnumerable<User> GetAll();
    }
}
