using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public class Customer
    {
        public int id { get; }
        public string name { get; set; }

        public string phone { get; set; }


        public string address { get; set; }

        public string area { get; set; }
        
        public string city { get; set; }


        public User owner { get; set; }

    }
}
