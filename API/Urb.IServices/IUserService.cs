using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Domain.Urb.Models;

namespace Urb.Application.Urb.IServices
{
    public interface IUserService
    {
        public Task<object> Register(UserRegisterModel userRegisterModel);
        public User GetUser(int id);
        public IEnumerable<User> GetAll();
    }
}
