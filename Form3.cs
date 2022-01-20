using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using MyLib;

namespace oaip5
{
    public partial class Form3 : Form
    {
        int kod;
        EnterForm enterForm;
        public Form3()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MailAddress from = new MailAddress("ranis_2@mail.ru", "Zaid Разраб(тех.моральная.поддержка)");
            MailAddress to = new MailAddress(richTextBox1.Text);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            Random rand = new Random();
            kod = rand.Next(1000, 10000);
            using (RanisLohContainer db = new RanisLohContainer())
            {
                foreach (Users user in db.UsersSet)
                {
                    if (richTextBox1.Text == user.Email)
                    {
                        m.Body = "<h1>Пароль: " + user.Password + "</h1>";
                        m.Body = "Код подтверждения " + kod;
                    }
                }
            }
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("ranis_2@mail.ru", "6919223557ranis");
            smtp.EnableSsl = true;
            smtp.Send(m);
            richTextBox2.Enabled = true;
            label3.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        { 
            if (int.Parse(richTextBox2.Text) == kod)
            {
                Form4 form4 = new Form4();
                form4.form3 = this;
                this.Visible = false;
                form4.Show();
            }
        else
            {
                MessageBox.Show("LOL, IT ISN'T TRUE");
                return;
            }
        }
    }
}
