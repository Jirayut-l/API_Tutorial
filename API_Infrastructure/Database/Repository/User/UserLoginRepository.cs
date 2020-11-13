using System.Collections.Generic;
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
        public IEnumerable<UserLoginModel> GetAllUserLogin()
        {
            return _mapper.Map<IEnumerable<UserLoginModel>>(_apiTestContext.UserLogin);
        }

        public UserLoginModel Authenticate(AuthenticateRequestModel model)
        {
            var entity = _apiTestContext.UserLogin.FirstOrDefault(f => f.Username == model.Username && f.Password == model.Password);
            if (entity == null) return new UserLoginModel();
            return _mapper.Map<UserLoginModel>(entity);
        }

        public UserLoginModel GetUserLoginByUsername(string username)
        {
            var entity = _apiTestContext.UserLogin.FirstOrDefault(f => f.Username == username);
            if (entity == null) return new UserLoginModel();
            return _mapper.Map<UserLoginModel>(entity);
        }

        public UserLoginModel GetUserLoginByPK(int pkUid)
        {
            var entity = _apiTestContext.UserLogin.Find(pkUid);
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
            //var entity = _apiTestContext.UserLogin.FirstOrDefault(f => f.PkUid == pkUid);
            var entity = _apiTestContext.UserLogin.Find(pkUid);
            if (entity == null) return;
            _apiTestContext.UserLogin.Remove(entity);
            _apiTestContext.SaveChanges();
        }

        public void Update(int pkUid, UserLoginModel model)
        {
            //var entity = _apiTestContext.UserLogin.FirstOrDefault(f => f.PkUid == pkUid);
            //if(entity==null)return;
            //entity.Password = model.Password;
            //entity.Username = model.Username;
            model.PkUid = pkUid;
            _apiTestContext.Update(_mapper.Map<UserLogin>(model));
            _apiTestContext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<UserLoginModel> models)
        {
            _apiTestContext.UpdateRange(_mapper.Map<IEnumerable<UserLogin>>(models));
            _apiTestContext.SaveChanges();
        }
    }
}