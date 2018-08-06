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
    public partial class XMLChooseForm : Form
    {
        public XMLChooseForm()
        {
            InitializeComponent();
        }

        public new XMLExercise ShowDialog()
        {
            base.ShowDialog();
            if (textBox1.Text != "")
            {
                XMLExercise result = new XMLExercise();
                result.ReadFromString(File.ReadAllText(textBox1.Text));
                return result;
            }
            return new XMLExercise();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        #region 生成程序所在根目录的TreeView
        private void PaintTreeView(TreeView treeView, string fullPath)
        {
            try
            {
                treeView.Nodes.Clear(); //清空TreeView

                DirectoryInfo dirs = new DirectoryInfo(fullPath); //获得程序所在路径的目录对象
                DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
                FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
                int dircount = dir.Count();//获得文件夹对象数量
                int filecount = file.Count();//获得文件对象数量

                //循环文件夹
                for (int i = 0; i < dircount; i++)
                {
                    treeView.Nodes.Add(dir[i].Name);
                    string pathNode = fullPath + "\\" + dir[i].Name;
                    GetMultiNode(treeView.Nodes[i], pathNode);
                }

                //循环文件
                for (int j = 0; j < filecount; j++)
                {
                    TreeNode node = new TreeNode(file[j].Name)
                    {
                        Tag = fullPath + "\\" + file[j].Name
                    };
                    treeView.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n出错的位置为：Form1.PaintTreeView()");
            }
        }
        #endregion

        #region 遍历TreeView根节点下文件和文件夹
        private bool GetMultiNode(TreeNode treeNode, string path)
        {
            if (Directory.Exists(path) == false)
            {
                return false;
            }

            DirectoryInfo dirs = new DirectoryInfo(path); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
            FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
            int dircount = dir.Count();//获得文件夹对象数量
            int filecount = file.Count();//获得文件对象数量
            int sumcount = dircount + filecount;

            if (sumcount == 0)
            {
                return false;
            }

            //循环文件夹
            for (int j = 0; j < dircount; j++)
            {
                treeNode.Nodes.Add(dir[j].Name);
                string pathNodeB = path + "\\" + dir[j].Name;
                GetMultiNode(treeNode.Nodes[j], pathNodeB);
            }

            //循环文件
            for (int j = 0; j < filecount; j++)
            {
                TreeNode node = new TreeNode(file[j].Name)
                {
                    Tag = path + "\\" + file[j].Name
                };
                treeNode.Nodes.Add(node);
            }
            return true;
        }
        #endregion

        private void XMLChooseForm_Load(object sender, EventArgs e)
        {
            PaintTreeView(treeView1,Properties.Settings.Default.KingsoftInstallPath);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text.Contains(".xml"))
            {
                textBox1.Text = (string)treeView1.SelectedNode.Tag;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            XMLExercise result = new XMLExercise();
            result.ReadFromString(File.ReadAllText(textBox1.Text));
            textBox2.Text = result.ExerciseName;
            textBox3.Text = result.ExerciseType;
        }
    }
}
