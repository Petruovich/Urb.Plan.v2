using Urb.Domain.Urb.Models;

namespace Urb.Plan.v2.IServices
{
    public interface IJWTService
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
        
    }
}
