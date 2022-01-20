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
    public partial class FindProfessor : Form
    {
        StudentForm studentForm;
        FormPrepodInfo FormPrepodInfo;
        public FindProfessor(string name)
        {
            InitializeComponent();
            label1.Text = name;
            UpdateListBoxProfessor();
            button3.BackColor = Color.Transparent;
        }

        private void FindProfessor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (RanisLohContainer db = new RanisLohContainer())
            {
                foreach (Professor professor in db.ProfessorSet)
                {
                    listBox1.Items.Add(professor.Surname + " " + professor.Name + " " + professor.Otchestvo);
                }

            }
            



        }

        private void UpdateListBoxProfessor()
        {
            this.listBox1.Items.Clear();
            using (RanisLohContainer db = new RanisLohContainer())
            {
                
                    foreach (Professor professor in db.ProfessorSet)
                    {
                        listBox1.Items.Add(professor.Surname + " " + professor.Name + " " + professor.Otchestvo);
                    }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                
                using (RanisLohContainer db = new RanisLohContainer())
                {
                    foreach (Professor professor in db.ProfessorSet)
                    {
                        if (professor.Surname + " " + professor.Name + " " + professor.Otchestvo == listBox1.SelectedItem.ToString())
                        {
                            this.FormPrepodInfo = new FormPrepodInfo(this, professor);
                            this.FormPrepodInfo.Show();
                            this.FormPrepodInfo.label2.Text = professor.Surname;
                            this.FormPrepodInfo.label5.Text = professor.Name;
                            this.FormPrepodInfo.label6.Text = professor.Otchestvo;
                            this.FormPrepodInfo.label9.Text = professor.SocialNtork;

                            this.FormPrepodInfo.label7.Text = professor.Position;
                            this.FormPrepodInfo.label4.Text = professor.PersonalData;
                            //this.FormPrepodInfo.listBox2.Text = professor.Student;
                            if (professor.Photo != null)
                            {
                                this.FormPrepodInfo.pictureBox1.Image = (Image)((new ImageConverter()).ConvertFrom(professor.Photo));
                            }
                        }
                    }
                    this.Visible = false;

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
                foreach (Professor professor in db.ProfessorSet)
                {
                    if (textBox1.Text == professor.Name || textBox1.Text == professor.Surname|| textBox1.Text == professor.Otchestvo)
                    {
                        listBox1.Items.Add(professor.Surname + " " + professor.Name + " " + professor.Otchestvo);
                    }
                    
                }

            }
        }
    }
}
