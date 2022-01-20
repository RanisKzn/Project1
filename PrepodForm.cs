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
using MyLib;

namespace oaip5
{
    public partial class PrepodForm : Form
    {
        EnterForm EnterForm;
        Users Users;
        public PrepodForm(EnterForm enterForm, Users users)
        {
            InitializeComponent();
            this.EnterForm = enterForm;
            this.Users = users;
            this.UpdateListBoxTheses();
            this.UpdateListBoxStudent();
            groupBox1.Visible = false;
            label13.Text = listBox1.Items.Count.ToString() + "/8";

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            StartForm startForm = new StartForm();
            startForm.Visible = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

            using (RanisLohContainer db = new RanisLohContainer())
            {
                Professor ModifiableProfessor = (from p in db.ProfessorSet
                                                 where p.Name == Users.Professor.Name
                                                 select p).FirstOrDefault();

                Thesis thesis = new Thesis()
                {
                    Name = richTextBox1.Text,
                    Annotation = richTextBox1.Text,
                    Professor = ModifiableProfessor
                };
                db.ThesisSet.Add(thesis);
                ModifiableProfessor.Thesis.Add(thesis);
                db.SaveChanges();
            }
            this.UpdateListBoxTheses();

        }
        private void UpdateListBoxTheses()
        {
            this.listBox2.Items.Clear();
            using (RanisLohContainer db = new RanisLohContainer())
            {
                var ThesesList = from t in db.ThesisSet
                                 where t.Professor.Name == (from p in db.ProfessorSet
                                                            where p.Name == Users.Professor.Name
                                                            select p).FirstOrDefault().Name
                                 select t;
                //List<Thesis> theses = ThesesList.ToList();
                //if (ThesesList.Count() != 0)
                //{
                //    foreach (Thesis thesis in ThesesList.ToList())
                //    {
                //        this.listBox2.Items.Add(thesis.Name);
                //    }
                //}
                //else
                //{
                //    return;
                //}
            }


        }
        private void UpdateListBoxStudent()
        {
            this.listBox1.Items.Clear();
            using (RanisLohContainer db = new RanisLohContainer())
            {
                var StudentList = from t in db.StudentSet
                                  where t.Professor.Name == (from p in db.ProfessorSet
                                                             where p.Name == Users.Professor.Name
                                                             select p).FirstOrDefault().Name
                                 select t;
                //foreach (Student student in StudentList)
                //{
                //    this.listBox1.Items.Add(student.Surname+" "+ student.Name + " " + student.NumberGroup);
                //}

            }


        }

        private void button1_Click(object sender, EventArgs e)
        { try
            {
                using (RanisLohContainer db = new RanisLohContainer())
                {
                    string str = Convert.ToString(listBox2.SelectedItem);
                    Thesis ModifiableThesis = (from t in db.ThesisSet
                                               where t.Name == str
                                               select t).FirstOrDefault();
                    db.ThesisSet.Remove(ModifiableThesis);
                    db.SaveChanges();
                }
                this.UpdateListBoxTheses();
            }
            catch { }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FindStudent findStudent = new FindStudent(this);
            findStudent.Show();
            this.Visible = false;

        }

        private void label6_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            groupBox1.Visible = true;
            using (RanisLohContainer db = new RanisLohContainer())
            {
                foreach (Users users in db.UsersSet)
                {
                    if (users.Student != null)
                    {
                        listBox3.Items.Add(users.Student.Surname + "" + users.Student.Name + "" + users.Student.NumberGroup);
                    }

                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (RanisLohContainer db = new RanisLohContainer())
            {
                if (listBox3.SelectedItem != null)
                {
                    string SelectedName = Convert.ToString(listBox3.SelectedItem);
                    Student student =
                                    (from s in db.StudentSet
                                     where s.Surname + s.Name + s.NumberGroup == SelectedName
                                     select s).FirstOrDefault();
                    if (student.Photo != null)
                    {
                        pictureBox2.Image = (Image)((new ImageConverter()).ConvertFrom(student.Photo));
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка выбора");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox3.SelectedItem != null)
            {
                using (RanisLohContainer db = new RanisLohContainer())
                {
                    //foreach (Student student in db.StudentSet)
                    for (int i = 0; i < db.StudentSet.ToList().Count; i++)
                    {
                        //if (student.Surname + student.Name + student.NumberGroup == listBox3.SelectedItem.ToString())
                        if (db.StudentSet.ToList()[i].Surname + db.StudentSet.ToList()[i].Name + db.StudentSet.ToList()[i].NumberGroup == listBox3.SelectedItem.ToString())
                        {
                            if (db.StudentSet.ToList()[i].Professor == null)
                            {
                                db.Entry(Users.Professor).State = EntityState.Modified;
                                Users.Professor.Student.Add(db.StudentSet.ToList()[i]);
                                //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa сработало)))))) связб поменять? ща 
                                listBox1.Items.Add(listBox3.SelectedItem.ToString());
                                MessageBox.Show("HA-HA"); //запускай!)) ААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААА(
                                                          //еще раз запусти, условие неверно записал((ЧТООООООО*??? серьезно???? УРАААААААААААА
                                label13.Text = listBox1.Items.Count.ToString() + "/8";
                                //db.Entry(Users.Professor).State = EntityState.Added;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    db.SaveChanges();
                }
            }
            

        }
    }
}
