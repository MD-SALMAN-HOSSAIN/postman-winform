using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{

    public enum WithdrawStatus
    {
        PENDING,
        CONFIRM,
        PROCCESSED,
        REJECTED
    }
    public class Withdraw
    {
        public string accountNumber { get; set; }

        public string bankName { get; set; }

        public double amount { get; set; }

        public WithdrawStatus status { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime proccessedAt { get; set; }


        public User owner { get; set; }

    }
}
