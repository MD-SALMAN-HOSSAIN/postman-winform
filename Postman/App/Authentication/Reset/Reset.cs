using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postman.App.Authentication.Reset
{
    public partial class Reset : Form
    {
        public Reset()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox2.Text))
            {
                guna2TextBox2.Focus();
                errorProvider1.SetError(this.guna2TextBox2, "Fill The Field");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
