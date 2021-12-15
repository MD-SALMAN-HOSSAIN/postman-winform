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
    public partial class MarchentPrincipal : Form
    {
        User user { get; set; }
        public MarchentPrincipal()
        {
            InitializeComponent();
            container(new MarchentDashboardProt());
        }

        public MarchentPrincipal(User user)
        {
            InitializeComponent();
            this.user = user;
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
            container(new ParcelTable(user));
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if(user != null) container(new UniformUpdate(user));
            else container(new UniformUpdate(user));
        }
    }
}
