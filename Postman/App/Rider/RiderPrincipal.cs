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
using Postman.App.Authentication.Login;
namespace Postman.App.Rider
{
    public partial class RiderPrincipal : Form
    {
        User user { get; set; }
        public RiderPrincipal()
        {
            InitializeComponent();
        }
        public RiderPrincipal(User user)
        {
            InitializeComponent();
            this.user = user;
            container(new RiderDashboardProt(user));
            riderEmail.Text = this.user.email;
            riderName.Text = this.user.name;
        }

        private void dashboardNavButton_Click(object sender, EventArgs e)
        {
            container(new RiderDashboardProt(user));
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            container(new Consignments(user));

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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if(user != null) container(new UniformUpdate(user));
            else container(new Consignments());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Info info = new Info();
                info.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            container(new UniformUpdate(user));
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            container(new RiderParcel(user));
        }
    }
}
