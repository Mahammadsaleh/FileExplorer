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
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyExplorer
{
    public partial class Form1 : Form
    {
        ListViewItem lvTemp;
        string[] columnArray = new string[4];
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
            if (comboBoxPath.Text.Length<=3)
            {
                return;
            }
            else
            {
                FileInfo fi = new FileInfo(comboBoxPath.Text);// file varmi yoxmu yoxlasin
                try
                {
                    FileInfo[] files = fi.Directory.GetFiles();
                    foreach (FileInfo file in files)
                    {

                        Icon iconForFile = Icon.ExtractAssociatedIcon(file.FullName);

                        if (!lvFolders.SmallImageList.Images.ContainsKey(file.Extension))//folder mi deye yoxlayir eger folderdirse iconu deyismir
                        {
                            iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                            lvFolders.SmallImageList.Images.Add(file.Extension, iconForFile);
                            lvFolders.Items.Add(file.Name, file.Extension);
                            string ext = Path.GetExtension(file.FullName);
                            long size = file.Length;
                            DateTime changeTime = Directory.GetLastWriteTime(file.FullName);
                            string typeFolder = ext;
              
                            columnArray[0] = file.Name;
                            columnArray[1] = changeTime.ToString();
                            columnArray[2] = ext;
                            if (columnArray[2]!= "File folder")
                            {
                                columnArray[3] = size.ToString();
                            }
                            
                            lvTemp = new ListViewItem(columnArray);
                            lvFolders.Items.Add(lvTemp);


                        }

                        //= file.Extension;
                    }
                }
                catch { MessageBox.Show("Acces denied"); }
            }
            
        }
    
        private void LoadingFolders()
        {
            
            lvFolders.Items.Clear();
            DirectoryInfo di = new DirectoryInfo( comboBoxPath.Text);
            
            if (Directory.Exists(comboBoxPath.Text))
            {
                try
                {
                    
                    DirectoryInfo[] folders = di.GetDirectories();
                    if (folders != null)
                    {
                        long sizeFolder = CalculateFolderSize(@"C:\Users\User\Documents\2ci kurs");
                        foreach (DirectoryInfo folder in folders)
                        {
                            DateTime changeTime = Directory.GetLastWriteTime(folder.FullName);
                            string typeFolder = "File folder";
                            //long sizeFolder = CalculateFolderSize(folder.FullName);
                            columnArray[0] = folder.ToString();
                            columnArray[1] = changeTime.ToString();
                            columnArray[2] = typeFolder;
                            string size = sizeFolder.ToString() + "Kb";
                            columnArray[3] = "";
                            lvTemp = new ListViewItem(columnArray, 2);
                            lvFolders.Items.Add(lvTemp);
                        }
                    }
                }
                catch { Console.WriteLine("Acces denied"); }
            }
        }
        protected static long CalculateFolderSize(string folder)
        {
            long folderSize = 0;
            try
            {
                //Checks if the path is valid or not
                if (!Directory.Exists(folder))
                    return folderSize;
                else
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(folder))
                        {
                            if (File.Exists(file))
                            {
                                FileInfo finfo = new FileInfo(file);
                                folderSize += finfo.Length;
                            }
                        }

                        foreach (string dir in Directory.GetDirectories(folder))
                            if(folderSize< 1000000000)
                            folderSize += CalculateFolderSize(dir);
                    }
                    catch (NotSupportedException e)
                    {
                        Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
            }
            return folderSize;
        }

        long FolderSize(DirectoryInfo folder)
        {
            long size =0;
            long totalSize = folder.EnumerateFiles().Sum(file => file.Length);
            foreach (FileInfo file in folder.GetFiles())
            {
                size +=file.Length;
            }
            return totalSize;
        }
        
        private void tvDriversAndFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (lvFolders.Items.Count != 0)
            {
                lvFolders.Items.Clear();
            }
            

            comboBoxPath.Text = e.Node.Text;
            pathArr.Add(comboBoxPath.Text);
            iter++;
            LoadingFolders();
            

        }
        string pathForSlected = @"c:\";
        string path = "";
        List<string> pathArr=new List<string>();
        int iter = -1;
        private void lvFolders_DoubleClick(object sender, EventArgs e)
        {
         
            comboBoxPath.Items.Add(comboBoxPath.Text);
            comboBoxPath.Text += path + @"\";

            if (File.Exists(comboBoxPath.Text.Substring(0, comboBoxPath.Text.Length-1)))
            {
                //using (StreamReader sr = File.OpenText(comboBoxPath.Text.Substring(0, comboBoxPath.Text.Length - 1)))
                //{
                //    String s = "";
                //    TextFileOpener textFileopen = new TextFileOpener();

                //    while ((s = sr.ReadLine()) != null)
                //    {
                //        textFileopen.rtbMain.Text += s;
                //    }
                //    textFileopen.Show();
                //}

                ProcessStartInfo psStartInfo = new ProcessStartInfo();
                psStartInfo.FileName = comboBoxPath.Text;
                Process ps = Process.Start(psStartInfo);
                comboBoxPath.Text = comboBoxPath.Text.Substring(0, comboBoxPath.Text.Length - (path.Length + 1));

            }
            else
            {
                lvFolders.Items.Clear();

                tipForSize.RemoveAll();
                pathArr.Add(comboBoxPath.Text);
                iter++;

                LoadingFolders();
                LoadingFiles();
            }
           
            // axirdan 4cu noqtedirse bu fayldir

        }
        
        private void lvFolders_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            path = e.Item.Text;
            tipForSize.RemoveAll();
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
            if (iter>0)
            {
                iter--;
                comboBoxPath.Text = pathArr[iter];
                LoadingFolders();
                LoadingFiles();
            }
            
            
            //lvFolders_ItemSelectionChanged(sender,e);
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            if (iter<pathArr.Count-1)
            {
                iter++;
                comboBoxPath.Text = pathArr[iter];
                LoadingFolders();
                LoadingFiles();
            }
            
            
        }
        
        private void lvFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            pathForSlected = comboBoxPath.Text +path;
         
            long sizeFolder = CalculateFolderSize(pathForSlected);
            string size = sizeFolder.ToString() + "byte";
            tipForSize.SetToolTip(lvFolders, size);
            pathForSlected = pathForSlected.Substring(0, pathForSlected.Length - (path.Length + 1));
         
            //tipForSize.Show(size, lvFolders);
        }
    }
}
