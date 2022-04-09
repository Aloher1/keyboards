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
    }
    public partial class MainForm : Form
    {  
        public List<objects> objList = new List<objects>();
        public class ReadAllObjects
        {
            string[] ReadObj = File.ReadAllLines("Objects.txt");
        }
        public MainForm()
        {
            InitializeComponent();
            int x = 30;
            int y = 10;
            for(int i = 0; i < objList.Count; i++)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
