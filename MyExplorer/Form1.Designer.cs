namespace MyExplorer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDriversAndFolders = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.lvFolders = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.Undo = new System.Windows.Forms.Button();
            this.comboBoxPath = new System.Windows.Forms.ComboBox();
            this.Redo = new System.Windows.Forms.Button();
            this.tipForSize = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 554);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDriversAndFolders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvFolders);
            this.splitContainer1.Size = new System.Drawing.Size(865, 523);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvDriversAndFolders
            // 
            this.tvDriversAndFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDriversAndFolders.ImageIndex = 0;
            this.tvDriversAndFolders.ImageList = this.icons;
            this.tvDriversAndFolders.Location = new System.Drawing.Point(0, 0);
            this.tvDriversAndFolders.Name = "tvDriversAndFolders";
            this.tvDriversAndFolders.SelectedImageIndex = 0;
            this.tvDriversAndFolders.Size = new System.Drawing.Size(188, 523);
            this.tvDriversAndFolders.TabIndex = 0;
            this.tvDriversAndFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDriversAndFolders_AfterSelect);
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "MyComputer.png");
            this.icons.Images.SetKeyName(1, "Drive.png");
            this.icons.Images.SetKeyName(2, "Folder.png");
            // 
            // lvFolders
            // 
            this.lvFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.date,
            this.type,
            this.size});
            this.lvFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFolders.GridLines = true;
            this.lvFolders.HideSelection = false;
            this.lvFolders.Location = new System.Drawing.Point(0, 0);
            this.lvFolders.Name = "lvFolders";
            this.lvFolders.Size = new System.Drawing.Size(673, 523);
            this.lvFolders.SmallImageList = this.icons;
            this.lvFolders.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvFolders.StateImageList = this.icons;
            this.lvFolders.TabIndex = 0;
            this.lvFolders.UseCompatibleStateImageBehavior = false;
            this.lvFolders.View = System.Windows.Forms.View.Details;
            this.lvFolders.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvFolders_ItemSelectionChanged);
            this.lvFolders.SelectedIndexChanged += new System.EventHandler(this.lvFolders_SelectedIndexChanged);
            this.lvFolders.DoubleClick += new System.EventHandler(this.lvFolders_DoubleClick);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 230;
            // 
            // date
            // 
            this.date.Text = "Data Modified";
            this.date.Width = 152;
            // 
            // type
            // 
            this.type.Text = "Type";
            this.type.Width = 69;
            // 
            // size
            // 
            this.size.Text = "Size";
            this.size.Width = 72;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Undo);
            this.panel2.Controls.Add(this.comboBoxPath);
            this.panel2.Controls.Add(this.Redo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 31);
            this.panel2.TabIndex = 5;
            // 
            // Undo
            // 
            this.Undo.Image = ((System.Drawing.Image)(resources.GetObject("Undo.Image")));
            this.Undo.Location = new System.Drawing.Point(3, 2);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(91, 27);
            this.Undo.TabIndex = 4;
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // comboBoxPath
            // 
            this.comboBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPath.FormattingEnabled = true;
            this.comboBoxPath.Location = new System.Drawing.Point(192, 3);
            this.comboBoxPath.Name = "comboBoxPath";
            this.comboBoxPath.Size = new System.Drawing.Size(673, 28);
            this.comboBoxPath.TabIndex = 0;
            this.comboBoxPath.SelectedIndexChanged += new System.EventHandler(this.comboBoxPath_SelectedIndexChanged);
            this.comboBoxPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBoxPath_MouseClick);
            // 
            // Redo
            // 
            this.Redo.Image = ((System.Drawing.Image)(resources.GetObject("Redo.Image")));
            this.Redo.Location = new System.Drawing.Point(100, 3);
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(88, 25);
            this.Redo.TabIndex = 3;
            this.Redo.UseVisualStyleBackColor = true;
            this.Redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 554);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvDriversAndFolders;
        private System.Windows.Forms.ListView lvFolders;
        private System.Windows.Forms.ComboBox comboBoxPath;
        public System.Windows.Forms.ImageList icons;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button Redo;
        private System.Windows.Forms.ToolTip tipForSize;
        private System.Windows.Forms.Panel panel2;
    }
}

