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
namespace Postman.App.Merchent
{
    public partial class MarchentDashboardProt : Form
    {
        User user { get; set; }
        List<Parcel> parcelList { get; set; }
        List<Customer> customerList { get; set; }

        ParcelRepositry pr = new ParcelRepositry();

        CustomerRepostiroy cr = new CustomerRepostiroy();
        public MarchentDashboardProt()
        {
            InitializeComponent();
        }

        public MarchentDashboardProt(User user)
        {
            InitializeComponent();
            this.user = user;
            if (user != null)
            {
                userName.Text = user.name;
                addressLabel.Text = user.pickupLocation;
                phoneLabel.Text = user.phone;
                parcelList = pr.getAllUser(user.id);
                customerList = cr.getAllCustomer(user);
                customerCounts.Text = $"{customerList.Count}";
                ParcelCount.Text = $"{parcelList.Count}";
                todayParcel.Text =$"{parcelList.Count}" ;
                DeliveredToday.Text = $"{parcelList.FindAll(elem => elem.createdAt.Day == new DateTime().Day && elem.status == "DELIVERED").Count}";
                ParcelThisMonth.Text = $"{parcelList.FindAll(elem => elem.createdAt.Month == new DateTime().Day).Count}";
                CustomerThisMonth.Text = $"{customerList.Count}";
            }
           
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
