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
        Program.DBconnect db = new Program.DBconnect();
        
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
                rename(db.eng());
            else
                rename(db.rus());
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
            if (textBoxName.Text != "" && comboBox1.Text != "" && textBoxPrice.Text != "" && textBox1.Text != "")
            {
                db.AddObj(textBoxName.Text, comboBox1.Text, textBoxPrice.Text, textBox1.Text);
                MessageBox.Show("Успешно");
                Close();
                db.objList();
            }
            else    MessageBox.Show("Заполните все поля!");
        }
    }
}
