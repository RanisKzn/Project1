using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Security.Cryptography;
using System.IO;
using System.Collections;
using System.Net.Sockets;
using MyLib;

namespace oaip5
{
    public partial class RegForm : Form
    {
        public StartForm StartForm;
        public byte[] imageBytes;
        private TcpClient client = new TcpClient("127.0.0.1", 8888);
        private Byte[] data;
        private NetworkStream stream;
        private MyLib.Message m1, m2, m;
        private ComplexMessage cm = new ComplexMessage();
        public RegForm()
        {
            InitializeComponent();
            ///richTextBox1.LostFocus += LostFocus.EventHandle(AddText);
            this.stream = client.GetStream();
            richTextBox2.Text = "Введите Фамилию...";
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox3.Text = "Введите Имя...";
            richTextBox3.BorderStyle = BorderStyle.None;
            richTextBox4.Text = "Введите Отчество...";
            richTextBox4.BorderStyle = BorderStyle.None;
            richTextBox5.Text = "Введите Группу...";
            richTextBox5.BorderStyle = BorderStyle.None;
            //richTextBox5.Text = "Введите Специальность...";
            //richTextBox5.BorderStyle = BorderStyle.None;
            richTextBox6.Text = "Введите Почту...";
            richTextBox6.BorderStyle = BorderStyle.None;
            richTextBox7.Text = "Введите Пароль...";
            richTextBox7.BorderStyle = BorderStyle.None;
            richTextBox1.Visible = false;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Text = "Введите Должность...";


        }
        private void InitComponentMessage(object first, object second, int status)
        {
            this.m1 = SerializeAndDeserialize.Serialize(first);
            this.m2 = SerializeAndDeserialize.Serialize(second);
            cm.First = m1;
            cm.Second = m2;
            cm.NumberStatus = status;
            m = SerializeAndDeserialize.Serialize(cm);
            this.data = m.Data;
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
            //{
            //    using (RanisLohContainer db = new RanisLohContainer())
            //    {

            //        Users user = new Users(richTextBox2.Text, this.GetHashString(richTextBox2.Text), richTextBox2.Text, "User");
            //        db.UsersSet.Add(user);
            //        db.SaveChanges();
            //    }
            //}
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
           
            
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            

           


            


        }

        private void richTextBox2_Enter(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "Введите Фамилию...")
            {
                richTextBox2.Text = "";
            }
        }

        private void richTextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox2.Text))
            {
                richTextBox2.Text = "Введите Фамилию...";
            }
        }

        private void richTextBox3_Enter(object sender, EventArgs e)
        {

            if (richTextBox3.Text == "Введите Имя...")
            {
                richTextBox3.Text = "";
            }
            
        }

        private void richTextBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox3.Text))
            {
                richTextBox3.Text = "Введите Имя...";
            }
        }

        private void richTextBox4_Enter(object sender, EventArgs e)
        {
           if (richTextBox4.Text == "Введите Отчество...")
            {
                richTextBox4.Text = "";
            } 
           
        }

        private void richTextBox4_Leave(object sender, EventArgs e)
        {
           if (string.IsNullOrWhiteSpace(richTextBox4.Text))
            {
                richTextBox4.Text = "Введите Отчество...";
            }
        }

        private void richTextBox6_Enter(object sender, EventArgs e)
        {
            
            if (richTextBox6.Text == "Введите Почту...")
            {
                richTextBox6.Text = "";
            }
        }

        private void richTextBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox6.Text))
            {
                richTextBox6.Text = "Введите Почту...";
            }
        }

        private void richTextBox7_Enter(object sender, EventArgs e)
        {
           
            if (richTextBox7.Text == "Введите Пароль...")
            {
                richTextBox7.Text = "";
            }
        }

        private void richTextBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox7.Text))
            {
                richTextBox7.Text = "Введите Пароль...";
            }
        }

        private void richTextBox5_Enter(object sender, EventArgs e)
        {
            if (richTextBox5.Text == "Введите Группу...")
            {
                richTextBox5.Text = "";
            }
        }

        private void richTextBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox5.Text))
            {
                richTextBox5.Text = "Введите Группу...";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Студент")
            {
                comboBox1.Visible = true;
                richTextBox1.Visible = false;
            }
            else
            {
                comboBox1.Visible = false;
                richTextBox1.Visible = true;
            }
        }

        private void richTextBox1_Enter_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Введите Должность...")
            {
                richTextBox1.Text = "";
            }
        }

        private void richTextBox1_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                richTextBox1.Text = "Введите Должность...";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() =="Студент")
            {
                richTextBox1.Enabled = true;
                using (RanisLohContainer db = new RanisLohContainer())
                {
                    Student student = new Student()
                    {

                        Name = richTextBox3.Text,
                        Surname = richTextBox2.Text,
                        Otchestvo = richTextBox4.Text,
                        NumberGroup = richTextBox5.Text,
                        Specialization = comboBox1.SelectedItem.ToString(),
                        Photo = this.imageBytes,
                    };
                    
                    Users users = new Users() {
                        Student = student,
                        Login= richTextBox6.Text,
                        Email = richTextBox6.Text,
                        Password =this.GetHashString(richTextBox7.Text),
                        Role =(string)comboBox2.SelectedItem
                    };
                    this.InitComponentMessage(student, users, 0);
                    this.Visible = false;
                    StartForm.Visible = true;
                }
            }
            else if (comboBox2.SelectedItem.ToString() =="Преподаватель")
            {
                richTextBox1.Enabled = false;
                using (RanisLohContainer db = new RanisLohContainer())
                {
                    Professor professor = new Professor()
                    {
                        Name = richTextBox3.Text,
                        Surname = richTextBox2.Text,
                        Otchestvo = richTextBox4.Text,
                        Position = richTextBox1.Text,
                        //PersonalData = richTextBox5.Text,
                        Photo = this.imageBytes,
                    };
                    //YBRAL SAVE CAHNGES
                    Users users = new Users()
                    {
                        Professor = professor,
                        Login = richTextBox6.Text,
                        Email = richTextBox6.Text,
                        Password = this.GetHashString(richTextBox7.Text),
                        Role = (string)comboBox2.SelectedItem,
                        
                    };
                    this.InitComponentMessage(professor, users, 0);
                    this.Visible = false;;
                    StartForm.Visible = true;
                }
                stream.Write(data, 0, data.Length );
                stream.Flush();
            }
            
        }

        private void RegForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image + Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.imageBytes = File.ReadAllBytes(open_dialog.FileName);
                    label3.Text = "Успешно";
                }
                catch
                {
                    label3.Text = "Ошибка";
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (StartForm != null)
            {
                StartForm.Visible = true;
            }
            else 
            {
                StartForm = new StartForm();
                StartForm.Visible = true;
            }
            
        }
    }
}
