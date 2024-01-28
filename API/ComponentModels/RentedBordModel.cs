using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Domain.Urb.Models;

namespace Urb.Application.ComponentModels
{
    public class RentedBordModel
    {
        public int BillboardId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }       
    }
}
