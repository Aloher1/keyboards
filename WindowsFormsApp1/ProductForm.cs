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
        DBconnect db = new DBconnect();
        class DBconnect
        {
            MySqlConnection conn;
            MySqlConnectionStringBuilder db;

            public DBconnect()
            {
                Initialize();
            }
            public void Delete(string name)
            {
                string sql = "DELETE FROM `dbkeyboards`.`table1` WHERE `table1`.`name` = @name";
                if (OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                    CloseConnection();
                }

            }
            private void Initialize()
            {
                db = new MySqlConnectionStringBuilder();
                db.Server = "sql7.freesqldatabase.com";        // хостинг БД
                db.Database = "sql7575921";                    // имя БД
                db.UserID = "sql7575921";                      // имя пользователя
                db.Password = "crhQxPWpVp";                    // пароль
                db.CharacterSet = "utf8";                      // кодировка БД
                conn = new MySqlConnection(db.ConnectionString);
            }
            private bool OpenConnection()
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            private void CloseConnection()
            {
                try
                {
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        void rename(Dictionary<string, string> words)
        {
            label4.Text = words["Добавлено"];
            button1.Text = words["Добавить в корзину"];
        }
        
        public ProductForm(string tag, string price, List<objects> objList)
        {
            InitializeComponent();
            if (Program.language == "eng")
                rename(MainForm.eng);
            else
                rename(MainForm.rus);

            foreach(objects choosenproduct in objList)
            {
                if(choosenproduct.name == tag)
                {
                    product = choosenproduct;
                }
            }
            //label1.Text = File.ReadAllText("../../../Files/" + tag + ".txt");
            pictureBox1.Image = product.picture.Image;
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
            //if(MouseButtons.Left(Point ))
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
