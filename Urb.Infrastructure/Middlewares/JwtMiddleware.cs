using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urb.Plan.v2.IServices;
using Urb.Plan.v2.Services;

namespace Urb.Infrastructure.Middlewares
{
    internal class JwtMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        IUserService _service;

        public JwtMiddleware (RequestDelegate requestDelegate, IUserService service)
        {
            _service = service;
            _requestDelegate = requestDelegate;
        }

        public RequestDelegate Invoke(IJWTService jWTService ,HttpContext httpContext, IUserService userService)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jWTService.ValidateToken(token);
            if (userId != null)
            {
                httpContext.Items["User"] = _service.GetUser(userId.Value);
            }
            
            return _requestDelegate;
        }
    }
}
