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

namespace MyExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddMyCompNode();
            AddDriverToMyComp();
        }
        private void AddMyCompNode()
        {
            TreeNode nodeMyComp = new TreeNode("My Comp");
            nodeMyComp.ImageKey = "MyComp";
            nodeMyComp.Name = "MyComp";
            tvDriversAndFolders.Nodes.Add(nodeMyComp);
        }
        private void AddDriverToMyComp()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                string driveName = drive.Name;
                TreeNode nodeDrive = new TreeNode(driveName);
                nodeDrive.ImageIndex = 1;
                nodeDrive.SelectedImageIndex = 1;
                tvDriversAndFolders.Nodes["MyComp"].Nodes.Add(nodeDrive);
            }
            tvDriversAndFolders.Nodes["MyComp"].Expand(); //expand
        }
       
        private void LoadingFiles()
        {
            FileInfo fi = new FileInfo(comboBoxPath.Text);
            FileInfo[] files = fi.Directory.GetFiles();
            foreach (FileInfo file in files)
            {
                lvFolders.Items.Add(file.Name);
            }
        }
        private void LoadingFolders()
        {
           
            lvFolders.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(comboBoxPath.Text);
            DirectoryInfo[] folders = di.GetDirectories();

            foreach (DirectoryInfo folder in folders)
            {
                lvFolders.Items.Add(folder.Name, 2);
            }
        }

        
        private void tvDriversAndFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (lvFolders.Items.Count != 0)
            {
                lvFolders.Items.Clear();
            }
            
            comboBoxPath.Text = e.Node.Text;
            LoadingFolders();
        }

        string path = "";
        string [] pathArr = new string[20];
        int count = 0;
        private void lvFolders_DoubleClick(object sender, EventArgs e)
        {

        
            lvFolders.Items.Clear();
            comboBoxPath.Text += path + "\\";
            LoadingFolders();
            LoadingFiles();

        }
        private void lvFolders_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            path = e.Item.Text;
            pathArr[count]=path;
            count++;

        }
        private void comboBoxPath_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxPath.Text = comboBoxPath.SelectedItem.ToString();
            LoadingFolders();
            LoadingFiles();
        }

        private void comboBoxPath_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBoxPath.Items.Contains(comboBoxPath.Text) == false)
            {
                comboBoxPath.Items.Add(comboBoxPath.Text);
            }
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            comboBoxPath.Text = comboBoxPath.Text.Replace(pathArr[count-1], "");
            comboBoxPath.Text = comboBoxPath.Text.Replace("\\", "\");
            LoadingFolders();
            LoadingFiles();
            count--;
            //lvFolders_ItemSelectionChanged(sender,e);
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            comboBoxPath.Text = comboBoxPath.Text.Replace("//", "/");
            //comboBoxPath.Text=comboBoxPath.Text.Replace(pathArr[count-1], 
        }
    }
}
