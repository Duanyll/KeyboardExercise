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
    public partial class TextExerciseForm : Form
    {
        const int MAX_CHARS_IN_ONE_LINE = 61;

        List<string> ExerciseText;
        int NowIndex;
        int NowIndexInPara;
        int NowTime;
        int NowIndexTotal;
        int CorretCharCount;

        public TextExerciseForm()
        {
            InitializeComponent();
        }

        public TextExerciseForm(string[] text, TXTReturnMode Mode)
        {
            InitializeComponent();
            ExerciseText = new List<string>();
            switch (Mode)
            {
                case TXTReturnMode.LinkWithSpace:
                    ExerciseText.Add("");
                    foreach (string i in text)
                    {
                        ExerciseText[0] = ExerciseText[0] + i + " ";
                    }
                    ExerciseText[0] = ExerciseText[0].Replace("\n", " ").Replace("\r", "").Replace("\t", " ");
                    ExerciseText[0] = ExerciseText[0].Remove(ExerciseText[0].Length - 1);
                    NowIndex = 0;                    
                    progressBar1.Maximum = ExerciseText[0].Length;
                    break;
                case TXTReturnMode.LinkWithoutSpace:
                    ExerciseText.Add("");
                    foreach (string i in text)
                    {
                        ExerciseText[0] = ExerciseText[0] + i + " ";
                    }
                    ExerciseText[0] = ExerciseText[0].Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    ExerciseText[0] = ExerciseText[0].Remove(ExerciseText[0].Length - 1);
                    NowIndex = 0;
                    progressBar1.Maximum = ExerciseText[0].Length;
                    break;
                case TXTReturnMode.DoNotLink:
                    ExerciseText = text.ToList();
                    progressBar1.Maximum = 0;
                    for(int i = 0;i<ExerciseText.Count;i++)
                    {
                        ExerciseText[i] = ExerciseText[i].Replace(Environment.NewLine, "");
                        progressBar1.Maximum += ExerciseText[i].Length;
                        if(ExerciseText[i] == "")
                        {
                            ExerciseText.RemoveAt(i);
                            i--;
                        }
                    }
                    break;                
            }
        }

        private void GoNextLine()
        {
            if (NowIndexInPara >= ExerciseText[NowIndex].Length - 1)
            {
                NowIndexInPara = 0;
                NowIndex++;
            }
            if (NowIndex >= ExerciseText.Count())
            {
                ExitExercice();
                return;
            }                       
            if (ExerciseText[NowIndex].Length - NowIndexInPara >= MAX_CHARS_IN_ONE_LINE)
            {
                SampleTextBox1.Text = ExerciseText[NowIndex].Substring(NowIndexInPara, MAX_CHARS_IN_ONE_LINE);
                NowIndexInPara += MAX_CHARS_IN_ONE_LINE;
                NowIndexTotal += MAX_CHARS_IN_ONE_LINE;
                UserEnterTextBox1.Clear();
            }
            else
            {
                SampleTextBox1.Text = ExerciseText[NowIndex].Substring(NowIndexInPara);
                NowIndexInPara = ExerciseText[NowIndex].Length;
                NowIndexTotal += ExerciseText[NowIndex].Length - NowIndexInPara;
                UserEnterTextBox1.Clear();
            }
        }

        private void ExitExercice()
        {
            timer1.Stop();
            MessageBox.Show("练习完成！\n" + label1.Text + "\n" + label3.Text + "\n" + label4.Text, "练习完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Compare()
        {
            int Length = SampleTextBox1.Text.Length;
            for (int i = 0; i < Length; i++)
            {
                if (SampleTextBox1.Text[i] == UserEnterTextBox1.Text[i])
                {
                    CorretCharCount++;
                }
            }
            label2.Text = "进度 " + (int)(NowIndexTotal / (double)progressBar1.Maximum * 100) + "%";
            label3.Text = "正确率 " + (int)(CorretCharCount / (double)NowIndexTotal * 100) + "%";
            label4.Text = "速度 " + (int)(NowIndexTotal / ((double)NowTime / 60.0)) + " 字/分";
            progressBar1.Increment(Length);
        }

        private void TextExerciseForm_Load(object sender, EventArgs e)
        {
            if(!Properties.Settings.Default.DoNotShowInfoForm1)
            {
                var InfoForm = new InfoForm1();
                InfoForm.ShowDialog();
            }
            NowIndex = NowIndexInPara = NowIndexTotal = 0;
            GoNextLine();
            NowTime = 0;
            CorretCharCount = 0;
            timer1.Start();
        }

        private void UserEnterTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (UserEnterTextBox1.Text.Length >= SampleTextBox1.Text.Length)
            {
                Compare();
                GoNextLine();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NowTime++;
            label1.Text = "用时 " + NowTime + " 秒";
        }
    }
}
