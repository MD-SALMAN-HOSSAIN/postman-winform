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


        public AddParcel()
        {
            InitializeComponent();
        }

        public AddParcel(User user)
        {
            this.user = user;
           
            InitializeComponent();
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
            parcelRepo.createone(new Parcel
            {
                invoiceNo = inovicetext.Text,
                amountToCollect = Convert.ToDouble(ammountToCollect.Text),
                deliveryFee = 80,
                customer = customer,
                paymetMethod = methodType.Text == "ONLINE" ? DeliveryMethod.ONLINE : DeliveryMethod.CASH,
            },  user.id);
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
