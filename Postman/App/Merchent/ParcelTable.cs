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
namespace Postman.App.Merchent
{
    public partial class ParcelTable : Form
    {
        User user { get; set; }
        public ParcelTable()
        {
            InitializeComponent();
        }

        public ParcelTable(User user)
        {

            this.user = user;
            InitializeComponent();
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            AddParcel parcelForm = new AddParcel(user);
            parcelForm.Show();
        }
    }
}
