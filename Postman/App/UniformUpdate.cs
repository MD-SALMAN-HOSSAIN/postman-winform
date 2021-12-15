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
namespace Postman.App
{
    public partial class UniformUpdate : Form
    {
        User user { get; set; }
        public UniformUpdate()
        {
            InitializeComponent();
        }

        public UniformUpdate(User user)
        {
            this.user = user;
            nameBox.Text = user.name;
            emailBox.Text = user.email;
            addressBox.Text = user.pickupLocation;
            phoneBox.Text = user.phone;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(passBox.Text) && String.IsNullOrEmpty(confirmPassBox.Text)
            {

            }
        }
    }
}
