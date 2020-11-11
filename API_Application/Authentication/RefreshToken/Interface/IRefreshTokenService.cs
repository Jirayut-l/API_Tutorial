﻿using System.Collections.Generic;
using API_Model;

namespace API_Application
{
    public interface IRefreshTokenService
    {
        void CreateRefreshToken(RefreshTokenModel model);
        RefreshTokenModel GetRefreshTokenByToken(string token);
        IEnumerable<RefreshTokenModel> GetAll();
    }
}