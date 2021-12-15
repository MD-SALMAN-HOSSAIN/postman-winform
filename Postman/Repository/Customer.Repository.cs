using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postman.DataAccess;
using Postman.Models;
namespace Postman.Repository
{
    public class CustomerRepostiroy
    {

        // CREATE 
        public bool CreateCustomer (Customer customer)
        {
            var query = ConnectionDB.ExecuteQuery("INSERT INTO customer VALUES (@name, @phone, @address, @area, @city);", new { customer.name, customer.phone, customer.address, customer.area, customer.city});

            if (query > 0) return true;

            return false;
        }

        // GET ALL
        public List<Customer> getAllCustomer ()
        {
            return ConnectionDB.SelectQuery<Customer>("SELECT * FROM customer;").ToList<Customer>();
        }


        // GET ONE
        public List<Customer> getOneCustomer(int userId)
        {
            return ConnectionDB.SelectQuery<Customer>("SELECT * FROM customer WHERE userId=@userId", new { userId }).ToList<Customer>();
        }


        // UPDATE ONE
        public int? UpdateOneCustomer(int id, Customer customer)
        {
            return ConnectionDB.ExecuteQuery(@"UPDATE customer 
	                                                SET name=@name,
		                                                phone=@phone,
		                                                address= @address,
		                                                area=@area,
		                                                city=@city
	                                                WHERE id=@id;
                                                    ", new { id, customer.name, customer.phone, customer.address, customer.area, customer.city });
      
        }

        // DELETE ONE

        public int? DeleteCustomer(int id)
        {
            return ConnectionDB.ExecuteQuery(@"DELETE FROM users WHERE id= @id;", new { id });
        }
    }
}
