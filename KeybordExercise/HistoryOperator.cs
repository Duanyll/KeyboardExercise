using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
namespace KeybordExercise
{
    static class HistoryOperator
    {
        //private static void CreateNewFile(string FileName)
        //{
        //    XmlDocument Doc = new XmlDocument();
        //    Doc.AppendChild(Doc.CreateXmlDeclaration("1.0", "utf-8", null));

        //    var RootNode = Doc.CreateElement("KBEhistory");
        //    Doc.AppendChild(RootNode);


        //}

        //public static void Load(string FileName)
        //{
        //    if (!File.Exists(FileName))
        //    {
        //        if(System.Windows.Forms.MessageBox.Show("历史记录文件不存在！要创建一个吗？","提示",System.Windows.Forms.MessageBoxButtons.OKCancel,System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
        //        {
        //            CreateNewFile(FileName);
        //        }
        //        else
        //        {
        //            Properties.Settings.Default.RecordHistory = false;
        //            Properties.Settings.Default.Save();
        //            return;
        //        }
        //    }
        //}
    }
}
