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
    public partial class MarchentDashboardProt : Form
    {
        User user { get; set; }
        public MarchentDashboardProt()
        {
            InitializeComponent();
        }

        public MarchentDashboardProt(User user)
        {
            InitializeComponent();
            this.user = user;
            if (user != null)
            {
                userName.Text = user.name;
                addressLabel.Text = user.pickupLocation;
                phoneLabel.Text = user.phone;
            }
           
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
