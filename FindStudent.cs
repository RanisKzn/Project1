using MyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oaip5
{
    public partial class FindStudent : Form
    {
        PrepodForm PrepodForm;
        FormStudentInfo FormStudentInfo;
        public FindStudent(PrepodForm prepodForm)
        {

            InitializeComponent();
            label1.Text = prepodForm.label1.Text;
            
            
        }
        public FindStudent()
        {
            InitializeComponent();
        }
        private void UpdateListBoxStudent()
        {
            this.listBox1.Items.Clear();
            using (RanisLohContainer db = new RanisLohContainer())
            {

                foreach (Student student in db.StudentSet)
                {
                    listBox1.Items.Add(student.Surname + " " + student.Name + " " + student.Otchestvo);
                }

            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (RanisLohContainer db = new RanisLohContainer())
            {
                if (listBox1.SelectedItem != null)
                {
                    string SelectedName = Convert.ToString(listBox1.SelectedItem);
                    Student student = (from s in db.StudentSet
                                        where s.Name == SelectedName
                                        select s).FirstOrDefault();
                    //richTextBoxName.Text = student.Name;

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                listBox1.Items.Clear();
                using (RanisLohContainer db = new RanisLohContainer())
                {
                    foreach (Student student in db.StudentSet)
                    {
                        listBox1.Items.Add(student.Surname + " " + student.Name + " " + student.Otchestvo);
                    }

                }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            StartForm startForm = new StartForm();
            this.Visible = false;
            startForm.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (RanisLohContainer db = new RanisLohContainer())
            {
                foreach (Student student in db.StudentSet)
                {
                    if (textBox1.Text == student.Name || textBox1.Text == student.Surname || textBox1.Text == student.Otchestvo)
                    {
                        listBox1.Items.Add(student.Surname + " " + student.Name + " " + student.Otchestvo);
                    }

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                this.FormStudentInfo = new FormStudentInfo(this);
                using (RanisLohContainer db = new RanisLohContainer())
                {
                    foreach (Student student in db.StudentSet)
                    {
                        if (student.Surname + " " + student.Name + " " + student.Otchestvo == listBox1.SelectedItem.ToString())
                        {
                            this.FormStudentInfo.Show();
                            this.FormStudentInfo.label2.Text = student.Surname;
                            this.FormStudentInfo.label6.Text = student.Name;
                            this.FormStudentInfo.label7.Text = student.Otchestvo;

                            this.FormStudentInfo.label3.Text = student.NumberGroup;
                            this.FormStudentInfo.label7.Text = student.Specialization;
                            this.FormStudentInfo.label5.Text = student.PersonalData;
                            this.FormStudentInfo.label9.Text = student.SocialNetork;
                            if (student.Professor != null)
                            {
                                this.FormStudentInfo.label10.Text = student.Professor.Surname;
                            }

                            //this.FormPrepodInfo.listBox2.Text = professor.Student;
                            if (student.Photo != null)
                            {
                                this.FormStudentInfo.pictureBox1.Image = (Image)((new ImageConverter()).ConvertFrom(student.Photo));
                            }
                        }
                    }
                }
                this.Visible = false;
            }

        }
    }
}
