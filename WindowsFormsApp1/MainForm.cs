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
    public struct objects
    {
        public int id;
        public PictureBox picture;
        public string name;
        public Label label;
        public int price;
        public string category;
        public string description;

        /*public objects(string name1, string category1, int price1)
        {
            picture = new PictureBox();
            name = name1;
            label = new Label();
            price = price1;
            category = category1;
        }*/
    }
    public struct priceIndecies
    {
        public int min;
        public int max;
    }

    public partial class MainForm : Form
    {
        
        public struct priceIndecies
        {
            public int min;
            public int max;
        }

        Program.DBconnect db = new Program.DBconnect();
        
        public static Dictionary<objects, int> cart = new Dictionary<objects, int>();

        public priceIndecies[] ind = new priceIndecies[5];

        public List<objects> objects = new List<objects>();
        
        /*void ReadAllObjects()
        {
            objList.Clear();
            string[] lines = File.ReadAllLines("../../../Objects.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { "," }, StringSplitOptions.None);
                objList.Add(new objects(parts[0], parts[1], Convert.ToInt32(parts[2])));
            }
        }*/

        /*public static void translate()
        {
            string[] ruslines = File.ReadAllLines("../../../Translate/rus.txt");
            foreach (string line in ruslines)
            {
                string[] parts = line.Split(new string[] { "," }, StringSplitOptions.None);
                rus.Add(parts[0], parts[1]);
            }

            string[] englines = File.ReadAllLines("../../../Translate/eng.txt");
            foreach (string line in englines)
            {
                string[] parts = line.Split(new string[] { "," }, StringSplitOptions.None);
                eng.Add(parts[0], parts[1]);
            }
        }*/
        
        public void rename(Dictionary<string,string> words)
        {
            SearchButton.Text = words["Поиск"];
            label1.Text = words["Категория"];
            label2.Text = words["Цена"];
            labelFrom.Text = words["от"];
            labelTo.Text = words["до"];
            ApplyButton.Text = words["Применить"];
            CategoryCheckedListBox.Items[0] = words["Корпуса"];
            CategoryCheckedListBox.Items[1] = words["Плейты"];
            CategoryCheckedListBox.Items[2] = words["Переключатели"];
            CategoryCheckedListBox.Items[3] = words["Платы"];
            CategoryCheckedListBox.Items[4] = words["Кейкапы"];
            PriceCheckedListBox.Items[0] = words["менее"] + "1000р";
            PriceCheckedListBox.Items[4] = words["больше"] + " " + "7001р";
        }
        public MainForm()
        {
            InitializeComponent();

            objects = db.objList();

            numericUpDown1.Text = db.objList().Min(obj => obj.price).ToString();
            numericUpDown2.Text = db.objList().Max(obj => obj.price).ToString();
            int x = 30;
            int y = 10;
            ind[0].min = db.objList().Min(obj => obj.price); ind[1].min = 1001;  
            ind[0].max = 1000;                          ind[1].max = 2000;  
            
            ind[2].min = 2001;    ind[3].min = 4001;    ind[4].min = 7001;
            ind[2].max = 4000;    ind[3].max = 7000;    ind[4].max = db.objList().Max(obj => obj.price);
            
            //MessageBox.Show(objects.Count.ToString());
            for (int i = 0; i < db.objList().Count; i++)
            {
                objects[i].picture.Location = new Point(x, y);
                objects[i].picture.Size = new Size(120, 120);
                objects[i].picture.SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    objects[i].picture.ImageLocation = "../../../Pictures/" + objects[i].name + ".jpg";
                    //objects[i].picture.Image = Image.FromFile("../../../Pictures/" + objects[i].name + ".jpg");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                panel2.Controls.Add(objects[i].picture);
                // MessageBox.Show(x.ToString());
                objects[i].label.Location = new Point(x, y + 120);
                objects[i].label.Size = new Size(120, 75);
                objects[i].label.Text = objects[i].label.Text;
                panel2.Controls.Add(objects[i].label);
                //MessageBox.Show(objects[i].label.Text + "---" + objects[i].name);
                x = x + 160;
                if (x + 130 >= Width - 250)
                {
                    x = 30;
                    y = y + 200;
                }
                objects[i].picture.Tag = objects[i].name;
                objects[i].picture.AccessibleDescription = objects[i].price.ToString();
                objects[i].picture.Click += new EventHandler(openProduct);
                try
                {
                    db.objList()[i] = objects[i];
                }
                catch(Exception ex) {MessageBox.Show(ex.Message); }
            }
            //MessageBox.Show(db.objList()[0].picture.Image.Size.ToString());
        }
        ///
        /// Открытие товара
        ///
        private void openProduct(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            ProductForm form = new ProductForm(pb.Tag.ToString(), pb.AccessibleDescription, db.objList());
            form.Show();
        }
        ///
        /// Кнопка поиска
        ///
        public void SearchButton_Click(object sender, EventArgs e)
        {
            db.objList();
            int x = 30;
            int y = 10;

            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].picture.Visible = true;
                if (textBox1.Text != "" && 
                    !objects[i].name.Contains(textBox1.Text.ToUpper()))
                    objects[i].picture.Visible = false;
                if (objects[i].picture.Visible)
                {
                    objects[i].picture.Location = new Point(x, y);
                    objects[i].label.Location = new Point(x, y + 120);
                    x = x + 160;
                    if (x + 130 >= Width - 250)
                    {
                        x = 30;
                        y = y + 200;
                    }
                }
                objects[i].label.Visible = objects[i].picture.Visible;
                try
                {
                    db.objList()[i] = objects[i];
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        ///
        /// Кнопка применить
        ///
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            db.objList();
            int x = 30;
            int y = 10;
            //
            //  Цена
            //
            if (PriceCheckedListBox.CheckedIndices.Count > 0)
            {
                List<priceIndecies> Checked = new List<priceIndecies>();
                for (int i = 0; i < ind.Length; i++)
                {
                    if (PriceCheckedListBox.CheckedIndices.Contains(i))
                        Checked.Add(ind[i]); 
                }
                numericUpDown1.Text = Checked.Min(priceIndecies => priceIndecies.min).ToString();
                numericUpDown2.Text = Checked.Max(priceIndecies => priceIndecies.max).ToString();
            }
            //
            //  Категория
            //
            rename(db.rus());
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].picture.Visible = true;
                bool getCategory = false;
                foreach (string category in CategoryCheckedListBox.CheckedItems)
                {   
                    if (objects[i].category.Contains(category))
                        getCategory = true;
                }
                if(!getCategory && CategoryCheckedListBox.CheckedItems.Count  > 0)
                    objects[i].picture.Visible = false;
                
                if (numericUpDown1.Text != "0" & numericUpDown2.Text != "0")
                {
                    if (numericUpDown1.Value > objects[i].price || objects[i].price > numericUpDown2.Value)
                    { objects[i].picture.Visible = false; }
                }
                
                if (objects[i].picture.Visible)
                {
                    objects[i].picture.Location = new Point(x, y);
                    objects[i].label.Location = new Point(x, y + 120);
                    x = x + 160;
                    if (x + 130 >= Width - 250)
                    {
                        x = 30;
                        y = y + 200;
                    }
                }
                objects[i].label.Visible = objects[i].picture.Visible;
                try
                {
                    db.objList()[i] = objects[i];
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

            if (Program.language == "eng")
                rename(db.eng());
        }        
        private void pictureBoxCart_Click(object sender, EventArgs e)
        {
            CartForm form = new CartForm();
            form.Show();
        }

        private void UserPictureBox_Click(object sender, EventArgs e)
        {
            if (Program.login != "")
            {
                MessageBox.Show("Вы уже вошли");
            }
            else
            {
                UserForm form = new UserForm();
                form.Show();
            }
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            if (Program.login == "admin")
            {
                AddForm form = new AddForm();
                form.Show();
            }
            else
                MessageBox.Show("Вы не админ");
        }
        
        private void DocPictureBox_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/@neonicdevicesforpc-klaviatury-sleng-i-terminy");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/@neonicdevicesforpc-korpus-mehanicheskoi-klaviatury");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/@exvperi-vse-chto-nuzhno-znat-pri-vybore-profilya-keikapov");
        }
        //
        //  Перевод
        //
        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.language == "rus")
            {
                rename(db.eng());
                Program.language = "eng";
                button1.Text = "EN";
            }
            else
            {
                rename(db.rus());
                Program.language = "rus";
                button1.Text = "RU";
            }
            
        }
    }
}