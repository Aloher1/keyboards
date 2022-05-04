using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class ProductForm : Form
    {
        objects product;
        public ProductForm(string tag, string price)
        {
            InitializeComponent();
            foreach(objects choosenproduct in MainForm.objList)
            {
                if(choosenproduct.name == tag)
                {
                    product = choosenproduct;
                }
            }
            //label1.Text = File.ReadAllText("../../../Files/" + tag + ".txt");
            pictureBox1.Image = product.picture.Image;
            label2.Text = product.name;
            if (product.category == "Переключатели")
                label3.Text = product.price + " руб/шт";
            else
                label3.Text = product.price + " руб.";
        }
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(100, 0);
            pictureBox1.Size = new Size(600, 600);
            //if(MouseButtons.Left(Point ))
        }

        private void ProductForm_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Location = new Point(600, 12);
            pictureBox1.Size = new Size(170, 170);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.cart.Add(product, 1);
            Program.cartPrice = Program.cartPrice + product.price;
            label4.Visible = true;
        }
    }
}
