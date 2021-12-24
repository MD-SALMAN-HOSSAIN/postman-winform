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
namespace Postman.App.Rider
{
    public partial class RiderDashboardProt : Form
    {
        User user { get; set; }
        List<Parcel> parcelList { get; set; }
        List<Parcel> riderParcel { get; set; }

        ParcelRepositry parcelRepo = new ParcelRepositry();
        public RiderDashboardProt()
        {
            InitializeComponent();
        }

        public RiderDashboardProt(User user )
        {
            InitializeComponent();
            if (user != null)
            {
                this.user = user;
                UserName.Text = user.name;
                emailRider.Text = user.email;
                phoneRider.Text = user.phone;
            }

            try
            {
                parcelList = parcelRepo.getAll().FindAll(e => e.status == "PENDING");
                riderParcel = parcelRepo.getRiderParcel(user.id);
                parcelToday.Text = $"{parcelList.Count}";
                parcelThisMonth.Text = $"{riderParcel.FindAll(e=> e.createdAt.Month == new DateTime().Month).Count}";
                deliveredParcels.Text = $"{riderParcel.FindAll(e => e.status == "DELIVERED").Count}";
                pendingDelivery.Text = $"{riderParcel.FindAll(e => e.status == "ONDELIVERY").Count}";
                deliveredThisMonth.Text = $"{riderParcel.FindAll(e => e.createdAt.Month == new DateTime().Month).Count}";
            }
            catch(Exception eer)
            {
                MessageBox.Show("Error occured" + eer.Message, "ERROR");
            }
        }
    }
}
