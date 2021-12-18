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
    }
}
