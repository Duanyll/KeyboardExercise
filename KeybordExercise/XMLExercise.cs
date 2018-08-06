using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace KeybordExercise
{
    public class XMLExercise
    {
        public List<string> ExerciseLines;
        public string ExerciseName = "NoName";
        public string ExerciseType = "None";

        public XMLExercise()
        {
            ExerciseLines = new List<string>();
        }

        public bool ReadFromString(string Content)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(Content);
                XmlNode Node = doc.SelectSingleNode(Properties.Resources.XMLRootNodeName);

                XmlNode courseInfoNode = Node.SelectSingleNode(Properties.Resources.XMLInfoNodeName);
                XmlElement xe = (XmlElement)courseInfoNode;
                ExerciseName = xe.GetAttribute(Properties.Resources.XMLExerciseNameAtt);
                ExerciseType = xe.GetAttribute(Properties.Resources.XMLExersiceTypeAtt);

                XmlNode ContentNode = Node.SelectSingleNode(Properties.Resources.XMLContentNodeName);
                XmlNodeList xnl = ContentNode.ChildNodes;
                foreach (XmlNode i in xnl)
                {
                    XmlElement xec = (XmlElement)i;
                    ExerciseLines.Add(xec.GetAttribute(Properties.Resources.XMLSentenceAtt));
                }
                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("所选XML不是正确的J山打字XML文本"+"\r\n内部信息：\r\n"+Ex.Message, "读取失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
