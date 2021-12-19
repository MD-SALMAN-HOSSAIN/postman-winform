using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public enum UserRole
    {
        ADMIN,
        RIDER,
        MARCHENT,
        BANNED
    }
    public class User
    {
        public int  id {get;}
        public string name { get; set; }

        public string password {get; set;}

        public UserRole userRole {get; set;}

        public string email {get; set;}

        public string phone {get; set;}

        public string pickupLocation { get; set; }

        public DateTime createdAt { get; set; }

    }

}
