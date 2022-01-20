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
    public partial class StartForm : Form
    {
        
        public StartForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
            EnterForm form2 = new EnterForm();
            form2.StartForm = this;
            form2.Show();
            this.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            RegForm form1 = new RegForm();
            form1.StartForm = this;
            form1.Show();
            this.Visible = false;
        }
    }
}
