using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postman.App.Merchent
{
    public partial class MarchentPrincipal : Form
    {
        public MarchentPrincipal()
        {
            InitializeComponent();
            container(new MarchentDashboardProt());
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

        private void dashboardNavButton_Click(object sender, EventArgs e)
        {
            container(new MarchentDashboardProt());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            container(new ParcelTable());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
