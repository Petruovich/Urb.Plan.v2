using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public RentedBords RentBord(RentedBords bord, byte[] photo)
        {
            RentedBords bords = new RentedBords()
            {
                BordName = bord.BordName,
                DordDescription = bord.DordDescription,
                StartDate = bord.StartDate,
                EndDate = bord.EndDate,
                Longitude = bord.Longitude,
                Latitude = bord.Latitude,
                Photo = photo
            };
            _context.RentedBords.Add(bords);
            _context.SaveChanges();
            return bords;
        }
    }
}
