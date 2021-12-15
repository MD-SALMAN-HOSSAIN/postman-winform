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
namespace Postman.App.Rider
{
    public partial class RiderDashboardProt : Form
    {
        public RiderDashboardProt()
        {
            InitializeComponent();
        }

        public RiderDashboardProt(User user )
        {
            
            if(user != null)
            {
                
            }
            InitializeComponent();

        }
    }
}
