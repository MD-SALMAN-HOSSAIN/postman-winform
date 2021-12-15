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

        List<Customer> customer { get; set; }

        List<string> customerNames { get; set; }

        ParcelRepositry parcelRepo = new ParcelRepositry();

        User user { get; set; }

        Customer selectedCustomer { get; set; }

        CustomerRepostiroy customerRepo = new CustomerRepostiroy();
        public AddParcel()
        {
            InitializeComponent();
        }

        public AddParcel(User user)
        {
            this.user = user;
            if (user != null) customer = customerRepo.getOneCustomer(user.id);
            else customer = customerRepo.getAllCustomer();
            if(customer != null)
            {
                customer.ForEach(e => customerNames.Add(e.name));
                customerData.DataSource = customerNames;
            }
            
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            parcelRepo.createone(new Parcel
            {
                invoiceNo = inovicetext.Text,
                amountToCollect = Convert.ToDouble(ammountToCollect.Text),
                deliveryFee = 80,
                customer = selectedCustomer,
                paymetMethod = methodType.Text == "ONLINE" ? DeliveryMethod.ONLINE : DeliveryMethod.CASH
            }, selectedCustomer.id, user.id);
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomer = customer.Find(item => item.name.Contains(customerData.Text));
        }
    }
}
