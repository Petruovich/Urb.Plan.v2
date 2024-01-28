using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urb.Domain.Urb.Models
{
    public class BillboardDetails
    {
        public int BillboardId { get; set; }
        public string? Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int DayCoast { get; set; }
        public string Adress { get; set; }
        public List<DateTime>? RentalDates { get; set; }
    }
}
