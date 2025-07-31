using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailWayScaffolding
{
    public partial class InitCommand : Form
    {
        Form1 f1;
        public InitCommand(Form1 f1)
        {
            this.f1 = f1;

            InitializeComponent();

            EkikanParamTextBox.Text = "30.0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1.EkikanParameterStr = EkikanParamTextBox.Text;
        }
    }
}
