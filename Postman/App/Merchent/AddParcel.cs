using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Postman.Repository;
using Postman.Models;
namespace Postman.App.Merchent
{
    public partial class AddParcel : Form
    {


       

        ParcelRepositry parcelRepo = new ParcelRepositry();

        User user { get; set; }

        CallbackDelegate Loadgridviewcallback { get; set; }
        public AddParcel()
        {
            InitializeComponent();
        }

        public AddParcel(User user, CallbackDelegate callback)
        {
            this.user = user;
           
            InitializeComponent();
            Loadgridviewcallback = callback;
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer()
            {
                address = customerAddress.Text,
                city = customerCity.Text,
                area = customerArea.Text,
                name = customerName.Text,
                phone = customerPhone.Text
            };
            try
            {
                var count = parcelRepo.createone(new Parcel
                {
                    invoiceNo = inovicetext.Text,
                    amountToCollect = Convert.ToDouble(amountToCollect.Text),
                    deliveryFee = 80,
                    parcelStatus= DeliveryStatus.PENDING,
                    customer = customer,
                    paymetMethod = methodType.Text == "ONLINE" ? DeliveryMethod.ONLINE : DeliveryMethod.CASH,
                }, user.id);
                if (count > 0)
                {
                     var result = MessageBox.Show("Successfully created parcel", "SUCCESS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                     if (result == DialogResult.Retry)
                    {
                        inovicetext.Text = "";
                        amountToCollect.Text = "";
                        methodType.Text = "";
                        weight.Text = "";
                        Loadgridviewcallback();
                    }
                     else if(result == DialogResult.Cancel)
                    {
                        this.Hide();
                        Loadgridviewcallback();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to create parcel," + error.Message, "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
