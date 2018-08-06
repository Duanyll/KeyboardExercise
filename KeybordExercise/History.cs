using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeybordExercise
{
    class History
    {
        DateTime StartTime;
        string ExerciseName;
        string ExerciseType;
        DateTime EndTime;
        int WordCount;
        int CorrectWordCount;

        public string ExerciseName1 { get => ExerciseName; set => ExerciseName = value; }
        public DateTime StartTime1 { get => StartTime; set => StartTime = value; }
        public string ExerciseType1 { get => ExerciseType; set => ExerciseType = value; }
        public DateTime EndTime1 { get => EndTime; set => EndTime = value; }
        public int WordCount1 { get => WordCount; set => WordCount = value; }
        public int CorrectWordCount1 { get => CorrectWordCount; set => CorrectWordCount = value; }

        public void ShowMessageBox()
        {
            string Message = "";
            Message += "开始时间" + StartTime.ToLongTimeString() + "\n";
            Message += "结束时间" + EndTime.ToLongTimeString() + "\n";
            Message += "用时" + (EndTime - StartTime).ToString() + "\n";
            Message += "速度" + WordCount / (EndTime - StartTime).TotalMinutes + "字/分\n";
            Message += "正确率" + (int)(CorrectWordCount / (double)WordCount) * 100 + "%";
            System.Windows.Forms.MessageBox.Show(Message, "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public string WriteToHistory()
        {
            string Message = "";
            Message += StartTime.ToLongDateString() + "\t";
            Message += StartTime.ToLongTimeString() + "\t";
            Message += ExerciseName + "\t";
            Message += ExerciseType + "\t";
            Message += "用时" + (int)((EndTime - StartTime).TotalMinutes) + ":" + ((EndTime - StartTime).Seconds) + "\t";
            Message += "速度" + WordCount / (EndTime - StartTime).TotalMinutes + "字/分\t";
            Message += "正确率" + (int)(CorrectWordCount / (double)WordCount) * 100 + "%";
            return Message;
        }
    }
}

