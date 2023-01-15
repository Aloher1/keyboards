using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace WindowsFormsApp1
{
    static class Program
    {
        public static int    cartPrice = 0;
        public static string language = "rus";
        public static string login = "";

        public class DBconnect
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
                db.Server = "localhost";        // хостинг БД
                db.Database = "keyboards";      // имя БД
                db.UserID = "root";             // имя пользователя
                db.Password = "";               // пароль
                db.CharacterSet = "utf8";       // кодировка БД
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
            public void AddObj(string name, string category, string price, string description)
            {
                string sql = "INSERT INTO `keyboards`.`objects` ( `id` , `name` , `category` , `price` , `description` ) VALUES ( '', @name, @category, @price, @description )";
                if (OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@description", description);

                        cmd.ExecuteNonQuery();
                    }
                    CloseConnection();
                }
            }
            public void AddUser(string login, string password)
            {
                string sql = "INSERT INTO `keyboards`.`loginpassword` ( `id` , `login` , `password` ) VALUES ( '', @login, @password )";
                if (OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);

                        cmd.ExecuteNonQuery();
                    }
                    CloseConnection();
                }
            }
            public void Delete(string name)
            {
                string sql = "DELETE FROM `keyboards`.`objects` WHERE `objects`.`name` = @name";
                if (OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                    CloseConnection();
                }
                File.Delete("../../../Pictures/" + name + ".jpg");
                MessageBox.Show("Удалено");
            }
            public Dictionary<string,string> rus()
            {
                string sql = "SELECT * FROM rus";
                Dictionary<string,string> pairs = new Dictionary<string, string>();
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string key;
                        string value;
                        key = reader.GetString(0);
                        value = reader.GetString(1);
                        pairs.Add(key, value);
                    }
                    CloseConnection();
                }
                return pairs;
            }

            public Dictionary<string, string> eng()
            {
                string sql = "SELECT * FROM eng";
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string key;
                        string value;
                        key = reader.GetString(0);
                        value = reader.GetString(1);
                        pairs.Add(key, value);
                    }
                    CloseConnection();
                }
                return pairs;
            }
            public List<string> logInfo()
            {
                string sql = "SELECT * FROM loginpassword";
                List<string> list = new List<string>();

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string login;
                        string password;
                        login = reader.GetString(1);
                        password = reader.GetString(2);
                        list.Add(login); list.Add(password);
                    }
                    CloseConnection();
                }
                return list;
            }
            public List<objects> objList()
            {
                string sql = "SELECT * FROM objects";
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
                        obj.description = reader.GetString(4);
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
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
