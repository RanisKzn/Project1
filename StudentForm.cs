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
    public partial class StudentForm : Form
    {
        EnterForm EnterForm;
        Users Users;
        public string name;
        public StudentForm(EnterForm enterForm, Users users)
        {

            InitializeComponent();
            this.EnterForm = enterForm;
            this.Users = users;
            name = label1.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            StartForm startForm = new StartForm();
            startForm.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FindProfessor findProfessor = new FindProfessor("Студент: " + Users.Student.Surname + " " + Users.Student.Name +" "+Users.Student.NumberGroup);
            findProfessor.Visible = true;
        }
    }
}
