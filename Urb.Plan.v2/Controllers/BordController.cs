using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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


        //[HttpGet]
        //public async Task<IActionResult> GetBillboards()
        //{
        //    var billboards = await _bordService.GetAllBillboardsAsync();
        //    return Ok(billboards);
        //}

        //[Authorize]    
        //[HttpPost("book/{billboardId}")]
        //public async Task<IActionResult> BookBillboard(int billboardId, [FromBody] BookingRequest request)
        //{
        //    var success = await _bordService.BookBillboardAsync(billboardId, request.RenterEmail, request.StartDate, request.EndDate);
        //    if (!success)
        //        return BadRequest("Unable to book the billboard.");

        //    return Ok();
        //}
        [Authorize]
        [HttpPost("id")]
            
        public object RentBoard(RentedBordModel model)
            {
            var hibfhs = User.Identity.Name;
            var user = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pyrt = user;
            // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _bordService.Rent(model/*, userId*/);
            }

        [Authorize]
        [HttpPost]

        public object RentttBoard(RentedBordModel model)
        {
            var hibfhs = User.Identity.Name;
            var user = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);        
            return hibfhs;
        }

        [HttpGet]
        public async Task<IActionResult> GetBillboardDetails()
        {
            var billboardDetails = await _bordService.GetBillboardWithRentalDatesAsync();
            if (billboardDetails == null)
            {
                return NotFound();
            }
            return Ok(billboardDetails);
        }

        public class BookingRequest
        {
            public string RenterEmail { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        //[Route("BordRent")]
        //[AllowAnonymous]
        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public RentedBords RentedBords([FromForm] RentedBords bord/*, byte[] photo*/)
        //{           
        //    return _bordService.RentBord(bord/*, photo*/);
        //}
    }
}
