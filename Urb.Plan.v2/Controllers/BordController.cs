using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Urb.Application.ComponentModels;
using Urb.Application.Urb.IServices;
using Urb.Domain.Urb.Models;
using Urb.Infrastructure.Urb.Services;

namespace Urb.Plan.v2.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class BordController : ControllerBase
    {
        private readonly IBordService _bordService;

        public BordController(IBordService bordService)
        {
            _bordService = bordService;
        }

        [Route("BordRent")]
        [AllowAnonymous]
        [HttpPost]
        public RentedBords Register(RentedBords bord, byte[] photo)
        {           
            return _bordService.RentBord(bord, photo);
        }
    }
}
