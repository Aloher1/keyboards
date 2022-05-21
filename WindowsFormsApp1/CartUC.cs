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
        Label l;
        public CartUC(objects obj, int value, Label label)
        {
            obj1 = obj;
            n = value;
            l = label;
            //label1.Text = n.ToString();
            InitializeComponent();
            ProductPB.Image = obj1.picture.Image;
            label2.Text = obj1.name;
        }


        public void plusPB_Click(object sender, EventArgs e)
        {
            n++;
            Program.cartPrice += obj1.price;
            label1.Text = n.ToString();
            l.Text = "К оплате: " + Program.cartPrice + " руб.";
        }

        public void minusPB_Click(object sender, EventArgs e)
        {
            if (n != 0)
            {
                n--;
                Program.cartPrice -= obj1.price;
                label1.Text = n.ToString();
                l.Text = "К оплате: " + Program.cartPrice + " руб.";
            }
            if(n == 0)
            {
                MainForm.cart.Remove(obj1);
                this.Parent = null;
            }
        }
    }
}
