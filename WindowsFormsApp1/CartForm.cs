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
    public partial class CartForm : Form
    {
        public CartForm()
        {
            InitializeComponent();
            label1.Text = label1.Text + Program.cartPrice + "руб.";
            int y = 10;
            foreach (KeyValuePair<objects, int> pair in MainForm.cart)
            {
                CartUC obj = new CartUC(pair.Key, pair.Value, this.label1);
                obj.Location = new Point(10, y);
                panel1.Controls.Add(obj);

                y += 150;
            }
        }
        
    }
}
