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
using MyLib;

namespace oaip5
{
    public partial class AdminForm : Form
    {

        EnterForm enterForm;
        RegForm regForm;
        Users Users;
        string name ;
        public AdminForm(/*EnterForm enterForm, Users users*/)
        {
            InitializeComponent();
            //this.enterForm = enterForm; 
           // this.Users = users;
            using (RanisLohContainer db = new RanisLohContainer())
            {
                foreach (Users user in db.UsersSet)
                {
                    if(user.Role == "Студент")
                    {
                        listBox1.Items.Add(user.Login);
                    }
                    
                    else if(user.Role == "Преподаватель")
                    {
                        listBox2.Items.Add(user.Login);
                    }
                }
            }

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
        private void UpdateListBox(ListBox listBox)
        {
            listBox.Items.Clear();
            using (RanisLohContainer db = new RanisLohContainer())
            {
                for (int i = 0; i < db.UsersSet.ToList().Count; i++)
                { 
                    if (db.UsersSet.ToList()[i].Role == "Студент" && listBox == listBox1)
                    {
                        listBox1.Items.Add(db.UsersSet.ToList()[i].Login);
                    }
                    if (db.UsersSet.ToList()[i].Role == "Преподаватель" && listBox == listBox2)
                    {
                        listBox2.Items.Add(db.UsersSet.ToList()[i].Login);
                    }
                }
            }
        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {

           
                if (comboBox2.SelectedItem.ToString() == "Студент")
                {
                using (RanisLohContainer db = new RanisLohContainer())
                {
                    Student student = new Student()
                    {

                        Name = richTextBox2.Text + " " + richTextBox3.Text + " " + richTextBox4.Text,
                        NumberGroup = richTextBox5.Text,
                        PersonalData = comboBox1.SelectedItem.ToString(),
                        //Photo = this.imageBytes
                    };
                    db.StudentSet.Add(student);
                    db.SaveChanges();
                    Users users = new Users()
                    {
                        Student = student,
                        Login = richTextBox6.Text,
                        Email = richTextBox6.Text,
                        Password = this.GetHashString(richTextBox7.Text),
                        Role = (string)comboBox2.SelectedItem
                    };
                    db.UsersSet.Add(users);
                    db.SaveChanges();


                }
                UpdateListBox(listBox1);
                
                }
                else if (comboBox2.SelectedItem.ToString() == "Преподаватель")
                {
                    using (RanisLohContainer db = new RanisLohContainer())
                    {
                        Professor professor = new Professor()
                        {
                            Name = richTextBox2.Text + " " + richTextBox3.Text + " " + richTextBox4.Text,
                            Position = richTextBox5.Text,
                            PersonalData = richTextBox1.Text,
                            //Photo = this.imageBytes
                        };
                        db.ProfessorSet.Add(professor);
                        db.SaveChanges();
                        Users users = new Users()
                        {
                            Professor = professor,
                            Login = richTextBox6.Text,
                            Email = richTextBox6.Text,
                            Password = this.GetHashString(richTextBox7.Text),
                            Role = (string)comboBox2.SelectedItem
                        };
                        db.UsersSet.Add(users);
                        db.SaveChanges();
                    UpdateListBox(listBox2);


                    }
                }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            using (RanisLohContainer db = new RanisLohContainer())
            {
                //foreach (Users user in db.UsersSet)
                //{
                
                
                if (listBox1.SelectedItem != null)
                {

                        Users user = (from t in db.UsersSet
                                      where t.Login == name
                                      select t).FirstOrDefault();
                        db.StudentSet.Remove(user.Student);
                        db.UsersSet.Remove(user);
                        db.SaveChanges();
                        listBox1.Update();
                    UpdateListBox(listBox1);

                }
                else if (listBox2.SelectedItem != null)
                {
                    
                        Users user = (from t in db.UsersSet
                                      where t.Login == name
                                      select t).FirstOrDefault();
                        db.ProfessorSet.Remove(user.Professor);
                        db.UsersSet.Remove(user);
                        db.SaveChanges();
                    UpdateListBox(listBox2);

                }

                    //if (listBox1.SelectedItem.ToString()==user.Login && user.Role == "Студент")
                    //{
                    //    db.StudentSet.Remove(user.Student);
                    //    db.UsersSet.Remove(user);
                    //    db.SaveChanges();
                    //}
                    //if (listBox1.SelectedItem.ToString() == user.Login && user.Role == "Преподаватель")
                    //{
                    //    db.ProfessorSet.Remove(user.Professor);
                    //    db.UsersSet.Remove(user);
                    //    db.SaveChanges();
                    //}

                //}
                
                listBox1.Update();
            }
        }

        private void listBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            StartForm startForm = new StartForm();
            startForm.Visible = true;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.name = listBox1.SelectedItem.ToString();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.name = listBox2.SelectedItem.ToString();
        }
    }
}
