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
namespace Postman.App.Admin
{
    public partial class AdminDashboardProt : Form
    {
        User user { get; set; }
        Account acc { get; set; }

        AccountRepository accountRepo = new AccountRepository();
        public AdminDashboardProt()
        {
            InitializeComponent();
            
        }

        public AdminDashboardProt(User user, int totalUser, int delivery)
        {
            InitializeComponent();
            this.user = user;
            acc = accountRepo.GetOneAccount(user.id);
            totalParcel.Text = delivery.ToString();
            totalUserCount.Text = totalUser.ToString();
            todayParcel.Text = delivery.ToString();
            deliveryTodayLabel.Text = delivery.ToString();
            parcelThisMonth.Text = delivery.ToString();
            userThisMonth.Text = totalUser.ToString();
            userAddress.Text = user.pickupLocation !=null ? "Pickup location not set" : user.pickupLocation;
            loadAllData(user);
        }

        void loadAllData(User user)
        {
           if(acc != null)
            {
                totalBalance.Text = acc.balance.ToString();
                totalWithdraw.Text = acc.withdraw.ToString();
            }
            HomePageName.Text = user.name.ToString();
            userPhone.Text = user.phone.ToString();
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }
    }
}
