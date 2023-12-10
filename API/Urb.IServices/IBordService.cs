using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Domain.Urb.Models;

namespace Urb.Application.Urb.IServices
{
    public interface IBordService
    {
        public RentedBords RentBord(RentedBords bord, byte[] photo);
    }
}
