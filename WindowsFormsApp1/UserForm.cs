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
    public partial class UserForm : Form
    {
        public static string login = "";
        List<string> logInfo = new List<string>();
        bool registration = false;
        
        void ReadLogInfo()
        {
            string[] lines = File.ReadAllLines("../../../loginInfo.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { "," }, StringSplitOptions.None);
                logInfo.Add(parts[0]);  logInfo.Add(parts[1]);
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
            ReadLogInfo();
            if (Program.language == "eng")
                rename(MainForm.eng);
            else
                rename(MainForm.rus);

            if (login != "")
            {
                MessageBox.Show("Вы уже вошли");
                Close();
            }
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
               for (int i = 0; i < logInfo.Count; i = i + 2)
                {
                    if (textBox1.Text != "" & textBox2.Text != "")
                    {
                        if (textBox1.Text == logInfo[i])
                            MessageBox.Show("Вы уже зарегистрированы");
                    }
                }
                if (login == "")
                {
                    login = textBox1.Text;
                    File.AppendAllText("../../../loginInfo.txt", Environment.NewLine + textBox1.Text + "," + textBox2.Text);
                    MessageBox.Show("Вы зарегистрировались");
                }
            }
            if (registration == false)
            {
                for (int i = 0; i < logInfo.Count; i = i + 2)
                {
                    if (textBox1.Text != ""         && textBox2.Text != "" && 
                        textBox1.Text == logInfo[i] && textBox2.Text == logInfo[i + 1])
                    {   login = textBox1.Text;  }
                }
                if (login == "")            MessageBox.Show("Вы не зарегистрированы");
                else if (login == "admin")  MessageBox.Show("Вы вошли в аккаунт админа");
                else                        MessageBox.Show("Вы вошли в аккаунт");
                Close();
            }
        }
    }
}