using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Application.ComponentModels;
using Urb.Application.Urb.IServices;
using Urb.Domain.Urb.Models;
using Urb.Persistance.Urb.DataConext;

namespace Urb.Infrastructure.Urb.Services
{
    public class BordService: IBordService
    {
        private UserTokenDataContext _context;
        

        public BordService(UserTokenDataContext context)
        {
            
            _context = context;
        }
        public async Task<IEnumerable<Billboard>> GetAllBillboardsAsync()
        {
            return await _context.Billboards.ToListAsync();
        }

        //public async Task<bool> BookBillboardAsync(int billboardId, string renterEmail, DateTime startDate, DateTime endDate)
        //{
        //    var billboard = await _context.Billboards.FindAsync(billboardId);
        //    if (billboard == null || billboard.RentalEndDate >= DateTime.Now)
        //        return false;

        //    //billboard.RenterEmail = renterEmail;
        //    billboard.RentalStartDate = startDate;
        //    billboard.RentalEndDate = endDate;

        //    _context.Billboards.Update(billboard);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}


        public bool IsAvailableForRent(int billboardId, DateTime newStartDate, DateTime newEndDate)
        {
            var billboard = _context.Billboards.Include(b => b.RentedBoards)
                                .FirstOrDefault(b => b.BillboardId == billboardId);

            if (billboard != null)
            {
                return !billboard.RentedBoards.Any(rb => rb.StartDate < newEndDate && rb.EndDate > newStartDate);
            }

            return false;
        }
        public static DateTime ConvertUTCFrom(DateTime UTCDataTimeStart)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
            DateTime localDateTimeStsrt = TimeZoneInfo.ConvertTimeFromUtc(UTCDataTimeStart, timeZoneInfo);
           
            return localDateTimeStsrt;
        }

        public RentedBoard Rent(RentedBordModel rentboards/*, string? userId*/)
        {
            //var availableDate = IsAvailableForRent(rentboards.BillboardId, rentboards.StartDate, rentboards.EndDate);
            //if (availableDate == true)
            //{
                var billboard =  _context.Billboards.FindAsync(rentboards.BillboardId).Result;
                if (billboard != null)
                {
                var daysstart = ConvertUTCFrom(rentboards.StartDate);
                var dayeend = ConvertUTCFrom(rentboards.EndDate);

                var rentDays = (dayeend - daysstart/*rentboards.EndDate - rentboards.StartDate*/).Days;
                    var rentCost = rentDays * billboard.DayCost;
                    //var rentUser = _context.Users.FindAsync(userId).Result;
                    RentedBoard rentedBoard = new RentedBoard
                    {
                        //RentedBoardId = rentboards.RentedBoardId,
                        BillboardId = rentboards.BillboardId,
                        //UserId = userId,
                        StartDate = rentboards.StartDate,
                        EndDate = rentboards.EndDate,
                        FullCost = rentCost
                    };
                    _context.RentedBords.Add(rentedBoard);
                    _context.SaveChanges();
                    return rentedBoard;                    
                }
            return null;
            //}
            return null;
        }
        
        private IEnumerable<DateTime> GetDateRange(DateTime start, DateTime end)
        {
            for (var date = start; date <= end; date = date.AddDays(1))
            {
                yield return date;
            }
        }
        public async Task<List<BillboardDetails>> GetBillboardWithRentalDatesAsync(/*string billboardId*/)
        {
            var billboards = await _context.Billboards
                                          .Include(b => b.RentedBoards).ToListAsync();
            //.FirstOrDefaultAsync(b => b.BillboardId == billboardId);

            //if (billboard == null) return null;



            var billboardsDetails = billboards.Select(billboard => new BillboardDetails
            {
                BillboardId = billboard.BillboardId,
                Description = billboard.Description,
                    Longitude = billboard.Longitude,
                    Latitude = billboard.Latitude,
                    DayCoast = billboard.DayCost,
                    Adress = billboard.Adress,
                RentalDates = billboard.RentedBoards
                                .SelectMany(rb => GetDateRange(rb.StartDate, rb.EndDate))
                                .Distinct()
                                .ToList()
            }).ToList();

            return billboardsDetails;





            //var rentalDates = billboard.RentedBoards
            //                           .SelectMany(rb => GetDateRange(rb.StartDate, rb.EndDate))
            //                           .Distinct()
            //                           .ToList();

            //return new BillboardDetails
            //{
            //    BillboardId = billboard.BillboardId,
            //    Description = billboard.Description,
            //    Longitude = billboard.Longitude,
            //    Latitude = billboard.Latitude,
            //    DayCoast = billboard.DayCoast,
            //    RentalDates = rentalDates
            //};
        }

















        //public RentedBords RentBord(RentedBords bord/*, byte[] photo*/)
        //{
        //    RentedBords bords = new RentedBords()
        //    {
        //        BordName = bord.BordName,
        //        DordDescription = bord.DordDescription,
        //        StartDate = bord.StartDate,
        //        EndDate = bord.EndDate,
        //        Longitude = bord.Longitude,
        //        Latitude = bord.Latitude,
        //        //Photo = bord.Photo
        //        //Photo = photo
        //    };
        //    _context.RentedBords.Add(bords);
        //    _context.SaveChanges();
        //    return bords;
        //}
    }
}
