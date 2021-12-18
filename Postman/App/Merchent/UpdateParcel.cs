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
    public partial class UpdateParcel : Form
    {

        Parcel parcel { get; set; }

        CallbackDelegate Loadgridviewcallback { get; set; }
        public UpdateParcel()
        {
            InitializeComponent();
        }

        public UpdateParcel(Parcel parcel, CallbackDelegate callback )
        {
            InitializeComponent();
            this.Loadgridviewcallback = callback;
            if(parcel != null)
            {
                this.parcel = parcel;
                inovicetext.Text = parcel.invoiceNo;
                amountToCollect.Text = parcel.amountToCollect.ToString();
                methodType.Text = parcel.paymetMethod.ToString();
                weight.Text = parcel.packageWeight.ToString();
                customerName.Text = parcel.customer.name.ToString();
                customerPhone.Text = parcel.customer.phone.ToString();
                customerArea.Text = parcel.customer.area.ToString();
                customerCity.Text = parcel.customer.phone.ToString();
                customerAddress.Text = parcel.customer.address.ToString();
            }
        }
    }
}
