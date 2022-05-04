using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CartUC : UserControl
    {
        int n;
        objects obj1;
        public CartUC(objects obj, int value)
        {
            obj1 = obj;
            n = value;
       //     label1.Text = n.ToString();
            InitializeComponent();
            ProductPB.Image = obj1.picture.Image;
            label2.Text = obj1.name;
        }

        private void plusPB_Click(object sender, EventArgs e)
        {
            n++;
            Program.cartPrice += obj1.price;
            label1.Text = n.ToString();
        }

        private void minusPB_Click(object sender, EventArgs e)
        {
            Program.cartPrice -= obj1.price;
            n--;
            label1.Text = n.ToString();
        }
    }
}
