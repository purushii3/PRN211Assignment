using BusinessObjects.Models;
using Repositories;

namespace Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserServices()
        {
            _userRepository = new UserRepository();
        }
        public User GetUserByUserName(string userName)
        {
            return _userRepository.GetUserByUserName(userName);
        }
    }
}
