using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{

   
    public class Account
    {
        public int id { get; }
        public double balance { get; set; }

        public double deposit { get; set;  }

        public double withdraw { get; set; }

        public User owner { get; set; }
    }
}
