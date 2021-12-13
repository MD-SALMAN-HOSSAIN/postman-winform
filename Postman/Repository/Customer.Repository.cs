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
        public bool CreateCustomer (Customer customer)
        {
            var query = ConnectionDB.ExecuteQuery("INSERT INTO customer VALUES (@name, @phone, @address, @area, @city);", new { customer.name, customer.phone, customer.address, customer.area, customer.city});

            if (query > 0) return true;

            return false;
        }


        public List<Customer> getAllCustomer ()
        {
            return ConnectionDB.SelectQuery<Customer>("SELECT * FROM customer;").ToList<Customer>();
        }

        public Customer getOneCustomer(int id)
        {
            return ConnectionDB.SelectQuery<Customer>("SELECT * FROM customer WHERE id=@id", new { id }).FirstOrDefault<Customer>();
        }

    }
}
