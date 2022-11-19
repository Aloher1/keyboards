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
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class AddForm : Form
    {
        DBconnect db = new DBconnect();
        class DBconnect
        {
            MySqlConnection conn;
            MySqlConnectionStringBuilder db;

            public DBconnect()
            {
                Initialize();
            }

            public void Add(string name, string category, string price)
            {
                string sql = "INSERT INTO `dbkeyboards`.`table1` ( `id` , `name` , `category` , `price` ) VALUES ( '', @name, @category, @price )";
                if (OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@price", price);

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
            label1.Text = words["Описание"];
            label2.Text = words["Категория"];
            label3.Text = words["Цена"];
            label4.Text = words["Название"];
            comboBox1.Text = words["Выберите категорию"];
            button1.Text = words["Выбрать картинку"];
            button2.Text = words["Добавить"];
            comboBox1.Items[0] = words["Корпуса"];
            comboBox1.Items[1] = words["Плейты"];
            comboBox1.Items[2] = words["Платы"];
            comboBox1.Items[3] = words["Переключатели"];
            comboBox1.Items[4] = words["Кейкапы"];
        }
        string address = "";
        public AddForm()
        {
            InitializeComponent();
            if (Program.language == "eng")
                rename(MainForm.eng);
            else
                rename(MainForm.rus);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                address = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(address);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.Add(textBoxName.Text, comboBox1.Text, textBoxPrice.Text);
            

            MessageBox.Show("Успешно");
        }
    }
}
