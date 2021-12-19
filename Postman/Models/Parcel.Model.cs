using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{

    

   
    public class Parcel
    {
        public int id { get; }
        public string invoiceNo { get; set; }

        public string method { get; set; }

        public double packageWeight { get; set; }

        public double amountToCollect { get; set; }

        public double deliveryFee { get; set; }

       
        public string status { get; set; }

        public Customer customer { get; set; }


        public User rider { get; set; }

        public int riderId { get; set; }
        public DateTime createdAt {get; set;}

    }
}
