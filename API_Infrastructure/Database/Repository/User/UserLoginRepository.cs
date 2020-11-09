using System.Linq;
using API_Model;
using AutoMapper;

namespace API_Infrastructure
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly IMapper _mapper;
        private readonly API_TESTContext _apiTestContext;

        public UserLoginRepository(IMapper mapper /*, API_TESTContext apiTestContext*/)
        {
            _mapper = mapper;
            //_apiTestContext = apiTestContext;
            _apiTestContext = new API_TESTContext();
        }
        public UserLoginModel GetAllUserLogin()
        {
            var entity = _apiTestContext.UserLogin.FirstOrDefault();
            return _mapper.Map<UserLoginModel>(entity);
        }

        public void Create(UserLoginModel model)
        {
            var entity = _mapper.Map<UserLogin>(model);
            _apiTestContext.UserLogin.Add(entity);
            _apiTestContext.SaveChanges();
        }

        public void Delete(int pkUid)
        {
            var entity = _apiTestContext.UserLogin.FirstOrDefault(f => f.PkUid == pkUid);
            if(entity==null) return;
            _apiTestContext.UserLogin.Remove(entity);
            _apiTestContext.SaveChanges();
        }
    }
}