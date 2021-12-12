using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public class User
    {
        public string name { get; set; }

        public string password {get; set;}

        public string userRole {get; set;}

        public string email {get; set;}

        public string phone {get; set;}

        public byte[] image {get; set;}
    }

}
