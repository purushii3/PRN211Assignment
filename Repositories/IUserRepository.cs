using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetUserById(int id);
        User GetUserByUserName(string userName);
        void SaveUser(User user);
        void DeleteCustomer(User user);
        void UpdateCustomer(User user);
    }
}
