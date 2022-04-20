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
            label2.Text = product.name;
            label3.Text = product.price + " руб.";
            pictureBox1.Image = product.picture.Image;
            
        }
    }
}
