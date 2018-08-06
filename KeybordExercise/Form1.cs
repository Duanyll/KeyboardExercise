using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KeybordExercise
{
    public enum TXTReturnMode
    {
        LinkWithSpace,
        LinkWithoutSpace,
        DoNotLink
    }

    enum XMLReturnMode
    {
        Auto,        
        LinkWithSpace,
        LinkWithoutSpace,
        DoNotLink
    }

    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }        

        private void label1_Click(object sender, EventArgs e)
        {
            AboutBox1 Aboutbox = new AboutBox1();
            Aboutbox.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && checkBox1.Checked)
            {
                MessageBox.Show("请输入需要的字符（小写）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (String i in listBox1.SelectedItems)
            {
                SinpleExerciseForm Exerciseform = new SinpleExerciseForm(i.Split(' ')[0], Convert.ToInt32(numericUpDown1.Value));
                Exerciseform.ShowDialog();
            }
            if (checkBox1.Checked)
            {
                SinpleExerciseForm Exerciseform = new SinpleExerciseForm(textBox1.Text, Convert.ToInt32(numericUpDown1.Value));
                Exerciseform.ShowDialog();
            }
            Properties.Settings.Default.LastSimpleTimes = Convert.ToInt32(numericUpDown1.Value);
            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            const string ALLOW_CHAR = "`1234567890-=qwertyuiop[]\\asdfghjkl;\'zxcvbnm,./";
            if (!ALLOW_CHAR.Contains(e.KeyChar))
            {
                if (!char.IsControl(e.KeyChar))
                {
                    MessageBox.Show("只能输入无需换档键的字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Handled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                textBox3.Lines = lines;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
            {
                MessageBox.Show("请打开或输入文档", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TextExerciseForm ExerciseForm = new TextExerciseForm(textBox3.Lines,(TXTReturnMode)Properties.Settings.Default.TxtReturn);
                ExerciseForm.ShowDialog();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label4.Text = "共 " + textBox3.Text.Length + " 字";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XMLChooseForm XMLForm = new XMLChooseForm();
            XMLExercise Ex = XMLForm.ShowDialog();
            textBox4.Text = Ex.ExerciseName;
            textBox5.Clear();
            foreach (string i in Ex.ExerciseLines)
            {
                textBox5.Text += i + Environment.NewLine;
            }
            textBox6.Text = Ex.ExerciseType;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("请打开或输入文档", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TXTReturnMode mode;
                switch((XMLReturnMode)Properties.Settings.Default.XMLReturn)
                {
                    case XMLReturnMode.Auto:
                        if (textBox6.Text.Contains("jump"))
                        {
                            mode = TXTReturnMode.LinkWithSpace;
                        }
                        if (textBox6.Text.Contains("article"))
                        {
                            mode = TXTReturnMode.DoNotLink;
                            break;
                        }
                        if (textBox6.Text.Contains("phrase"))
                        {
                            mode = TXTReturnMode.DoNotLink;
                            break;
                        }
                        if (textBox6.Text.Contains("word"))
                        {
                            mode = TXTReturnMode.LinkWithSpace;
                            break;
                        }
                        if (textBox6.Text.Contains("nov"))
                        {
                            mode = TXTReturnMode.DoNotLink;
                            break;
                        }
                        mode = TXTReturnMode.DoNotLink;
                        break;
                    case XMLReturnMode.DoNotLink:
                        mode = TXTReturnMode.DoNotLink;
                        break;
                    case XMLReturnMode.LinkWithoutSpace:
                        mode = TXTReturnMode.LinkWithoutSpace;
                        break;
                    case XMLReturnMode.LinkWithSpace:
                        mode = TXTReturnMode.LinkWithSpace;
                        break;
                    default:
                        mode = TXTReturnMode.LinkWithSpace;
                        break;
                }
                TextExerciseForm ExerciseForm = new TextExerciseForm(textBox5.Lines,mode);
                ExerciseForm.ShowDialog();
            }
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            textBox7.Text = Properties.Settings.Default.KingsoftInstallPath;
            comboBox1.SelectedIndex = Properties.Settings.Default.TxtReturn;
            comboBox2.SelectedIndex = Properties.Settings.Default.XMLReturn;
            checkBox2.Checked = Properties.Settings.Default.RecordHistory;
            numericUpDown1.Value = Properties.Settings.Default.LastSimpleTimes;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.KingsoftInstallPath = textBox7.Text;
            Properties.Settings.Default.Save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TxtReturn = comboBox1.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.XMLReturn = comboBox2.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要重置设置吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
                textBox7.Text = Properties.Settings.Default.KingsoftInstallPath;
                comboBox1.SelectedIndex = Properties.Settings.Default.TxtReturn;
                comboBox2.SelectedIndex = Properties.Settings.Default.XMLReturn;
                checkBox2.Checked = Properties.Settings.Default.RecordHistory;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RecordHistory = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
        }

        public void AppendTextToHistory(string x)
        {
            textBox8.AppendText(x + Environment.NewLine);
        }
    }
}
