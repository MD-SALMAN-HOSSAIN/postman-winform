using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postman.DataAccess;
using Postman.Models;
namespace Postman.Repository
{
    class WithdrawRepository
    {

        public int? CreateOne(Withdraw withdraw, int userId)
        {
            return ConnectionDB.ExecuteQuery("INSERT INTO  withdraw VALUES(@accountNumber, @amount, @status,@method ,CURRENT_TIMESTAMP , null, @userId);",
                new { withdraw.accountNumber, withdraw.amount,method= withdraw.bankName, status ="PENDING", withdraw.createdAt, userId });
        }


        public List<Withdraw> GetAllByUser(int userId)
        {
            return ConnectionDB.SelectQuery<Withdraw>("SELECT * FROM withdraw WHERE userId= @userId;", new { userId }).ToList();
        }

        public int? ChangeStatus(int id, string status)
        {
            return ConnectionDB.ExecuteQuery("UPDATE withdraw SET status=@status WHERE id= @id;", new { id, status });
        }


        public List<Withdraw> GetAll()
        {
            return ConnectionDB.SelectQuery<Withdraw>("SELECT * FROM withdraw;").ToList();
        }

        public Withdraw GetOne(int id)
        {
            return ConnectionDB.SelectQuery<Withdraw>("SELECT * FROM withdraw WHERE id=@id;", new { id }).SingleOrDefault();
        }
        public int? UpdateOne(Withdraw withdraw, int userId)
        {
            return ConnectionDB.ExecuteQuery(@"	UPDATE withdraw 
			                                    SET accountNumber=@accountNumber,
				                                    amount=@amount,
				                                    status=@status,
				                                    proccessAt= CURRENT_TIMESTAMP
			                                    WHERE id=@id;",
                        new { withdraw.accountNumber, withdraw.amount, withdraw.status, userId });
        }


        public int? DeleteOne(int id)
        {
            return ConnectionDB.ExecuteQuery("DELETE FROM withdraw WHERE id=@id", new { id });
        }
    }



}
