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

        public void DeleteCustomer(User user)
        {
            _userRepository.DeleteCustomer(user);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User GetUserByUserName(string userName)
        {
            return _userRepository.GetUserByUserName(userName);
        }

        public void SaveUser(User user)
        {
            _userRepository.SaveUser(user);
        }

        public List<User> SearchByName(string fullName)
        {
            return _userRepository.SearchByName(fullName);
        }

        public void UpdateCustomer(User user)
        {
            _userRepository.UpdateCustomer(user);
        }
    }
}
