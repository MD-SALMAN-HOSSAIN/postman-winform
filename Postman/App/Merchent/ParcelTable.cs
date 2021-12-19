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
    public partial class ParcelTable : Form
    {
        ParcelRepositry parcelRepo = new ParcelRepositry();

        User user { get; set; }

        List<Parcel> parcelList { get; set; }
        public ParcelTable()
        {
            InitializeComponent();
        }

        public ParcelTable(User user)
        {

            this.user = user;
            InitializeComponent();
            loadGridView();
            parcelCount.Text = $"{parcelList.Count}";
        }
        void loadGridView()
        {
            try
            {
                parcelList = parcelRepo.getAllUser(this.user.id);
                this.consignmentTableData.DataSource = parcelList;
            }
            catch (Exception err)
            {
                MessageBox.Show("Failed to fetch data, " + err.Message, "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            CallbackDelegate callbackDelegate = new CallbackDelegate(loadGridView);
            AddParcel parcelForm = new AddParcel(user, callbackDelegate);
            parcelForm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            CallbackDelegate callbackDelegate = new CallbackDelegate(loadGridView);
            
            if(consignmentTableData.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.consignmentTableData.SelectedRows[0];
                int parcelId = Convert.ToInt32(row.Cells["id"].Value);

                try
                {
                    var parcel = parcelRepo.getOneParcel(parcelId);
                    if(parcel != null)
                    {
                        UpdateParcel parcelForm = new UpdateParcel(parcel, callbackDelegate);
                        parcelForm.Show();
                    }

                }
                catch(Exception erro)
                {
                    MessageBox.Show("Something went wrong! ", erro.Message);
                }
            }
          
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

           var ans= MessageBox.Show("Are you sure you wanted to delete parcel?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ans == DialogResult.No)
            {
                return;
            }    
            if (consignmentTableData.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.consignmentTableData.SelectedRows[0];
                int parcelId = Convert.ToInt32(row.Cells["id"].Value);

                try
                {
                    var result = parcelRepo.deleteOne(parcelId);
                    if(result> 0)
                    {
                        loadGridView();
                        MessageBox.Show("Parcel Deleted successfully", "DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Something went wrong! ", erro.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (consignmentTableData.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.consignmentTableData.SelectedRows[0];
                int parcelId = Convert.ToInt32(row.Cells["id"].Value);

                ViewParcelDetails viewParcelDetails = new ViewParcelDetails(parcelId);
                viewParcelDetails.Show();
            }
        }
    }
}
