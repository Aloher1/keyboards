using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp1
{
    public partial class CartForm : Form
    {
        void rename(Dictionary<string, string> words)
        {
            label1.Text = words["К оплате:"] + Program.cartPrice + words["руб."];
            label2.Text = words["Введите почту"];
            BuyButton.Text = words["Купить"];
        }
        public CartForm()
        {
            InitializeComponent();
            if (Program.language == "eng")
                rename(MainForm.eng);
            else
                rename(MainForm.rus);
            int y = 10;
            foreach (KeyValuePair<objects, int> pair in MainForm.cart)
            {
                CartUC obj = new CartUC(pair.Key, pair.Value, this.label1);
                obj.Location = new Point(10, y);
                panel1.Controls.Add(obj);
                y += 150;
            }
        }
        //
        //  Отправка письма на почту
        //
        private void BuyButton_Click(object sender, EventArgs e)
        {
            MailAddress fromAddress = new MailAddress("moonwalker7070@gmail.com", "магазин");
            MailAddress toAddress = new MailAddress(textBox1.Text, UserForm.login);
            MailMessage message = new MailMessage(fromAddress.ToString(), toAddress.ToString());
            message.Body = "спасибо";
            message.Subject = "Спасибо за покупку!";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("moonwalker7070@gmail.com", "lalka_1890");
            smtp.EnableSsl = true;
            smtp.Send(message);

            MessageBox.Show("Спасибо за покупку");
        }
    }
}
