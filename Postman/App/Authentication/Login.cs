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
using Postman.App.Admin;
using Postman.App.Merchent;
using Postman.App.Rider;

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
                    var user = userRepo.GetUserInfo(emailTextBox.Text, passwordTextBox.Text);
                    Console.WriteLine(user.userRole);
                    if(user.userRole == "marchent")
                    {
                        this.Hide();
                        MerchentDashboard merchent = new MerchentDashboard();
                        merchent.Show();
                    }
                    else if(user.userRole == "admin")
                    {
                        this.Hide();
                        AdminPrincipal admin = new AdminPrincipal();
                        admin.Show();
                    }
                    else if(user.userRole == "rider")
                    {
                        this.Hide();
                        RiderDashboard rider = new RiderDashboard();
                        rider.Show();
                    }
                   
                }
                else
                {
                    MessageBox.Show("Check your email and password", "Login failed!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailTextBox.Text))
            {
                emailTextBox.Focus();
                errorProvider1.SetError(this.emailTextBox, "Fill The Field");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                passwordTextBox.Focus();
                errorProvider2.SetError(this.passwordTextBox, "Fill The Field");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
