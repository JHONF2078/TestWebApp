
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.DataAccess.Interfaces;
using TestWebApp.Entities;

namespace TestWebApp.Business.services
{
    public class UserService : IUserService
    {

        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            return await _userRepository.GetAsync(
                 orderBy: q => q.OrderBy(u => u.Id)
             );
        }
    }
}
