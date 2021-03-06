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
    public struct priceIndecies
    {
        public int min;
        public int max;
    }

    public partial class MainForm : Form
    {  
        public static List<objects> objList = new List<objects>();
        public static Dictionary<objects, int> cart = new Dictionary<objects, int>(); 
        
        public static Dictionary<string, string> rus = new Dictionary<string, string>();
        public static Dictionary<string, string> eng = new Dictionary<string, string>();
        
        public priceIndecies[] ind = new priceIndecies[5];

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

        public static void translate()
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
        }
        
        void rename(Dictionary<string, string> words)
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
            ReadAllObjects();
            translate();
            
            numericUpDown1.Text = objList.Min(obj => obj.price).ToString();
            numericUpDown2.Text = objList.Max(obj => obj.price).ToString();
            int x = 30;
            int y = 10;
            ind[0].min = objList.Min(obj => obj.price); ind[1].min = 1001;  
            ind[0].max = 1000;                          ind[1].max = 2000;  
            
            ind[2].min = 2001;    ind[3].min = 4001;    ind[4].min = 7001;
            ind[2].max = 4000;    ind[3].max = 7000;    ind[4].max = objList.Max(obj => obj.price);
            
            for (int i = 0; i < objList.Count; i++)
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
        ///
        /// Открытие товара
        ///
        private void openProduct(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            ProductForm form = new ProductForm(pb.Tag.ToString(), pb.AccessibleDescription);
            form.Show();
        }
        ///
        /// Кнопка поиска
        ///
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
        ///
        /// Кнопка применить
        ///
        private void ApplyButton_Click(object sender, EventArgs e)
        {
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
            rename(rus);
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
                
                if (numericUpDown1.Text != "0" & numericUpDown2.Text != "0")
                {
                    if (numericUpDown1.Value > objList[i].price || objList[i].price > numericUpDown2.Value)
                    { objList[i].picture.Visible = false; }
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
            if (Program.language == "eng")
                rename(eng);
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
                rename(eng);
                Program.language = "eng";
                button1.Text = "EN";
            }
            else
            {
                rename(rus);
                Program.language = "rus";
                button1.Text = "RU";
            }
            
        }
    }
}