using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urb.Infrastructure.Middlewares
{
    internal class JwtMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public JwtMiddleware (RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public RequestDelegate Invoke(/*IJwtUtils jwtUtils*/ HttpContext httpContext/*, UserService userService*/)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            //var userId = jwtutils.ValidateToken(token);
            //if (user != null)
            //{
            //    httpContext.Items["User"] = usrService.GetById(userId.Value);
            //}
               
            
            return _requestDelegate;
        }

    }
}
