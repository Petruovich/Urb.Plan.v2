using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Urb.Domain.Urb.DataConext;
using Urb.Domain.Urb.Models;
using Urb.Plan.v2.IServices;
using Urb.Plan.v2.Mapper;
using Urb.Plan.v2.Views;

namespace Urb.Plan.v2.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private MainDataContext _context;
        private IJWTService _jwtService;
        private readonly IMapper _mapper;
        public UserService(MainDataContext context, 
            IJWTService jWTService, 
            IMapper autoMapperProfile, 
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _jwtService = jWTService;
            _mapper = autoMapperProfile;
            _userManager = userManager;
        }        
        private IActionResult Ok(User user)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }
        public User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
        public async Task<object> Register(UserRegisterModel userRegisterModel)
        {
            var user = _mapper.Map<IdentityUser>(userRegisterModel);

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                _context.SaveChanges();
                var token = _jwtService.GenerateToken(user);
                return token;
            }
            else
            {
                return new { Error = "Failed to create user" };
            }
        }
        //public IActionResult AuthenticateUser(AuthenticateUserView authenticateUserView)
        //{
        //    var user = _context.Users.SingleOrDefault(x => x.UserName == authenticateUserView.Username);

        //    return ;
        //}
    }
}
