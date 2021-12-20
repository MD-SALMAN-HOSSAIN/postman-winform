using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postman.DataAccess;
using Postman.Models;
using Postman.Repository;
namespace Postman.Repository
{

    public enum SignUPStatus
    {
        SUCCESS,
        FAILED,
        EXISTS
    }
    public class UserRepository
    {
        // Login

        
        AccountRepository acc = new AccountRepository();
        public bool VerifyUser (string email, string password)
        {
            var result = ConnectionDB.SelectQuery<User>("SELECT * FROM users WHERE email=@email and password=@password;", new { email, password });
            if(result.Count ==1) return true;
            return false;
        }

        public User GetUserInfo(string email)
        {
            return ConnectionDB.SelectQuery<User>("SELECT * FROM users WHERE email=@email ;", new { email }).SingleOrDefault();
        }

        public User GetOneUser(int id)
        {
            return ConnectionDB.SelectQuery<User>("SELECT * FROM users WHERE id=@id", new { id }).SingleOrDefault();
        }

        public List<User> GetAll()
        {
            return ConnectionDB.SelectQuery<User>("SELECT * FROM users;").ToList();
        }

        public SignUPStatus RegisterUser (User user)
        {
            var result = ConnectionDB.SelectQuery<User>("SELECT * FROM users WHERE email=@email;", new { user.email });
            if (result.Count == 1) return SignUPStatus.EXISTS;
            var query = ConnectionDB.ExecuteQuery("INSERT INTO users VALUES (@name, @email,@password,@userRole, @phone, @pickupLocation, CURRENT_TIMESTAMP);", new { user.name, user.email, user.password, user.userRole, user.phone, user.pickupLocation });
            if (query > 0)
            {
                var userInfo = this.GetUserInfo(user.email);
                if(userInfo != null)
                {
                    var account = acc.CreateOne(userInfo.id);
                    if (account > 0) Console.WriteLine("Account Created successfully");
                    else Console.WriteLine("Something went wrong, " + account);
                }
                return SignUPStatus.SUCCESS;
            }
            return SignUPStatus.FAILED;
        }

        public int? UpdateUser(User user, int id)
        {
            
            return ConnectionDB.ExecuteQuery(@"UPDATE users
			                                            SET  
				                                            name = @name,
				                                            email = @email,
				                                            pickupLocation = @pickupLocation
			                                            WHERE id=@id;",
                                                       new { user.name, user.email,user.pickupLocation, id });
        }

        public int? UpdateUserWithPassword(User user, int id)
        {
            
            return ConnectionDB.ExecuteQuery(@"UPDATE users
			                                        SET  
				                                        name = @name,
				                                        email = @email,
				                                        password=@password,
				                                        pickupLocation = @pickupLocation
			                                        WHERE id=@id;",
                                                    new { user.name, user.email, user.password, user.pickupLocation, id });
           
        }
    }
}
