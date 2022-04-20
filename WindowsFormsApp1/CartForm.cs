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
            int x = 10;
            int y = 10;
            for(int i = 0; i < MainForm.cart.Count;i++)
            {
                MainForm.cart[i].picture.Location = new Point(x, y);
                MainForm.cart[i].picture.Size = new Size(120, 120);
                MainForm.cart[i].picture.SizeMode = PictureBoxSizeMode.StretchImage;
                panel1.Controls.Add(MainForm.cart[i].picture);

                MainForm.cart[i].label .Location = new Point(x + 150, y);
                MainForm.cart[i].label.Size = new Size(120, 75);
                MainForm.cart[i].label.Text = MainForm.cart[i].name;
                panel1.Controls.Add(MainForm.cart[i].label);

                x = 10;
                y = y + 150;
            }
            label1.Text = label1.Text + Program.cartPrice + "руб.";
        }
    }
}
