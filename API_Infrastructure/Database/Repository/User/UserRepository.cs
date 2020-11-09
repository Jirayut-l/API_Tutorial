using System.Linq;
using API_Model;
using AutoMapper;

namespace API_Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly API_TESTContext _apiTestContext;

        public UserRepository(IMapper mapper)
        {
            _mapper = mapper;
            _apiTestContext = new API_TESTContext();
        }
        public UserLoginModel GetUserLogin()
        {
            var entity = _apiTestContext.UserLogin.FirstOrDefault();
            return _mapper.Map<UserLoginModel>(entity);
        }
    }
}