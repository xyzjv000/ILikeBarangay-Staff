using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iliekbarangay
{
    public partial class FingerUpdate : Form
    {
        public FingerUpdate()
        {
            InitializeComponent();
        }
        public String FormName
        {
            get { return formName.Text; }
            set { formName.Text = value; }
        }

        private void clsBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
