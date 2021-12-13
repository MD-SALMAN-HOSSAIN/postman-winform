﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Postman.Repository;
using Postman.Models;
namespace Postman.App.Authentication.Register
{
    public partial class Register : Form
    {
        UserRepository userRepo = new UserRepository();
        public Register()
        {
            InitializeComponent();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            if (CheckNull(fullnameText) && CheckNull(passwordText) && CheckNull(phoneText) && CheckNull(emailText) && CheckNull(confirmPasswordText))
            {

                if (!String.Equals(confirmPasswordText.Text,  passwordText.Text))
                {
                    return;
                }
                Console.WriteLine("Hello world", riderRadio.Checked , marchentRadio.Checked);
                if (riderRadio.Checked || marchentRadio.Checked)
                {
                    User user = new User()
                    {
                        email = emailText.Text,
                        password = passwordText.Text,
                        phone = phoneText.Text,
                        name = fullnameText.Text,
                        userRole = riderRadio.Checked ? "rider" : marchentRadio.Checked ? "marchent" : ""
                    };
                    try
                    {
                        Console.WriteLine("Creating data");
                            userRepo.RegisterUser(user);
                    } catch(Exception err)
                    {
                        Console.WriteLine("Error: " + err.Message);
                    }
                }
            }
        }


        private bool CheckNull(Guna2TextBox box)
        {
            return !String.IsNullOrEmpty(box.Text);
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
