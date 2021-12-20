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

        CallbackDelegate loadGridView { get; set; }
        public UniformWIthdraw()
        {
            InitializeComponent();
        }

        public UniformWIthdraw(User user, CallbackDelegate callback)
        {
            InitializeComponent();
            this.user = user;
            this.loadGridView = callback;
            var account = new AccountRepository().GetOneAccount(user.id);
            if(account !=null)
            {
                balanceLabel.Text = account.balance.ToString();
                balance = Convert.ToDouble(account.balance);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(balance >= Convert.ToDouble(amountBox.Text))
            {
                Withdraw withdraw = new Withdraw() { 
                    
                    accountNumber= accountNumber.Text,
                    amount = Convert.ToDouble(amountBox.Text),
                    bankName= paymentMethod.Text
                };
                try
                {
                    var result = new WithdrawRepository().CreateOne(withdraw, user.id);
                    if (result > 0)
                    {
                        MessageBox.Show("Successfully created request");
                        var account = new AccountRepository().GetOneAccount(user.id);
                        if(account != null)
                        {
                            var reflect = new AccountRepository().CreateWithdrawRequst(withdraw.amount, account.balance - withdraw.amount,user.id);
                            if(reflect <= 0) MessageBox.Show("Failed to create request!");
                        }
                        loadGridView();
                    }
                    else MessageBox.Show("Failed to create request!");
                }
                catch(Exception err)
                {
                    MessageBox.Show("Error"+ err.Message);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
