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
using Postman.Models;
namespace Postman.App.Merchent
{
    public partial class CustomerTableForm : Form
    {
        CustomerRepostiroy customer = new CustomerRepostiroy();
        public CustomerTableForm()
        {
            InitializeComponent();
           
        }

        public CustomerTableForm(User user)
        {
            InitializeComponent();
            this.guna2DataGridView1.DataSource = customer.getAllCustomer(user);
        }
        
    }
}
