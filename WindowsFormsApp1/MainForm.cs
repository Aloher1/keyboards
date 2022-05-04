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
        public static Dictionary<objects, int> cart = new Dictionary<objects, int>();
        
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
            

            numericUpDown1.Text = objList.Min(obj => obj.price).ToString();
            numericUpDown2.Text = objList.Max(obj => obj.price).ToString();
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

                objList[i].picture.Tag = objList[i].name;
                objList[i].picture.AccessibleDescription = objList[i].price.ToString();
                objList[i].picture.Click += new EventHandler(openProduct);
            }
        }
        private void openProduct(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            ProductForm form = new ProductForm(pb.Tag.ToString(), pb.AccessibleDescription);
            form.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            int x = 30;
            int y = 10;

            for (int i = 0; i < objList.Count; i++)
            {
                objList[i].picture.Visible = true;
                if (textBox1.Text != "" && 
                    !objList[i].name.Contains(textBox1.Text.ToUpper()))
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
        //Фильтры
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            int x = 30;
            int y = 10;
            for (int i = 0; i < objList.Count; i++)
            {
                objList[i].picture.Visible = true;
                bool getCategory = false;
                foreach (string category in CategoryCheckedListBox.CheckedItems)
                {
                    if (objList[i].category.Contains(category))
                        getCategory = true;
                }
                if(!getCategory && CategoryCheckedListBox.CheckedItems.Count  > 0)
                    objList[i].picture.Visible = false;
                
                if(PriceCheckedListBox.CheckedIndices.Contains(0))
                {
                    numericUpDown1.Text = objList.Min(objects => objects.price).ToString();
                    numericUpDown2.Text = "1000";
                }
                else if (PriceCheckedListBox.CheckedIndices.Contains(1))
                {
                    numericUpDown1.Text = "1001";
                    numericUpDown2.Text = "2000";
                }
                else if (PriceCheckedListBox.CheckedIndices.Contains(2))
                {
                    numericUpDown1.Text = "2001";
                    numericUpDown2.Text = "4000";
                }
                else if (PriceCheckedListBox.CheckedIndices.Contains(3))
                {
                    numericUpDown1.Text = "4001";
                    numericUpDown2.Text = "7000";
                }
                else if (PriceCheckedListBox.CheckedIndices.Contains(4))
                {
                    numericUpDown1.Text = "7001";
                    numericUpDown2.Text = objList.Max(objects => objects.price).ToString();
                }
                else
                {
                    numericUpDown1.Text = objList.Min(objects => objects.price).ToString();
                    numericUpDown2.Text = objList.Max(objects => objects.price).ToString();
                }
                
                if (numericUpDown1.Text != "0" & numericUpDown2.Text != "0")
                {
                    if (numericUpDown1.Value > objList[i].price || objList[i].price > numericUpDown2.Value) 
                    {
                            objList[i].picture.Visible = false;
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
        private void pictureBoxCart_Click(object sender, EventArgs e)
        {
            CartForm form = new CartForm();
            form.Show();
        }

        private void UserPictureBox_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.Show();
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            if (UserForm.login == "admin")
            {
                AddForm form = new AddForm();
                form.Show();
            }
            else
                MessageBox.Show("Вы не админ");
        }

        /*private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                MessageBox.Show("123");
            }
        }*/
    }
}
