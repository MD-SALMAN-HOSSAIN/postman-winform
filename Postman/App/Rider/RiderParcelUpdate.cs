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
    public partial class RiderParcelUpdate : Form
    {
        string Status { get; set; }
        CallbackDelegate loadGrid { get; set; }
        ParcelRepositry parcelRepo = new ParcelRepositry(); 

        Parcel parcel { get; set; }
        public RiderParcelUpdate()
        {
            InitializeComponent();
        }

        public RiderParcelUpdate(int parcelId, CallbackDelegate callback)
        {
            InitializeComponent();
            this.parcel = parcelRepo.getOneParcel(parcelId);
            if (parcel != null)
            {
                invoiceText.Text = parcel.invoiceNo;
                methodText.Text = parcel.method;
                statusUpdate.Text = parcel.status;
                amountText.Text = parcel.amountToCollect.ToString();
                Status = parcel.status;
                loadGrid = callback;
            }    
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(Status == statusUpdate.Text)
            {
                MessageBox.Show("Please change the status of parcel!", "Warning");
                return;
            }
            var result = MessageBox.Show($"Do you want to change  this parcel status {Status} to {statusUpdate.Text}?", "Confirmission", MessageBoxButtons.YesNo);
            
            if(result == DialogResult.Yes)
            {
                try
                {
                   var rs= parcelRepo.updateParcelStatus(parcel.id, statusUpdate.Text);
                    if (rs > 0)
                    {
                        MessageBox.Show("Successfully updated");
                        loadGrid();
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show("Error Occured while updating");
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
