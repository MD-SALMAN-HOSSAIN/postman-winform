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
using System.Windows.Forms.DataVisualization.Charting;

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

        public AdminDashboardProt(User user, List<User> totalUser, List<Parcel> delivery)
        {
            InitializeComponent();
            this.user = user;
            acc = accountRepo.GetOneAccount(user.id);
            totalParcel.Text = delivery.Count.ToString();
            totalUserCount.Text = totalUser.ToString();
            todayParcel.Text = delivery.Count.ToString();
            deliveryTodayLabel.Text = delivery.Count.ToString();
            parcelThisMonth.Text = delivery.Count.ToString();
            userThisMonth.Text = totalUser.Count.ToString();
            userAddress.Text = user.pickupLocation !=null ? "Pickup location not set" : user.pickupLocation;
            
            loadAllData(user);
            
        }

        void loadAllData(User user)
        {
          
            HomePageName.Text = user.name.ToString();
            userPhone.Text = user.phone.ToString();
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void totalUserCount_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
