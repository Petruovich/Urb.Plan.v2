using AutoMapper;
using Azure.Messaging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Application.ComponentModels;
using Urb.Application.IComponentModels;
using Urb.Application.Urb.IServices;
using Urb.Domain.Urb.Models;
using Urb.Persistance.Urb.DataConext;

namespace Urb.Infrastructure.Urb.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private UserTokenDataContext _context;
        private IJwtService _jwtService;
        private readonly IMapper _mapper;
        public UserService(
            UserTokenDataContext context,
            IJwtService jWTService,
            IMapper autoMapperProfile,
            SignInManager<User> signInManager,
            UserManager<User> userManager
            )
        {
            _context = context;
            _jwtService = jWTService;
            _mapper = autoMapperProfile;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Ok(User user)
        {
            throw new NotImplementedException();
        }
        public async Task<User>  GetUser(string email)
        {
            var identityuser = await _userManager.FindByEmailAsync(email);                     
            return identityuser;
        }
        public async Task<object> Register(IUserRegisterModel userRegisterModel)
        {          
            var user = _mapper.Map<User>(userRegisterModel);
            var testEmail = await GetUser(user.Email);           
            if (testEmail != null)
            {
                return new { Messege = "User already exist" };
            }            
            var result = await _userManager.CreateAsync(user, userRegisterModel.Password);
            
            if (result.Succeeded)
            {
                var authUser = _mapper.Map<UserAuthenticateModel>(userRegisterModel);
                var token = AuthenticateUser(authUser);

                _context.Users.Add(user);
                return result;
            }           
            List<IdentityError> errors = result.Errors.ToList();
            var errorDetail = string.Join(", ", errors.Select(e => e.Description));
            return new { Error = errorDetail };           
        }
        public async Task<IActionResult> AuthenticateUser(IUserAuthenticateModel authenticateUser)
        {
            var user = _mapper.Map<User>(authenticateUser);
            var joinUser = await _userManager.FindByEmailAsync(user.Email); 
            if (joinUser == null)
            {
                return new BadRequestObjectResult(new {Message = "not found" });
            }          
                var userauth = await _signInManager.CheckPasswordSignInAsync(joinUser, authenticateUser.Password,
                                                                               lockoutOnFailure: false); 
            if (userauth.Succeeded)
            {
                var token = _jwtService.GenerateToken(authenticateUser);
                return new OkObjectResult(token);
                //return token;               
            }
            return new BadRequestObjectResult( new { Messege = "Auth Failed" });
        }
    }
}











//IdentityUser user = new IdentityUser
//{
//    UserName = userRegisterModel.UserName,
//    Email = userRegisterModel.Email,
//    PasswordHash = userRegisterModel.Password
//};

//var user = _mapper.Map<User>(userRegisterModel);
//var user = _mapper.Map<UserRegisterModel>(_identityUser);
//IdentityUser user = new IdentityUser()
//User testuser = new User()
//{

//    UserName = userRegisterModel.FirstName + "." + userRegisterModel.SecondName,
//    Email = userRegisterModel.Email,
//    //PasswordHash = _model.Password
//};
//var result = await _userManager.CreateAsync(user, userRegisterModel.Password);
//_context.Users.S();                
//var token = _jwtService.GenerateToken(user);

//var user = (User?)_context.Users.FirstOrDefault(q => q.Email == email);
//if (user == null) throw new KeyNotFoundException("User not found");

//var test = /*(IdentityUser)*/_userManager.FindByEmailAsync(user.Email); 

//var result = await _userManager.CreateAsync(user, userRegisterModel.Password);




//using AutoMapper;
//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Urb.Application.ComponentModels;
//using Urb.Application.IComponentModels;
//using Urb.Application.Urb.IServices;
//using Urb.Domain.Urb.Models;
//using Urb.Persistance.Urb.DataConext;
////using Urb.Persistance.Urb.DataConext;
////using Urb.Persistance.Urb.UnitOfWork;////

