using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        // readonly dynamic _userDao = new UserDAO();
        public void DeleteCustomer(User user) => UserDAO.DeleteCustomer(user);

        public List<User> GetAll() => UserDAO.GetAll();
        
        public User GetUserById(int id) => UserDAO.GetUserById(id);

        public User GetUserByUserName(string userName) => UserDAO.GetUserByUserName(userName);

        public void SaveUser(User user) => UserDAO.SaveUser(user);


        public void UpdateCustomer(User user) => UserDAO.UpdateCustomer(user);
    }
}
