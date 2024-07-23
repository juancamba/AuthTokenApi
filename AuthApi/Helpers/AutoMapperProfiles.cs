using AuthApi.Data;
using AuthApi.Dto;
using AutoMapper;

namespace AuthApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {


            CreateMap<RegisterDto, AppUser>();


        }
    }
}
