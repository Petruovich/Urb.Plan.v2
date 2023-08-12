using Urb.Domain.Urb.Models;
using Urb.Plan.v2.Views;

namespace Urb.Plan.v2.IServices
{
    public interface IUserService
    {
        public Task<object> Register(UserRegisterModel userRegisterModel);
        public User GetUser(int id);
        public IEnumerable<User> GetAll();
    }
}
