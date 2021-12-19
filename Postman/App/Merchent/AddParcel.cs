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
                    parcelStatus="PENDING",
                    customer = customer,
                    paymetMethod =methodType.Text,
                    packageWeight= Convert.ToDouble(weight.Text),
                    createdAt = new DateTime()
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
                        customerAddress.Text = "";
                        customerArea.Text = "";
                        customerName.Text = "";
                        customerCity.Text = "";
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

        private void methodType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inovicetext_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inovicetext.Text))
            {
                inovicetext.Focus();
                errorProvider1.SetError(this.inovicetext, "Fill The Field");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void amountToCollect_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amountToCollect.Text))
            {
                amountToCollect.Focus();
                errorProvider2.SetError(this.amountToCollect, "Fill The Field");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void customerName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerName.Text))
            {
                customerName.Focus();
                errorProvider3.SetError(this.customerName, "Fill The Field");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void weight_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(weight.Text))
            {
                weight.Focus();
                errorProvider4.SetError(this.weight, "Fill The Field");
            }
            else
            {
                errorProvider4.Clear();
            }
            
        }

        private void customerPhone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerPhone.Text))
            {
                customerPhone.Focus();
                errorProvider5.SetError(this.customerPhone, "Fill The Field");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void customerArea_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerArea.Text))
            {
                customerArea.Focus();
                errorProvider6.SetError(this.customerArea, "Fill The Field");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void customerCity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerCity.Text))
            {
                customerCity.Focus();
                errorProvider7.SetError(this.customerCity, "Fill The Field");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void customerAddress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerAddress.Text))
            {
                customerAddress.Focus();
                errorProvider8.SetError(this.customerAddress, "Fill The Field");
            }
            else
            {
                errorProvider8.Clear();
            }
        }
    }
}
