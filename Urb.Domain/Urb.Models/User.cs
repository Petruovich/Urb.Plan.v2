using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urb.Domain.Urb.Models
{
    public class User: IdentityUser
    {                
        //public List<RentedBoard>? RentedBoards { get; set; }
    }
}
