using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApp.Entities;

namespace TestWebApp.Business.services
{
    public interface IUserService
    {
        Task<IReadOnlyList<User>> GetAllAsync();
    }
}
