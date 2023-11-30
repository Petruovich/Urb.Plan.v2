using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Application.IComponentModels;

namespace Urb.Application.ComponentModels
{
    public class UserAuthenticateModel: IUserAuthenticateModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
