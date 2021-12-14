using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postman.App.Rider
{
    public partial class RiderPrincipal : Form
    {
        public RiderPrincipal()
        {
            InitializeComponent();
            container(new RiderDashboardProt());
        }

        private void dashboardNavButton_Click(object sender, EventArgs e)
        {
            container(new RiderDashboardProt());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            container(new Consignments());

        }

        private void container(object _form)
        {
            if (panel_container.Controls.Count > 0) panel_container.Controls.Clear();

            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            panel_container.Controls.Add(fm);
            panel_container.Tag = fm;
            fm.Show();
        }
    }
}
