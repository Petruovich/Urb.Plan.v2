using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urb.Application.IComponentModels
{
    public interface IUserAuthenticateModel
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
