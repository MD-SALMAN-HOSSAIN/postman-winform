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

        ParcelRepositry parcelRepo = new ParcelRepositry();
        public Consignments()
        {
            InitializeComponent();
        }

        public Consignments(User user)
        {
            this.user = user;
            InitializeComponent();
            loadGridView(user);
        }
        void loadGridView(User user)
        {
            try
            {
                this.consignmentTableData.DataSource = parcelRepo.getRiderConsignments(user.id);
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
    }
}
