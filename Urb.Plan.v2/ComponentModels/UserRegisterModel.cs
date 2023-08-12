using System.ComponentModel.DataAnnotations;

namespace Urb.Plan.v2.Views
{
    public class UserRegisterModel
    {             
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

