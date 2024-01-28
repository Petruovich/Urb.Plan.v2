using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urb.Domain.Urb.Models
{
    public class Billboard
    {
        public int BillboardId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
        public string? Adress { get; set; }
        public string? Description { get; set; }
        public int DayCost { get; set; }
        public List<RentedBoard>? RentedBoards { get; set; }
    }
}


//public List<DateTime>? AllDays { get; set; }