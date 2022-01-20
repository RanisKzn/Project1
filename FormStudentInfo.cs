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
    public partial class FormStudentInfo : Form
    {
        FindStudent findStudent;
        public FormStudentInfo(FindStudent findStudent)
        {
            this.findStudent = findStudent;
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            findStudent.Visible = true;
        }

        private void FormStudentInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
