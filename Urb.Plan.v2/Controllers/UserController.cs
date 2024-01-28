using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<object> Register(UserRegisterModel userRegisterModel)
        {
            //_userService.Register(userRegisterModel);
            var result = await _userService.Register(userRegisterModel);/*Ok(new { message = "Registration successful" });*/
            if (result is IdentityResult identityResult)
            {
                if (identityResult.Succeeded)
                {
                    return Ok("User registered successfully.");
                }
                else
                {
                    var errors = identityResult.Errors.Select(e => e.Description);
                    return BadRequest(new { Errors = errors });
                }
            }

            if (result?.GetType().GetProperty("Error")?.GetValue(result) is string errorDetail)
            {
                return BadRequest(new { Error = errorDetail });
            }

            if (result?.GetType().GetProperty("Message")?.GetValue(result) is string message)
            {
                return BadRequest(new { Message = message });
            }

            return BadRequest("Unknown error occurred.");



            //if (result is IdentityResult identityResult && identityResult.Succeeded)
            //{
            //    return Ok("User registered successfully."); 
            //}                        
            //    return BadRequest(_userService.Register(userRegisterModel));
            //    


            //if (result is IdentityResult identityResult)
            //{
            //    if (identityResult.Succeeded)
            //    {
            //        return Ok("User registered successfully.");
            //    }
            //    else
            //    {
            //        var errors = identityResult.Errors.Select(e => e.Description);
            //        return BadRequest(new { Errors = errors });
            //    }
            //}

            //if (result is { Error: var errorDetail })
            //{
            //    return BadRequest(new { Error = errorDetail });
            //}
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Authenticate(UserAuthenticateModel model)
        {
            var response = await _userService.AuthenticateUser(model);

            if (response is BadRequestObjectResult badRequestResult)
            {
                return BadRequest(badRequestResult.Value);
            }

            if (response is OkObjectResult okResult)
            {
                return Ok(okResult.Value);
            }

            return BadRequest("An unknown error occurred.");
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
