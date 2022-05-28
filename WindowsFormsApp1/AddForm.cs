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
    public partial class AddForm : Form
    {
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
            File.AppendAllText("../../../Objects.txt", Environment.NewLine +
                textBoxName.Text + "," + comboBox1.Text + "," + textBoxPrice.Text);
            FileStream file = File.Create("../../../Files/" + textBoxName.Text + ".txt");
            file.Close();
            File.WriteAllText("../../../Files/" + textBoxName.Text + ".txt", textBox1.Text);
            if (address != "")
                File.Copy(address, "../../../Pictures/" + textBoxName.Text + ".jpg");
            MessageBox.Show("Успешно");
        }
    }
}
