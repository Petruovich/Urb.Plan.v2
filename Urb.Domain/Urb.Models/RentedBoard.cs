using Microsoft.SqlServer.Server;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urb.Domain.Urb.Models
{
    public class RentedBoard
    {      
        public int RentedBoardId { get; set; }
        public int BillboardId { get; set; }
        public Billboard? Billboard { get; set; }
        //public string? UserId { get; set; }
        //public User? User { get; set; }        
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int? FullCost { get; set; } 
    }
}










//[Required]
//public double Longitude { get; set; }
//[Required]
//public double Latitude { get; set; }
//[SwaggerSchema(Type = "string", Format = "binary")]
//[SwaggerSchema(Description = "Select File")]
//[SwaggerIgnore]
//public byte[] Photo { get; set; }












