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
        List<Withdraw> withdrawList { get; set; }
        public WithdrawTable()
        {
            InitializeComponent();
            loadGridView();
        }

        public WithdrawTable(List<Withdraw> withdrawList)
        {
            InitializeComponent();
            loadGridView(withdrawList);
            this.withdrawList = withdrawList;
        }
        void loadGridView()
        {
            try
            {
                this.withdrawTableData.DataSource = withdraw.GetAll();
                NumberOfUser.Text =$"{withdrawList.Count}";
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
                NumberOfUser.Text = $"{withdrawList.Count}";
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong in the database" + error, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void userTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
           
            if (withdrawTableData.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.withdrawTableData.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["id"].Value);

                try
                {
                    var withdraw = new WithdrawRepository().GetOne(id);
                    
                    if (withdraw != null)
                    {
                        if (withdraw.status.ToString() == "PENDING")
                        {
                            var account = new AccountRepository().GetOneAccount(withdraw.id);
                            if (account != null)
                            {

                                var res = new AccountRepository().ConfirmWithdrawRequest(account.balance - withdraw.amount, account.withdraw - withdraw.amount, account.userId);
                                if (res > 0)
                                {
                                    var response = new WithdrawRepository().ChangeStatus(id, "SUCCESS");
                                    if (response > 0) MessageBox.Show("Withdraw successfull");
                                    loadGridView();
                                }
                            }
                        }
                        else MessageBox.Show("Already proccessed!");

                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Something went wrong! ", erro.Message);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (withdrawTableData.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.withdrawTableData.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["id"].Value);

                try
                {
                    var withdraw = new WithdrawRepository().GetOne(id);
                    if (withdraw != null)
                    {
                        if (withdraw.status.ToString() == "PENDING")
                        {
                            var account = new AccountRepository().GetOneAccount(withdraw.id);
                            if (account != null)
                            {
                                var res = new AccountRepository().ConfirmWithdrawRequest(account.balance + withdraw.amount, account.withdraw - withdraw.amount, account.userId);
                                if (res > 0)
                                {
                                    var response = new WithdrawRepository().ChangeStatus(id, "FAILED");
                                    if (response > 0) MessageBox.Show("Withdraw FAILED");
                                    loadGridView();
                                }
                            }
                        }
                        else MessageBox.Show("Already proccessed");

                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Something went wrong! ", erro.Message);
                }
            }
        }

        private void NumberOfUser_Click(object sender, EventArgs e)
        {

        }
    }
}
