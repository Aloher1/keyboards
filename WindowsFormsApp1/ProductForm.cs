using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ProductForm : Form
    {
        objects product;
        Program.DBconnect db = new Program.DBconnect();

        void rename(Dictionary<string, string> words)
        {
            label4.Text = words["Добавлено"];
            button1.Text = words["Добавить в корзину"];
        }
        
        public ProductForm(string tag, string price, List<objects> objList)
        {
            InitializeComponent();
            if (Program.language == "eng")
                rename(db.eng());
            else
                rename(db.rus());

            foreach(objects choosenproduct in objList)
            {
                if(choosenproduct.name == tag)
                {
                    product = choosenproduct;
                }
            }
            label1.Text = product.description;
            pictureBox1.ImageLocation = "../../../Pictures/" + tag + ".jpg";
            label2.Text = product.name;
            if (Program.language == "eng")
                label3.Text = product.price + " rub";
            else
                label3.Text = product.price + " руб.";

            if (Program.login == "admin")    pictureBox2.Visible = true;
        }
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(100, 0);
            pictureBox1.Size = new Size(600, 600);
        }

        private void ProductForm_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Location = new Point(600, 12);
            pictureBox1.Size = new Size(170, 170);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.cart.ContainsKey(product))
                MainForm.cart[product]++;
            else
                MainForm.cart.Add(product, 1);
            
            Program.cartPrice = Program.cartPrice + product.price;
            label4.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            db.Delete(product.name);
            MessageBox.Show("Успешно");
        }
    }
}
