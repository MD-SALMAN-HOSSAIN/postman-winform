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
    public partial class Consignments : Form
    {
        User user { get; set; }
        List<Parcel> listOfparcel {get; set;}
        ParcelRepositry parcelRepo = new ParcelRepositry();
        public Consignments()
        {
            InitializeComponent();
        }

        public Consignments(User user)
        {
            this.user = user;
            InitializeComponent();
            loadGridView();
        }
        void loadGridView()
        {
            try
            {
                listOfparcel = parcelRepo.getRiderConsignments(user.id);
                this.consignmentTableData.DataSource = listOfparcel;
                NumberOfUser.Text = $"{listOfparcel.Count}";
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong in the database" + error, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (consignmentTableData.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.consignmentTableData.SelectedRows[0];
                int parcelId = Convert.ToInt32(row.Cells["id"].Value);

                ViewParcelDetails viewParcelDetails = new ViewParcelDetails(parcelId);
                viewParcelDetails.Show();
            }
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            
            if (consignmentTableData.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.consignmentTableData.SelectedRows[0];
                int parcelId = Convert.ToInt32(row.Cells["id"].Value);
                CallbackDelegate callbackDelegate = new CallbackDelegate(loadGridView);

                RiderParcelUpdate update = new RiderParcelUpdate(parcelId, callbackDelegate);
                update.Show();
            }
        }
    }
}
