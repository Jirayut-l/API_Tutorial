using API_Infrastructure;
using API_Model;
using AutoMapper;

namespace API_Infrastructure
{
    public class AutoMappingService : Profile
    {
        public AutoMappingService()
        {
            CreateMap<UserLogin,UserLoginModel>();
        }
    }
}
