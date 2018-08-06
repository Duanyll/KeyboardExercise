using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeybordExercise
{
    public partial class InfoForm1 : Form
    {
        public InfoForm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InfoForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.DoNotShowInfoForm1 = true;
                Properties.Settings.Default.Save();
            }
        }
    }
}
