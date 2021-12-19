using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Postman.Models;
using Postman.Repository;
namespace Postman.App
{
    public partial class UniformWIthdraw : Form
    {
        User user { get; set; }
        Double balance { get; set; }
        public UniformWIthdraw()
        {
            InitializeComponent();
        }

        public UniformWIthdraw(User user)
        {
            InitializeComponent();
            this.user = user;

            var account = new AccountRepository().GetOneAccount(user.id);
            if(account !=null)
            {
                balanceLabel.Text = account.balance.ToString();
                balance = Convert.ToDouble(account.balance);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(balance <= Convert.ToDouble(amountBox.Text))
            {
                Withdraw withdraw = new Withdraw() { 
                    
                    accountNumber= accountNumber.Text,
                    amount = Convert.ToDouble(amountBox.Text),
                    
                    bankName= paymentMethod.Text
                };
                try
                {
                    var result = new WithdrawRepository().CreateOne(withdraw, user.id);
                    if (result > 0) MessageBox.Show("Successfully created request");
                }
                catch(Exception err)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
