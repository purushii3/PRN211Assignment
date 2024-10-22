using BusinessObjects.Models;

namespace DataAccessLayer
{
    public class UserDAO
    {
        public static User GetUserByUserName(string userName)
        {
            using var db = new KoiFishContext();
            return db.Users.FirstOrDefault(x => x.UserName.Equals(userName));
        }
    }
}
