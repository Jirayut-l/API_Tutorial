namespace API_Infrastructure
{
    public interface IRevokeTokenRepository
    {
        void RevokeToken(string token, string ipAddress);
    }
}