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
using Postman.App.Dashboard;


namespace Postman.App.Authentication.Login
{
    public partial class Login : Form
    {

        UserRepository userRepo = new UserRepository();
        public Login()
        {
            InitializeComponent();
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           
            if(emailTextBox != null && passwordTextBox != null)
            {
                if (userRepo.VerifyUser(emailTextBox.Text, passwordTextBox.Text))
                {
                    this.Hide();
                    MerchentDashboard merchent = new MerchentDashboard();
                    merchent.Show();
                }
            }
           
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register.Register register = new Register.Register();
            register.Show();
        }
    }
}
