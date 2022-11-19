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
        class DBconnect
        {
            MySqlConnection conn;
            MySqlConnectionStringBuilder db;

            public DBconnect()
            {
                Initialize();
            }
            private void Initialize()
            {
                db = new MySqlConnectionStringBuilder();
                db.Server = "sql7.freesqldatabase.com";        // хостинг БД
                db.Database = "sql7575921";                    // имя БД
                db.UserID = "sql7575921";                      // имя пользователя
                db.Password = "crhQxPWpVp";                    // пароль
                db.CharacterSet = "utf8";                      // кодировка БД
                conn = new MySqlConnection(db.ConnectionString);
            }
            private bool OpenConnection()
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            private void CloseConnection()
            {
                try
                {
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            public List<objects> objList()
            {
                string sql = "SELECT * FROM table1";
                List<objects> list = new List<objects>();

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objects obj = new objects();
                        obj.id = reader.GetInt32(0);
                        obj.name = reader.GetString(1);
                        obj.category = reader.GetString(2);
                        obj.price = reader.GetInt32(3);
                        obj.picture = new PictureBox();
                        obj.label = new Label();
                        obj.label.Text = obj.name;
                        list.Add(obj);
                    }
                    CloseConnection();
                }
                return list;
            }
        }
        public struct priceIndecies
        {
            public int min;
            public int max;
        }

        DBconnect db = new DBconnect();
        //public static List<objects> objList = new List<objects>();
        public static Dictionary<objects, int> cart = new Dictionary<objects, int>(); 
        
        public static Dictionary<string, string> rus = new Dictionary<string, string>();
        public static Dictionary<string, string> eng = new Dictionary<string, string>();
        
        public priceIndecies[] ind = new priceIndecies[5];

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
            //ReadAllObjects();
            translate();
            
            numericUpDown1.Text = db.objList().Min(obj => obj.price).ToString();
            numericUpDown2.Text = db.objList().Max(obj => obj.price).ToString();
            int x = 30;
            int y = 10;
            ind[0].min = db.objList().Min(obj => obj.price); ind[1].min = 1001;  
            ind[0].max = 1000;                          ind[1].max = 2000;  
            
            ind[2].min = 2001;    ind[3].min = 4001;    ind[4].min = 7001;
            ind[2].max = 4000;    ind[3].max = 7000;    ind[4].max = db.objList().Max(obj => obj.price);
            
            //MessageBox.Show("https://localhost/" + db.objList()[1].name + ".jpg");
            for (int i = 0; i < db.objList().Count; i++)
            {
                //db.objList()[i].picture = new PictureBox();
                db.objList()[i].picture.Location = new Point(x, y);
                db.objList()[i].picture.Size = new Size(120, 120);
                db.objList()[i].picture.SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    db.objList()[i].picture.ImageLocation = "../../../Pictures/" + db.objList()[i].name + ".jpg";
                    //db.objList()[i].picture.Image = Image.FromFile("../../../Pictures/" + db.objList()[i].name + ".jpg");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                panel2.Controls.Add(db.objList()[i].picture);
                // MessageBox.Show(x.ToString());
                db.objList()[i].label.Location = new Point(x, y + 120);
                db.objList()[i].label.Size = new Size(120, 75);
                db.objList()[i].label.Text = db.objList()[i].label.Text;
                panel2.Controls.Add(db.objList()[i].label);
                //MessageBox.Show(db.objList()[i].label.Text + "---" + db.objList()[i].name);
                x = x + 160;
                if (x + 130 >= Width - 250)
                {
                    x = 30;
                    y = y + 200;
                }
                db.objList()[i].picture.Tag = db.objList()[i].name;
                db.objList()[i].picture.AccessibleDescription = db.objList()[i].price.ToString();
                db.objList()[i].picture.Click += new EventHandler(openProduct);
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
        private void SearchButton_Click(object sender, EventArgs e)
        {
            int x = 30;
            int y = 10;

            for (int i = 0; i < db.objList().Count; i++)
            {
                db.objList()[i].picture.Visible = true;
                if (textBox1.Text != "" && 
                    !db.objList()[i].name.Contains(textBox1.Text.ToUpper()))
                    db.objList()[i].picture.Visible = false;
                if (db.objList()[i].picture.Visible)
                {
                    db.objList()[i].picture.Location = new Point(x, y);
                    db.objList()[i].label.Location = new Point(x, y + 120);
                    x = x + 160;
                    if (x + 130 >= Width - 250)
                    {
                        x = 30;
                        y = y + 200;
                    }
                }
                db.objList()[i].label.Visible = db.objList()[i].picture.Visible;
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
            for (int i = 0; i < db.objList().Count; i++)
            {
                db.objList()[i].picture.Visible = true;
                bool getCategory = false;
                foreach (string category in CategoryCheckedListBox.CheckedItems)
                {   
                    if (db.objList()[i].category.Contains(category))
                        getCategory = true;
                }
                if(!getCategory && CategoryCheckedListBox.CheckedItems.Count  > 0)
                    db.objList()[i].picture.Visible = false;
                
                if (numericUpDown1.Text != "0" & numericUpDown2.Text != "0")
                {
                    if (numericUpDown1.Value > db.objList()[i].price || db.objList()[i].price > numericUpDown2.Value)
                    { db.objList()[i].picture.Visible = false; }
                }
                
                if (db.objList()[i].picture.Visible)
                {
                    db.objList()[i].picture.Location = new Point(x, y);
                    db.objList()[i].label.Location = new Point(x, y + 120);
                    x = x + 160;
                    if (x + 130 >= Width - 250)
                    {
                        x = 30;
                        y = y + 200;
                    }
                }
                db.objList()[i].label.Visible = db.objList()[i].picture.Visible;
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