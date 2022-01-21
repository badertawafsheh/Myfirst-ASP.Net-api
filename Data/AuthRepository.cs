using first_web_api.Models;
using System.Threading.Tasks;

namespace first_web_api.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public Task<ServiceResponse<int>> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            _context.Users.Add(user);   
            await _context.SaveChangesAsync();
            ServiceResponse<int> response = new ServiceResponse<int>();
            response.Data = user.Id;
            return response;    
        } 

        public Task<bool> userExist(string username)
        {
            throw new System.NotImplementedException();
        }

        

    }
}
