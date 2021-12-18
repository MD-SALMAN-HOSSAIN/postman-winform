using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        ONDELIVERY,
        DELIVERED,
        CANCELLED
    }
    public class Parcel
    {
        public int id { get; }
        public string invoiceNo { get; set; }

        public DeliveryMethod paymetMethod { get; set; }

        public double packageWeight { get; set; }

        public double amountToCollect { get; set; }

        public double deliveryFee { get; set; }

        [EnumDataType(typeof(DeliveryStatus))]
        public DeliveryStatus parcelStatus { get; set; }

        public Customer customer { get; set; }


        public User rider { get; set; }

        public DateTime createdAt {get; set;}

    }
}
