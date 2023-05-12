//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
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
        public ICollection<Token> Tokens { get; set; }
    }
}
