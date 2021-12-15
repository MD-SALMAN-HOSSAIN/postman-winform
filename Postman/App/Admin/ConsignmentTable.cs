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
namespace Postman.App.Admin
{
    public partial class ConsignmentTable : Form
    {
        ParcelRepositry parcelRepo = new ParcelRepositry();
        public ConsignmentTable()
        {
            InitializeComponent();
            loadGridView();
        }

        public ConsignmentTable(List<Parcel> parcelList)
        {
            InitializeComponent();
            loadGridView(parcelList);
        }

        private void userTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void loadGridView()
        {
            try
            {
                this.consignmentTableData.DataSource = parcelRepo.getAll();
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong in the database" + error, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void loadGridView(List<Parcel> parcelList)
        {
            try
            {
                this.consignmentTableData.DataSource =parcelList;
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong in the database" + error, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
