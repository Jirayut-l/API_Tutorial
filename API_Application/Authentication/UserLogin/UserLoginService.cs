﻿using System.Collections.Generic;
using API_Infrastructure;
using API_Model;

namespace API_Application
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public UserLoginService(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public IEnumerable<UserLoginModel> GetAllUser()
        {
            return _userLoginRepository.GetAllUserLogin();
        }

        public UserLoginModel Authenticate(AuthenticateRequestModel model)
        {
            return _userLoginRepository.Authenticate(model);
        }

        public UserLoginModel GetUserLoginByUsername(string username)
        {
            return _userLoginRepository.GetUserLoginByUsername(username);
        }

        public UserLoginModel GetUserLoginByPK(int pkUid)
        {
            return _userLoginRepository.GetUserLoginByPK(pkUid);
        }

        public void Create(UserLoginModel model)
        {
            _userLoginRepository.Create(model);
        }

        public void Delete(int pkUid)
        {
           _userLoginRepository.Delete(pkUid);
        }

        public void Update(int pkUid, UserLoginModel model)
        {
            _userLoginRepository.Update(pkUid,model);
        }

        public void UpdateRange(IEnumerable<UserLoginModel> models)
        {
           _userLoginRepository.UpdateRange(models);
        }
    }
}