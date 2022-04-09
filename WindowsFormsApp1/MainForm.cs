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

        public objects(string name1, int price1, string category1)
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
            string[] line = File.ReadAllLines("Objects.txt");
            
        }
        public MainForm()
        {
            InitializeComponent();
            //ReadAllObjects();
            
            int x = 30;
            int y = 10;
            for(int i = 0; i < objList.Count; i++)
            {
                objList[i].label.Location = new Point(x, y + 120);
                objList[i].label.Size = new Size(120, 75);
                objList[i].label.Text = objList[i].name;

                objList[i].picture.Location = new Point(x, y);
                objList[i].picture.Size = new Size(120, 120);
                objList[i].picture.SizeMode = PictureBoxSizeMode.StretchImage;

                x = x + 160;
                if(x + 130 <= Width)
                {
                    x = 30;
                    y = y + 200;
                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
