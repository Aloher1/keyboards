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
    public struct objects
    {
        public PictureBox picture;
        public string name;
        public Label label;
        public int price;
        public string category;

        public objects(string name1, string category1, int price1)
        {
            picture = new PictureBox();
            name = name1;
            label = new Label();
            price = price1;
            category = category1;
        }
    }
    public partial class MainForm : Form
    {  
        public static List<objects> objList = new List<objects>();
        void ReadAllObjects()
        {
            objList.Clear();
            string[] lines = File.ReadAllLines("../../../Objects.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { "," }, StringSplitOptions.None);
                objList.Add(new objects(parts[0], parts[1], Convert.ToInt32(parts[2])));
            }
         }
        public MainForm()
        {
            InitializeComponent();
            ReadAllObjects();
            
            
            int x = 30;
            int y = 10;
            
            for(int i = 0; i < objList.Count; i++)
            {
                objList[i].picture.Location = new Point(x, y);
                objList[i].picture.Size = new Size(120, 120);
                objList[i].picture.SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    objList[i].picture.Image = Image.FromFile("../../../Pictures/" + objList[i].name + ".jpg");
                }
                catch (Exception) { }
                panel2.Controls.Add(objList[i].picture);
                
                objList[i].label.Location = new Point(x, y + 120);
                objList[i].label.Size = new Size(120, 75);
                objList[i].label.Text = objList[i].name;
                //objList [i].label.TextAlign = ContentAlignment.MiddleCenter;
                panel2.Controls.Add(objList[i].label);
                
                x = x + 160;
                if(x + 130 >= Width - 250)
                {
                    x = 30;
                    y = y + 200;
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            int x = 30;
            int y = 10;

            for (int i = 0; i < objList.Count; i++)
            {
                objList[i].picture.Visible = true;
                if (textBox1.Text != "" && 
                    !objList[i].name.Contains(textBox1.Text))
                    objList[i].picture.Visible = false;
                if (objList[i].picture.Visible)
                {
                    objList[i].picture.Location = new Point(x, y);
                    objList[i].label.Location = new Point(x, y + 120);
                    x = x + 160;
                    if (x + 130 >= Width - 250)
                    {
                        x = 30;
                        y = y + 200;
                    }
                }
                objList[i].label.Visible = objList[i].picture.Visible;
            }

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            int x = 30;
            int y = 10;
            for (int i = 0; i < objList.Count; i++)
            {
                objList[i].picture.Visible = true;
                foreach (string category in checkedListBox1.CheckedItems)
                {
                    if (!objList[i].category.Contains(category) && checkedListBox1.CheckedItems.Count > 0)
                    {
                        objList[i].picture.Visible = false;
                        //MessageBox.Show(category);
                    }
                }
                if (objList[i].picture.Visible)
                {
                    objList[i].picture.Location = new Point(x, y);
                    objList[i].label.Location = new Point(x, y + 120);
                    x = x + 160;
                    if (x + 130 >= Width - 250)
                    {
                        x = 30;
                        y = y + 200;
                    }
                }
                objList[i].label.Visible = objList[i].picture.Visible;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }
}
