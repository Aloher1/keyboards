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
        string address = "";
        public AddForm()
        {
            InitializeComponent();
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
