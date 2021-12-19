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
namespace Postman.App.Merchent
{
    public partial class WithdrawTableMr : Form
    {
        User user { get; set; }

        List<Withdraw> withdrawList { get; set; }

        WithdrawRepository withdrawRepo = new WithdrawRepository();
        public WithdrawTableMr()
        {
            InitializeComponent();
        }
        public WithdrawTableMr(User user)
        {
            InitializeComponent();

            this.user = user;
            loadGridView();

        }

        void loadGridView()
        {
            void loadGridView()
            {
                try
                {
                    withdrawList = withdrawRepo.GetAllByUser(user.id);
                    NumberOfUser.Text = $"{withdrawList.Count}";
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong, " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            UniformWIthdraw withdraw = new UniformWIthdraw(user);
            withdraw.Show();
        }
    }
}
