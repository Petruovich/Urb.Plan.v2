using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Urb.Domain.Urb.Models;
using Urb.Plan.v2.Views;

namespace Urb.Plan.v2.Mapper
{
    public class AutoMapperProfile: Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegisterModel, IdentityUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src =>  src.Password));

            CreateMap<User, AuthenticateRequest>();

            //CreateMap<UpdateRequest, User>()

        }
    }
}
