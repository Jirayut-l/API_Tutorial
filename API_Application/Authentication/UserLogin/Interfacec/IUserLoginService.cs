using System.Collections.Generic;
using API_Model;

namespace API_Application

{
    public interface IUserLoginService
    {
        IEnumerable<UserLoginModel> GetAllUser();
        UserLoginModel GetUserLogin(int p);
        void Create(UserLoginModel model);
        void Delete(int pkUid);
        void Update(int pkUid, UserLoginModel model);
        void UpdateRange(IEnumerable<UserLoginModel> models);


    }
}