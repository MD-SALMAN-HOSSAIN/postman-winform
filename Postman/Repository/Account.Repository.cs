using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postman.DataAccess;
using Postman.Models;
namespace Postman.Repository
{
    public class AccountRepository
    {
        public int? CreateOne(int userId)
        {
            return ConnectionDB.ExecuteQuery("INSERT INTO account (userId) VALUES (@userId);", new { userId});
        }

        public Account GetAllAccount()
        {
            return ConnectionDB.SelectQuery<Account>("SELECT * FROM account;").SingleOrDefault();
        }

        public Account GetOneAccount(int userId)
        {
            return ConnectionDB.SelectQuery<Account>("SELECT * FROM account WHERE userId=@userId", new { userId }).SingleOrDefault();
        }
 

        public int? WithdrawFromAccount(Account account, int id)
        {
            return ConnectionDB.ExecuteQuery(@"
	                            UPDATE account 
		                            SET balance=@balance,
			                            withdraw=@withdraw
		                            WHERE id=@id;",
                    new { account.balance, account.withdraw, id });
        }

        public int? AddIncomeToAccount(double balance, double deposit, int id)
        {
            return ConnectionDB.ExecuteQuery(@"
	                            UPDATE account 
		                            SET balance=@balance,
                                        deposit=@deposit
		                            WHERE id=@id;",
                    new { balance, deposit, id });
        }
    }
}
