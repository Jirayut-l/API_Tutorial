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
            CreateMap<UserLoginModel, UserLogin>();
            CreateMap<EmployeeModel, Employee>();
            CreateMap<Employee, EmployeeModel>();
            CreateMap<RefreshToken, RefreshTokenModel>();
            CreateMap<RefreshTokenModel, RefreshToken>();
        }
    }
}
