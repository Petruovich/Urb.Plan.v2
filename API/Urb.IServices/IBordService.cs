using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Application.ComponentModels;
using Urb.Domain.Urb.Models;

namespace Urb.Application.Urb.IServices
{
    public interface IBordService
    {
        //public Task<bool> BookBillboardAsync(int billboardId, string renterEmail, DateTime startDate, DateTime endDate);
        public Task<IEnumerable<Billboard>> GetAllBillboardsAsync();
        public RentedBoard Rent(RentedBordModel rentboards/*, string userId*/);
        public Task<List<BillboardDetails>> GetBillboardWithRentalDatesAsync(/*string billboardId*/);
        //public  Task<BillboardDetails> GetBillboardWithRentalDatesAsync(string billboardId);

        //public RentedBords RentBord(RentedBords bord/*, byte[] photo*/);
    }
}
