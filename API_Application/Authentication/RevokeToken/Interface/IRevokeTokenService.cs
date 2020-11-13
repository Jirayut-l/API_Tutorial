using System.Threading.Tasks;
using API_Model;

namespace API_Application
{
    public interface IRevokeTokenService
    {
        Task<Result> RevokeToken(string token, string ipAddress);
    }
}