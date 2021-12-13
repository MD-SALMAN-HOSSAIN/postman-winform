using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postman.DataAccess;
using Postman.Models;
namespace Postman.Repository
{
    public class UserRepository
    {
        // Login

        public bool VerifyUser (string email, string password)
        {
            var result = ConnectionDB.SelectQuery<User>("SELECT * FROM users WHERE email=@email and password=@password;", new { email, password });

            if(result.Count ==1)
            {
                return true;
            }
            return false;
        }

        public bool RegisterUser (User user)
        {
            var query = ConnectionDB.ExecuteQuery("INSERT INTO users VALUES (@name, @email,@password,@userRole, @phone);", new { user.name, user.email, user.password, user.userRole, user.phone });
            if (query > 0) return true;
            return false;
        }
    }
}
