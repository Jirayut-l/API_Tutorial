using System.Collections.Generic;
using System.Linq;
using API_Model;
using AutoMapper;

namespace API_Infrastructure
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IMapper _mapper;
        private readonly API_TESTContext _apiTestContext;

        public RefreshTokenRepository(IMapper mapper)
        {
            _mapper = mapper;
            _apiTestContext = new API_TESTContext();
        }

        public void CreateRefreshToken(RefreshTokenModel model)
        {
            var entity = _mapper.Map<RefreshToken>(model);
            _apiTestContext.RefreshToken.Add(entity);
            _apiTestContext.SaveChanges();
        }

        public RefreshTokenModel GetRefreshTokenByToken(string token)
        {
            var entity = (from refreshToken in _apiTestContext.RefreshToken
                where refreshToken.Token == token
                select refreshToken).FirstOrDefault();
            return _mapper.Map<RefreshTokenModel>(entity);
        }

        public IEnumerable<RefreshTokenModel> GetAll()
        {
            var entity = _apiTestContext.RefreshToken.ToList();
            return _mapper.Map<IEnumerable<RefreshTokenModel>>(entity);
        }
    }
}