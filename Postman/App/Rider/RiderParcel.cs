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
    public partial class RiderParcel : Form
    {
        ParcelRepositry parcelRepo = new ParcelRepositry();
        User user { get; set; }

        List <Parcel> listOfParcels { get; set; }
        public RiderParcel()
        {
            InitializeComponent();
        }

        public RiderParcel(User user)
        {
            InitializeComponent();
            this.user = user;
            loadGridView();
        }

        void loadGridView()
        {
            try
            {
                listOfParcels = parcelRepo.getAll().FindAll(e=> e.status == "PENDING");
                numberOfParcels.Text = $"{listOfParcels.Count}";
                consignmentTableData.DataSource = listOfParcels;
            }
            catch(Exception e)
            {
                MessageBox.Show("Something went wrong, " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            if(consignmentTableData.SelectedRows.Count >0)
            {
                DataGridViewRow row = this.consignmentTableData.SelectedRows[0];
                int parcelId = Convert.ToInt32(row.Cells["id"].Value);
                var response = MessageBox.Show("Are you ready to delivery the parcel?", "CONFIRMISSION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (response == DialogResult.OK)
                {
                    try
                    {
                        var result = this.parcelRepo.AssignParcelToRider(parcelId, user.id);
                        if (result > 0)
                        {
                            MessageBox.Show("Successfully assigned the parcel", "SUCCESSS");
                            loadGridView();
                        }
                        else MessageBox.Show("Failed to assign the parcel", "FAILED");
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show("Failed to assign parcel, ERROR: "+ err.Message, "DB ERROR");
                    }
                }
                else return;
            }
        }
    }
}
