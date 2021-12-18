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
        public bool CreateCustomer (Customer customer, int userId)
        {
            var query = ConnectionDB.ExecuteQuery("INSERT INTO customer VALUES (@name, @phone, @address, @area, @city, @userId);", new { customer.name, customer.phone, customer.address, customer.area, customer.city, userId});

            if (query > 0) return true;

            return false;
        }

        // GET ALL
        public List<Customer> getAllCustomer (User user)
        {
            return ConnectionDB.SelectQuery<Customer>("SELECT * FROM customer where userId=@id;", new { user.id }).ToList<Customer>();
        }


        // GET ONE
        public Customer getOneCustomer(string phone)
        {
            return ConnectionDB.SelectQuery<Customer>("SELECT * FROM customer WHERE phone=@phone", new { phone }).SingleOrDefault<Customer>();
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
