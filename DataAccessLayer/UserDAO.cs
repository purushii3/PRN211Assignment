using BusinessObjects.Models;

namespace DataAccessLayer
{
    public class UserDAO
    {
        private static readonly KoiFishContext _db;
        public static List<User> GetAll()
        {
            var listUser = new List<User>();
            try
            {
                listUser = _db.Users.Where(x => x.Status == true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUser;

        }

        public static User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(x => x.UserId == id);
        }

        public static User GetUserByUserName(string userName)
        {
            using var db = new KoiFishContext();
            return db.Users.FirstOrDefault(x => x.UserName.Equals(userName));
        }

        public static void SaveUser(User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteCustomer(User user)
        {
            try
            {
                var u = _db.Users.SingleOrDefault(x => x.UserId == user.UserId);
                if (u != null)
                {
                    u.Status = false;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateCustomer(User user)
        {
            try
            {
                _db.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
