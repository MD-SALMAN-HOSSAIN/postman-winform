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
namespace Postman.App.Admin
{
    public partial class WithdrawTable : Form
    {

        WithdrawRepository withdraw = new WithdrawRepository();
        public WithdrawTable()
        {
            InitializeComponent();
            loadGridView();
        }

        public WithdrawTable(List<Withdraw> withdrawList)
        {
            InitializeComponent();
            loadGridView(withdrawList);
        }
        void loadGridView()
        {
            try
            {
                this.withdrawTableData.DataSource = withdraw.GetAll();
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong in the database" + error, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void loadGridView(List<Withdraw> withdrawList)
        {
            try
            {
                this.withdrawTableData.DataSource = withdrawList;
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong in the database" + error, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void userTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
