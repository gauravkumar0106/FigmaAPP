using System.Threading.Tasks;
using Figma.API.Models;

namespace Figma.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
          Task<User> Login(string username, string password);
           Task<bool> UserExists(string username);
    }
}