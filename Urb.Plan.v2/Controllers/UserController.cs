using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Urb.Application.App.Settings;
using Urb.Application.ComponentModels;
using Urb.Application.IComponentModels;
using Urb.Application.Urb.IServices;
using Urb.Plan.v2.Views;

namespace Urb.Plan.v2.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private IUserService _userService;
        private IMapper _mapper;
        private AppSettings _appSettings;
        public UserController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [Route("Register")]
        [AllowAnonymous]
        [HttpPost/*("register")*/]
        public Task<object> Register(UserRegisterModel userRegisterModel)
        {
            //_userService.Register(userRegisterModel);
            return  _userService.Register(userRegisterModel);/*Ok(new { message = "Registration successful" });*/
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<object> Authenticate(UserAuthenticateModel model)
        {
            var response = await _userService.AuthenticateUser(model);
            return response;
        }
        //[Route("GetAll")]
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}

        //[Route("GetUser")]
        //[HttpGet/*("{id}")*/]
        //public IActionResult GetById(int id)
        //{
        //    var user = _userService.GetUser(id);
        //    return Ok(user);
        //}
    }
}
