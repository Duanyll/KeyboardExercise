using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KeybordExercise
{
    public partial class SinpleExerciseForm : Form
    {
        private const int CHAR_DISPLAY_COUNT = 8;

        private string chars;
        private int totalCharCount;
        private int charSpawned;
        private int charEntered;
        private int timePass;
        private int nowIndex;
        History His;

        public SinpleExerciseForm()
        {
            InitializeComponent();
        }

        public SinpleExerciseForm(string testChars,int testCount)
        {
            chars = testChars;
            totalCharCount = testCount;
            timePass = 0;
            charSpawned = 0;
            charEntered = 0;
            InitializeComponent();
            His = new History();
            His.ExerciseName1 = testChars;
            His.ExerciseType1 = "SimpleExercise";

            progressBar1.Maximum = totalCharCount;
        }

        private void CreateChars(int count)
        {
            if (count <= 0 && count > CHAR_DISPLAY_COUNT)
            {
                throw new ArgumentOutOfRangeException("count", count, "超范围了");
            }
            Random rand = new Random();
            int MAX_CHAR = chars.Length;
            wordLabel1.Text = "";
            for (int i = 0; i < CHAR_DISPLAY_COUNT; i++)
            {
                if (count > i)
                {
                    wordLabel1.Text = wordLabel1.Text + " " + chars[rand.Next(MAX_CHAR)].ToString();
                }
                else
                {
                    wordLabel1.Text = wordLabel1.Text + " -";
                }
            }
            charSpawned += count;
        }

        private void GoNextLine()
        {
            if (totalCharCount-charSpawned <= 0)
            {
                ExitExercise();
                return;
            }
            if (totalCharCount-charSpawned >= CHAR_DISPLAY_COUNT)
            {
                CreateChars(CHAR_DISPLAY_COUNT);
            }
            else
            {
                CreateChars(totalCharCount - charSpawned);
            }
            nowIndex = 1;
        }

        private void ExitExercise()
        {
            timer1.Stop();
            His.EndTime1 = DateTime.Now;
            His.WordCount1 = totalCharCount;
            His.CorrectWordCount1 = totalCharCount;
            His.ShowMessageBox();
            this.Close();
        }

        private void SinpleExerciseForm_Load(object sender, EventArgs e)
        {
            GoNextLine();
            His.StartTime1 = DateTime.Now;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timePass++;
            infoLabel1.Text = "用时 " + timePass.ToString() + " 秒";
            infoLabel2.Text = "速度 " + (int)(charEntered / ((double)timePass/60)) + " 字/分";
        }

        private void GoNext()
        {
            //把当前位置变成勾
            wordLabel1.Text =  wordLabel1.Text.Remove(nowIndex, 1).Insert(nowIndex, "√");
            nowIndex = nowIndex + 2;
            charEntered++;
            progressBar1.Increment(1);
            infoLabel3.Text = "进度 " + (int)(charEntered*100 / (double)totalCharCount) + "%";
            if (charEntered >= totalCharCount)
            {
                ExitExercise();
                return;
            }
            if (nowIndex >= CHAR_DISPLAY_COUNT*2)
            {
                GoNextLine();
            }
        }

        //[DllImport("user32.dll")]
        //private static extern bool FlashWindow(IntPtr handle, bool bInvert);

        private void SinpleExerciseForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == wordLabel1.Text[nowIndex])
            {
                GoNext();
            }
            else
            {
                //FlashWindow(this.Handle, true);
                System.Media.SystemSounds.Hand.Play();
            }
            e.Handled = true;
        }
    }
}
