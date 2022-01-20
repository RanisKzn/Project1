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
using MyLib;
using System.Net.Sockets;

namespace oaip5
{
    public partial class EnterForm : Form
    {
        RegForm RegForm;
        public StartForm StartForm;
        StudentForm StudentForm;
        PrepodForm PrepodForm;
        AdminForm AdminForm;
        TcpClient client = new TcpClient("127.0.0.1", 8888);
        Byte[] data;
        NetworkStream stream;
        MyLib.Message m, m1, m2;
        ComplexMessage cm = new ComplexMessage();

        //FormAdminPanel FormAdminPanel;

        public EnterForm()
        {
            InitializeComponent();
            this.stream = client.GetStream();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 form4 = new Form4();
            this.Visible = true;   
            form4.Show();


        }

        private void label2_Click(object sender, EventArgs e)
        {
            RegForm = new RegForm();
            RegForm.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RegForm regForm = new RegForm();
            regForm.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.m1 = SerializeAndDeserialize.Serialize(textBox1.Text);
            this.m2 = SerializeAndDeserialize.Serialize(textBox2.Text);
            this.cm.First = this.m1;
            this.cm.Second = this.m2;
            this.cm.NumberStatus = 1;
            this.m = SerializeAndDeserialize.Serialize(this.cm);
            data = this.m.Data;
            stream.Write(data, 0, data.Length);
            if (stream.CanRead)
            {
                int numberOfBytesRead = 0;
                byte[] readingData = new byte[6297630];
                do
                {
                    numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                }
                while (stream.DataAvailable); 
                this.m.Data = readingData;
                this.cm =(ComplexMessage)SerializeAndDeserialize.Deserialize(m);
                if (cm.NumberStatus == 2)
                {
                    ComplexMessage complexMessage = (ComplexMessage)SerializeAndDeserialize.Deserialize(m);
                    Users user1 = (Users) SerializeAndDeserialize.Deserialize(complexMessage.First);
                    
                    
                    if (user1.Role == "Студент")
                    {
                        Student student = (Student)SerializeAndDeserialize.Deserialize(complexMessage.Second);
                        this.StudentForm = new StudentForm(this, user1);
                        this.StudentForm.Text = "Профиль " + user1.Student.Name;
                        this.StudentForm.label1.Text = user1.Role + ":" + user1.Student.Surname + " " + user1.Student.Name + " " + user1.Student.NumberGroup;
                        this.StudentForm.label2.Text = user1.Student.Surname;
                        this.StudentForm.label5.Text = user1.Student.Name;
                        this.StudentForm.label6.Text = user1.Student.Otchestvo;
                        this.StudentForm.label7.Text = user1.Student.NumberGroup;
                        this.StudentForm.label9.Text = user1.Student.Specialization;
                        this.StudentForm.label8.Text = user1.Student.PersonalData;
                        if (user1.Student.Professor != null)

                        {
                            this.StudentForm.label11.Text = user1.Student.Professor.Surname.ToString();
                        }
                        this.StudentForm.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                        if (user1.Student.Photo != null)
                        {
                            this.StudentForm.pictureBox1.Image = (Image)((new ImageConverter()).ConvertFrom(user1.Student.Photo));
                        }
                        this.Visible = false;
                        StudentForm.Visible = true;

                    }
                    else if(user1.Role == "Преподаватель")
                    {
                        Professor professor  = (Professor)SerializeAndDeserialize.Deserialize(complexMessage.Second);
                        professor = user1.Professor;
                        this.PrepodForm = new PrepodForm(this, user1);
                        this.PrepodForm.Text = "Профиль " + user1.Professor.Name;
                        this.PrepodForm.label1.Text = user1.Professor.Position + ":" + user1.Professor.Name + " " + user1.Professor.Surname;
                        this.PrepodForm.label8.Text = user1.Professor.Surname;
                        this.PrepodForm.label9.Text = user1.Professor.Name;
                        this.PrepodForm.label10.Text = user1.Professor.Otchestvo;
                        this.PrepodForm.label11.Text = user1.Professor.Position;
                        this.PrepodForm.label2.Text = user1.Professor.PersonalData;
                        if (user1.Professor.Photo != null)
                        {
                            this.PrepodForm.pictureBox1.Image = (Image)((new ImageConverter()).ConvertFrom(user1.Professor.Photo));
                        }
                        this.Visible = false;
                        PrepodForm.Visible = true;
                    }

                }
                else if(cm.NumberStatus == 3)
                {
                    MessageBox.Show("Неверный логин или пароль");

                }
            }

            //using (RanisLohContainer db = new RanisLohContainer())
            //{
            //    foreach (Users user in db.UsersSet)
            //    {
            //        this.RegForm = new RegForm();
            //        if (user.Login == textBox1.Text && user.Password == RegForm.GetHashString(textBox2.Text) && user.Role == "Студент")
            //        {
            //            this.StudentForm = new StudentForm(this, user);
            //            this.StudentForm.Text = "Профиль " + user.Student.Name;
            //            this.StudentForm.label1.Text = user.Role + ":" + user.Student.Surname + " "+user.Student.Name + " " + user.Student.NumberGroup;
            //            this.StudentForm.label2.Text = user.Student.Surname;
            //            this.StudentForm.label5.Text = user.Student.Name;
            //            this.StudentForm.label6.Text = user.Student.Otchestvo;
            //            this.StudentForm.label7.Text = user.Student.NumberGroup;
            //            this.StudentForm.label9.Text = user.Student.Specialization;
            //            this.StudentForm.label8.Text = user.Student.PersonalData;
            //            if (user.Student.Professor != null)

            //            {
            //                this.StudentForm.label11.Text = user.Student.Professor.Surname.ToString();
            //            }
            //            this.StudentForm.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            //            if (user.Student.Photo != null)
            //            {
            //                this.StudentForm.pictureBox1.Image = (Image)((new ImageConverter()).ConvertFrom(user.Student.Photo));
            //            }
            //                this.Visible = false;
            //            StudentForm.Visible = true;
            //        }
            //        else if (user.Login == textBox1.Text && user.Password == RegForm.GetHashString(textBox2.Text) && user.Role == "Преподаватель")
            //        {
            //            this.PrepodForm = new PrepodForm(this, user);
            //            this.PrepodForm.Text = "Профиль " + user.Professor.Name;
            //            this.PrepodForm.label1.Text = user.Professor.Position + ":" + user.Professor.Name + " "+ user.Professor.Surname ;
            //            this.PrepodForm.label8.Text = user.Professor.Surname;
            //            this.PrepodForm.label9.Text = user.Professor.Name;
            //            this.PrepodForm.label10.Text = user.Professor.Otchestvo;
            //            this.PrepodForm.label11.Text = user.Professor.Position;
            //            this.PrepodForm.label2.Text = user.Professor.PersonalData;
            //            if (user.Professor.Photo != null)
            //            {
            //                this.PrepodForm.pictureBox1.Image = (Image)((new ImageConverter()).ConvertFrom(user.Professor.Photo));
            //            }
            //            this.Visible = false;
            //            PrepodForm.Visible = true;
            //        }
            //        else if (user.Login == textBox1.Text && user.Password == RegForm.GetHashString(textBox2.Text) && user.Role == "Администратор")
            //        {
            //            //this.AdminForm = new AdminForm(this, user);
            //            this.AdminForm.Visible = true;
            //            this.Visible = false;
            //        }

            //    }

        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 form3 = new Form3();
            
            form3.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            StartForm.Visible = true;
        }
    }
}
