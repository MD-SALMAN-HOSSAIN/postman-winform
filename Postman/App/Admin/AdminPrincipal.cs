using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postman.App.Admin
{
    public partial class AdminPrincipal : Form
    {
        public AdminPrincipal()
        {
            InitializeComponent();
            container(new AdminDashboardProt());
        }

        private void AdminDashboardProto_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
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
            top_dash.Text = "DASHBOARD";
            container(new AdminDashboardProt());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            top_dash.Text = "USER LIST";
            container(new UserTable());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            top_dash.Text = "CONSIGNMENTS";
            container(new ConsignmentTable());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            top_dash.Text = "WITHDRAW REQUESTS";
            container(new WithdrawTable());
        }
    }
}
