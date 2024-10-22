using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByUserName(string userName) => UserDAO.GetUserByUserName(userName);
    }
}
