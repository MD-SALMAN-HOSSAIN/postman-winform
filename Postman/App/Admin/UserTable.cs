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
namespace Postman.App.Admin
{
    public partial class UserTable : Form
    {
        UserRepository userRepo = new UserRepository();

        
        public UserTable()
        {

            InitializeComponent();
            loadGridView();
        }

        void loadGridView()
        {
            try
            {
                var user = userRepo.GetAll();
                this.userTableData.DataSource = user;
                NumberOfUser.Text = user.Count.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong in the database"+ error, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void userTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}