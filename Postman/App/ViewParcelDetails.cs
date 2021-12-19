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
    public partial class ViewParcelDetails : Form
    {
        ParcelRepositry parcelRepo = new ParcelRepositry();
        UserRepository userRepo = new UserRepository();
        Parcel parcel { get; set; }
        public ViewParcelDetails()
        {
            InitializeComponent();
        }

        public ViewParcelDetails(int id)
        {
            InitializeComponent();
            parcel = parcelRepo.getOneParcel(id);
            if(parcel != null)
            {
                invoiceText.Text = parcel.invoiceNo;
                collectionAmountText.Text = parcel.amountToCollect.ToString();
                paymentMethodText.Text = parcel.method;
                deliveryFeeText.Text = parcel.deliveryFee.ToString();
                statusText.Text = parcel.status;
                packageWeightText.Text = parcel.packageWeight.ToString();
                if(parcel.customer != null)
                {
                    customerNameText.Text = parcel.customer.name;
                    customerAddressText.Text = parcel.customer.address;
                    customerCityText.Text = parcel.customer.city;
                    customerPhoneText.Text = parcel.customer.phone;
                    customerAreaText.Text = parcel.customer.area;
                }
                var rider = userRepo.GetOneUser(parcel.riderId);
                if(rider != null)
                {
                    riderEmailText.Text = rider.email;
                    riderNameText.Text = rider.name;
                    riderPhoneText.Text = rider.phone;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
