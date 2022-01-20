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
    public partial class Form4 : Form
    {
        RegForm regForm;
        public Form3 form3;
        StartForm startForm;
        public Form4()
        {
            InitializeComponent();
        }
        public string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            using (RanisLohContainer db = new RanisLohContainer())
            {
                //foreach (Users user in db.UsersSet)
                //{
                //    if (form3.richTextBox1.Text == user.Email)
                //    {
                //if (richTextBox1.Text == richTextBox2.Text)
                //{
                Users user = (from t in db.UsersSet
                              where t.Email == form3.richTextBox1.Text
                              select t).FirstOrDefault();
                user.Password = this.GetHashString(richTextBox2.Text);
                db.SaveChanges();
                MessageBox.Show("parol pomenyan");
                this.Visible = false;
                startForm = new StartForm();
                startForm.Visible = true;
            }
        }
    }
}
