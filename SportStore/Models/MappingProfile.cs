using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace SportStore.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<LoginModel, IdentityUser>().ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
    }
    }
}
