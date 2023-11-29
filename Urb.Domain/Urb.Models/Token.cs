using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urb.Domain.Urb.Models
{
    public class Token
    {
        [Key]
        public string TokenId { get; set; }
        public User User { get; set; }   
        //public int? UserId { get; set; } /*= 0;*/
        public string Access_Token { get; set; }   
    }
}
