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
using Postman.App.Authentication.Login;
namespace Postman.App.Admin
{
    public partial class AdminPrincipal : Form
    {
        User user { get; set; }

        List<User> userList { get; set; }

        List<Parcel> consignmentList { get; set; }
        List<Withdraw> witdrawList { get; set; }

        UserRepository userRepo = new UserRepository();
        ParcelRepositry parcelRepo = new ParcelRepositry();
        WithdrawRepository withdrawRepository = new WithdrawRepository();
        public AdminPrincipal()
        {
            InitializeComponent();
            if(user == null)
            {
                container(new AdminDashboardProt());
            }
            
        }

        public AdminPrincipal(User user)
        {
            InitializeComponent();
            Console.WriteLine("User" + user.name);
            userList = userRepo.GetAll();
            consignmentList = parcelRepo.getAll();
            witdrawList = withdrawRepository.GetAll();
            container(new AdminDashboardProt(user, userList.Count, consignmentList.Count ));
            this.user = user;
            
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
            if (user != null) container(new AdminDashboardProt(user, userList.Count, consignmentList.Count));
            else container(new AdminDashboardProt()); 
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            top_dash.Text = "USER LIST";
            container(new UserTable());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            top_dash.Text = "CONSIGNMENTS";
            container(new ConsignmentTable(consignmentList));
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            top_dash.Text = "WITHDRAW REQUESTS";
            container(new WithdrawTable(witdrawList));
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            top_dash.Text = "SETTINGS";
            container(new UniformUpdate(user));
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
        }
    }
}
