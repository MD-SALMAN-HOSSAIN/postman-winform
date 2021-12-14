using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{

    public enum DeliveryMethod
    {
        ONLINE,
        CASH
    }

    public enum DeliveryStatus
    {
        PENDING,
        CONFIRMED,
        DELIVERY,
        DELIVERED,
        CANCELLED
    }
    public class Parcel
    {
        public string invoiceNo { get; set; }

        public DeliveryMethod paymetMethod { get; set; }
        
        public double packageWeight { get; set; }

        public double amountToCollect { get; set; }

        public double deliveryFee { get; set; }

        public DeliveryStatus parcelStatus { get; set; }

        public Customer customer { get; set; }


        public User rider { get; set; }


    }
}
