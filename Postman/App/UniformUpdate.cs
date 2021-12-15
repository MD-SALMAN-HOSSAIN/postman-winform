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
namespace Postman.App
{
    public partial class UniformUpdate : Form
    {
        User user { get; set; }

        UserRepository userRepo = new UserRepository();

        public UniformUpdate()
        {
            InitializeComponent();
        }

        public UniformUpdate(User user)
        {
            this.user = user;
            Console.WriteLine("Updating user "+ user.name);
            if (user != null)
            {
                nameBox.Text = user.name;
                emailBox.Text = user.email;
                addressBox.Text = user.pickupLocation;
                phoneBox.Text = user.phone;
            }
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(passBox.Text != null && confirmPassBox.Text != null)
            {
                string hashed = BCrypt.Net.BCrypt.HashPassword(passBox.Text);
                userRepo.UpdateUser(new User { email = emailBox.Text, name = nameBox.Text,password=hashed, pickupLocation = addressBox.Text, phone = phoneBox.Text }, user.id);
                return;
            }
            userRepo.UpdateUser(new User { email= emailBox.Text, name= nameBox.Text,  pickupLocation = addressBox.Text, phone = phoneBox.Text }, user.id);
        }
    }
}
