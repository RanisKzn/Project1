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
    
    public partial class FormPrepodInfo : Form
    {
        Professor Professor;
        FindProfessor FindProfessor;
        Users Users;
        public FormPrepodInfo(FindProfessor findProfessor, Professor professor)
        {
            InitializeComponent();
            this.Professor = professor;
            this.FindProfessor = findProfessor;
            this.UpdateListBoxTheses();
            this.UpdateListBoxStudent();
            label10.Text = listBox1.Items.Count.ToString() + "/8";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void UpdateListBoxStudent()
        {
            this.listBox2.Items.Clear();
            using (RanisLohContainer db = new RanisLohContainer())
            {
                var StudentList = from t in db.StudentSet
                                  where t.Professor.Name == Professor.Name
                                  select t;
                List<Student> students = StudentList.ToList();
                if(students.Count != 0)
                {
                    foreach (Student student in StudentList)
                    {
                        listBox2.Items.Add(student.Surname + " " + student.Name + " " + student.NumberGroup);
                    }
                }
            }
        }
        private void UpdateListBoxTheses()
        {
            this.listBox1.Items.Clear();
            using (RanisLohContainer db = new RanisLohContainer())
            {
                var ThesesList = from t in db.ThesisSet
                                 where t.Professor.Name == (from p in db.ProfessorSet
                                                            where p.Name == Professor.Name
                                                            select p).FirstOrDefault().Name
                                 select t;
                List<Thesis> theses = ThesesList.ToList();
                if (theses.Count !=0)
                {
                    foreach (Thesis thesis in ThesesList)
                    {
                        listBox1.Items.Add(thesis.Name);
                    }

                }
                

            }


        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FindProfessor.Visible = true;
        }
    }
}