//namespace Urb.Infrastructure.Urb.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly UserManager<IdentityUser> _userManager;
//        private SignInManager<IdentityUser> _signInManager;
//        private UserTokenDataContext _context;
//        private IJwtService _jwtService;
//        private readonly IMapper _mapper;
//        //private UnitOfWork _unitOfWork;
//        //private IdentityUser _identityUser;
//        //private UserRegisterModel _userRegisterModel;
//        //private IUserRegisterModel _model;
//        public UserService(
//            UserTokenDataContext context,
//            IJwtService jWTService,
//            IMapper autoMapperProfile,
//            //IUserRegisterModel userRegisterModel,
//            //IdentityUser identityUser,
//            //UserRegisterModel model,
//            SignInManager<IdentityUser> signInManager,
//            UserManager<IdentityUser> userManager
//            )
//        {
//            //_userRegisterModel = model;
//            //_signInManager = signInManager;
//            //_model = userRegisterModel;
//            //_model = model;
//            //_identityUser = identityUser;
//            _context = context;
//            _jwtService = jWTService;
//            _mapper = autoMapperProfile;
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }
//        public IActionResult Ok(User user)
//        {
//            throw new NotImplementedException();
//        }
//        //public IEnumerable<User> GetAll()
//        //{
//        //    return _context.Users;
//        //}
//        public async Task<IdentityUser> GetUser(string email)
//        {
//            var identityuser = await _userManager.FindByEmailAsync(email);
//            return identityuser;
//        }
//        public async Task<object> Register(IUserRegisterModel userRegisterModel)
//        {
//            var user = _mapper.Map<User>(userRegisterModel);
//            var testEmail = await GetUser(user.Email);
//            if (testEmail != null)
//            {
//                return new { Messege = "User already exist" };
//            }
//            var result = await _userManager.CreateAsync(user, userRegisterModel.Password);

//            if (result.Succeeded)
//            {
//                //IUserRegisterModel reguser = new UserRegisterModel();
//                //IUserAuthenticateModel authmodel = new UserAuthenticateModel();
//                var authUser = _mapper.Map<UserAuthenticateModel>(userRegisterModel);
//                var token = AuthenticateUser(authUser);

//                _context.Users.Add(user);
//                //_jwtService.GenerateToken(user);
//                return result;
//            }
//            List<IdentityError> errors = result.Errors.ToList();
//            var errorDetail = string.Join(", ", errors.Select(e => e.Description));
//            return new { Error = errorDetail };
//        }
//        public async Task<object> AuthenticateUser(IUserAuthenticateModel authenticateUser)
//        {
//            //var auth = _mapper.Map<UserRegisterModel>(authenticateUser);/
//            //IUserRegisterModel user = new UserRegisterModel();
//            //var huy = _mapper.Map<IUserAuthenticateModel>(user);
//            var user = _mapper.Map<User>(authenticateUser);
//            var joinUser = await _userManager.FindByEmailAsync(user.Email);
//            if (joinUser == null)
//            {
//                return new { Messege = "User not found" };
//            }
//            //var userauth = await _signInManager.PasswordSignInAsync(user.Email, authenticateUser.Password/*user.PasswordHash*/, 
//            //isPersistent: false, lockoutOnFailure: false);
//            var userauth = await _signInManager.CheckPasswordSignInAsync(joinUser, authenticateUser.Password,
//                                                                           lockoutOnFailure: false);
//            if (userauth.Succeeded)
//            {
//                var token = _jwtService.GenerateToken(authenticateUser);
//                return token;
//                //return new { Messege = "--" };
//            }
//            return new { Messege = "Auth Failed" };
//            //var ert = _jwtService.GenerateToken();
//            //var user = _context.Users.SingleOrDefault(x => x.UserName == authenticateUserView.Username);

//        }
//    }
//}
