using first_web_api.Models;
using System.Threading.Tasks;

namespace first_web_api.Data
{
    public class AuthRepository : IAuthRepository
    {
        public Task<ServiceResponse<int>> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<int>> Register(User user, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> userExist(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}
