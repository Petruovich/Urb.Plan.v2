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
        public string Name { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
