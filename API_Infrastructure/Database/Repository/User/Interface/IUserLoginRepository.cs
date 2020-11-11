using System.Collections.Generic;
using API_Model;

namespace API_Infrastructure
{
    public interface IUserLoginRepository
    {
        IEnumerable<UserLoginModel> GetAllUserLogin();
        UserLoginModel GetUserLogin(int pkUid);
        void Create(UserLoginModel model);
        void Delete(int pkUid);
        void Update(int pkUid, UserLoginModel model);
        void UpdateRange(IEnumerable<UserLoginModel> models);

    }
}