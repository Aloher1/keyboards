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

namespace WindowsFormsApp1
{
    public partial class UserForm : Form
    {
        bool registration = false;
        DBconnect db = new DBconnect();

        /*void ReadLogInfo()
        {
            string[] lines = File.ReadAllLines("../../../loginInfo.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { "," }, StringSplitOptions.None);
                logInfo.Add(parts[0]);  logInfo.Add(parts[1]);
            }
        }*/
        class DBconnect
        {
            MySqlConnection conn;
            MySqlConnectionStringBuilder db;

            public DBconnect()
            {
                Initialize();
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
            public void Add(string login, string password)
            {
                string sql = "INSERT INTO `dbkeyboards`.`loginpassword` ( `id` , `login` , `password` ) VALUES ( '', @login, @password )";
                if (OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);

                        cmd.ExecuteNonQuery();
                    }
                    CloseConnection();
                }
            }
            public List<string> logInfo()
            {
                string sql = "SELECT * FROM loginpassword";
                List<string> list = new List<string>();

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string login;
                        string password;
                        login = reader.GetString(1);
                        password = reader.GetString(2);
                        list.Add(login); list.Add(password);
                    }
                    CloseConnection();
                }
                return list;
            }
        }
        void rename(Dictionary<string, string> words)
        {
            linkLabel1.Text = words["Регистрация"];
            label1.Text = words["Логин"];
            label2.Text = words["Вход"];
            label3.Text = words["Пароль"];
            button1.Text = words["Войти"];
        }

        public UserForm()
        {
            InitializeComponent();
            if (Program.language == "eng")
                rename(MainForm.eng);
            else
                rename(MainForm.rus);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
                pictureBox1.Image = Image.FromFile("../../../Pictures/hide.png");
            }

            else if (textBox2.UseSystemPasswordChar == false)
            {
                textBox2.UseSystemPasswordChar = true;
                pictureBox1.Image = Image.FromFile("../../../Pictures/show.png");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (registration == false)
            {
                registration = true;
                linkLabel1.Location = new Point(340, 9);
                if (Program.language == "eng")
                {
                    linkLabel1.Text = "Login";
                    label2.Text = "Registration";
                    button1.Text = "Register";
                }
                else
                {
                    linkLabel1.Text = "Вход";
                    label2.Text = "Регистрация";
                    button1.Text = "Зарегистрироваться";
                }
            }
            else if (registration == true)
            {
                registration = false;
                linkLabel1.Location = new Point(270, 9);
                if (Program.language == "eng")
                {
                    linkLabel1.Text = "Registration";
                    label2.Text = "Login";
                    button1.Text = "Login";
                }
                else
                {
                    linkLabel1.Text = "Регистрация";
                    label2.Text = "Вход";
                    button1.Text = "Войти";
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (registration == true)
            {
                for (int i = 0; i < db.logInfo().Count; i = i + 2)
                {
                    if (textBox1.Text != "" & textBox2.Text != "")
                    {
                        if (textBox1.Text == db.logInfo()[i])
                            MessageBox.Show("Вы уже зарегистрированы");
                    }
                }
                if (Program.login == "" && textBox1.Text != "" && textBox2.Text != "")
                {
                    Program.login = textBox1.Text;
                    db.Add(textBox1.Text, textBox2.Text);
                    MessageBox.Show("Вы зарегистрировались");
                }
            }
            if (registration == false)
            {
               for (int i = 0; i < db.logInfo().Count; i = i + 2)
               {
                    if (textBox1.Text != ""         && textBox2.Text != "" && 
                        textBox1.Text == db.logInfo()[i] && textBox2.Text == db.logInfo()[i + 1])
                    {   Program.login = textBox1.Text;   }
               }
                if (Program.login == "")            MessageBox.Show("Вы не зарегистрированы");
                else if (Program.login == "admin")  MessageBox.Show("Вы вошли в аккаунт админа");
                else                        MessageBox.Show("Вы вошли в аккаунт");
                Close();
            }
        }
    }
}