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
                MessageBox.Show("Something went wrong in the database" + error, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void userTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (userTableData.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.userTableData.SelectedRows[0];
                int userId = Convert.ToInt32(row.Cells["id"].Value);

                if (userId > 0)
                {
                    var res = MessageBox.Show("Are you sure want to Ban the user?", "Confirmission", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                       try
                        {
                            var result = new UserRepository().BanUser(Models.UserRole.BANNED, userId);
                            if (result > 0) MessageBox.Show("successfully banned user");
                            else MessageBox.Show("Failed to ban user");
                        }
                        catch(Exception er)
                        {
                            MessageBox.Show("Error occured while query" + er.Message);
                        }
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (userTableData.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.userTableData.SelectedRows[0];
                int userId = Convert.ToInt32(row.Cells["id"].Value);

                if (userId > 0)
                {
                    var res = MessageBox.Show("Are you sure want to delete the user?", "Confirmission", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                       try
                        {
                            var result = new UserRepository().RemoveUser(userId);
                            if (result > 0) MessageBox.Show("successfully deleted user");
                            else MessageBox.Show("Failed to delete the user");
                        }
                        catch(Exception err)
                        {
                            MessageBox.Show("Error occured while query" + err.Message);
                        }
                    }
                }
            }
        }
    }
}