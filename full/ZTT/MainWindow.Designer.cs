namespace ZTT
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlMiddleRight = new System.Windows.Forms.Panel();
            this.lstFiles = new System.Windows.Forms.ListView();
            this.ilFBLarge = new System.Windows.Forms.ImageList(this.components);
            this.pnlMiddleLeft = new System.Windows.Forms.Panel();
            this.btnAdvancedSel = new System.Windows.Forms.Button();
            this.btnInternalSel = new System.Windows.Forms.Button();
            this.btnHomeSel = new System.Windows.Forms.Button();
            this.btnExternalSel = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.prgTotalProgress = new System.Windows.Forms.ProgressBar();
            this.prgCurrentItem = new System.Windows.Forms.ProgressBar();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwFTPGetDirList = new System.ComponentModel.BackgroundWorker();
            this.tmrClearStatus = new System.Windows.Forms.Timer(this.components);
            this.btnUploadFolder = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.pnlMiddle.SuspendLayout();
            this.pnlMiddleRight.SuspendLayout();
            this.pnlMiddleLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.mnuMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMiddle.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMiddle.Controls.Add(this.pnlMiddleRight);
            this.pnlMiddle.Controls.Add(this.pnlMiddleLeft);
            this.pnlMiddle.Location = new System.Drawing.Point(12, 61);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(760, 456);
            this.pnlMiddle.TabIndex = 0;
            // 
            // pnlMiddleRight
            // 
            this.pnlMiddleRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMiddleRight.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMiddleRight.Controls.Add(this.lstFiles);
            this.pnlMiddleRight.Location = new System.Drawing.Point(119, 3);
            this.pnlMiddleRight.Name = "pnlMiddleRight";
            this.pnlMiddleRight.Size = new System.Drawing.Size(638, 450);
            this.pnlMiddleRight.TabIndex = 1;
            // 
            // lstFiles
            // 
            this.lstFiles.AllowDrop = true;
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.LargeImageList = this.ilFBLarge;
            this.lstFiles.Location = new System.Drawing.Point(3, 3);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(632, 444);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragDrop);
            this.lstFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragEnter);
            this.lstFiles.DoubleClick += new System.EventHandler(this.lstFiles_DoubleClick);
            this.lstFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstFiles_MouseUp);
            // 
            // ilFBLarge
            // 
            this.ilFBLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilFBLarge.ImageStream")));
            this.ilFBLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.ilFBLarge.Images.SetKeyName(0, "folder.png");
            this.ilFBLarge.Images.SetKeyName(1, "file.png");
            this.ilFBLarge.Images.SetKeyName(2, "opk.png");
            // 
            // pnlMiddleLeft
            // 
            this.pnlMiddleLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMiddleLeft.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMiddleLeft.Controls.Add(this.btnAdvancedSel);
            this.pnlMiddleLeft.Controls.Add(this.btnInternalSel);
            this.pnlMiddleLeft.Controls.Add(this.btnHomeSel);
            this.pnlMiddleLeft.Controls.Add(this.btnExternalSel);
            this.pnlMiddleLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlMiddleLeft.Name = "pnlMiddleLeft";
            this.pnlMiddleLeft.Size = new System.Drawing.Size(110, 450);
            this.pnlMiddleLeft.TabIndex = 0;
            // 
            // btnAdvancedSel
            // 
            this.btnAdvancedSel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvancedSel.Location = new System.Drawing.Point(3, 89);
            this.btnAdvancedSel.Name = "btnAdvancedSel";
            this.btnAdvancedSel.Size = new System.Drawing.Size(104, 23);
            this.btnAdvancedSel.TabIndex = 3;
            this.btnAdvancedSel.Text = "Advanced Mode";
            this.btnAdvancedSel.UseVisualStyleBackColor = true;
            this.btnAdvancedSel.Click += new System.EventHandler(this.btnAdvancedSel_Click);
            // 
            // btnInternalSel
            // 
            this.btnInternalSel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInternalSel.Location = new System.Drawing.Point(3, 2);
            this.btnInternalSel.Name = "btnInternalSel";
            this.btnInternalSel.Size = new System.Drawing.Size(104, 23);
            this.btnInternalSel.TabIndex = 0;
            this.btnInternalSel.Text = "Internal Apps";
            this.btnInternalSel.UseVisualStyleBackColor = true;
            this.btnInternalSel.Click += new System.EventHandler(this.btnInternalSel_Click);
            // 
            // btnHomeSel
            // 
            this.btnHomeSel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHomeSel.Location = new System.Drawing.Point(3, 60);
            this.btnHomeSel.Name = "btnHomeSel";
            this.btnHomeSel.Size = new System.Drawing.Size(104, 23);
            this.btnHomeSel.TabIndex = 2;
            this.btnHomeSel.Text = "$HOME";
            this.btnHomeSel.UseVisualStyleBackColor = true;
            this.btnHomeSel.Click += new System.EventHandler(this.btnHomeSel_Click);
            // 
            // btnExternalSel
            // 
            this.btnExternalSel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExternalSel.Location = new System.Drawing.Point(3, 31);
            this.btnExternalSel.Name = "btnExternalSel";
            this.btnExternalSel.Size = new System.Drawing.Size(104, 23);
            this.btnExternalSel.TabIndex = 1;
            this.btnExternalSel.Text = "External Apps";
            this.btnExternalSel.UseVisualStyleBackColor = true;
            this.btnExternalSel.Click += new System.EventHandler(this.btnExternalSel_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBottom.Controls.Add(this.txtStatus);
            this.pnlBottom.Controls.Add(this.prgTotalProgress);
            this.pnlBottom.Controls.Add(this.prgCurrentItem);
            this.pnlBottom.Location = new System.Drawing.Point(12, 523);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(760, 27);
            this.pnlBottom.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStatus.Location = new System.Drawing.Point(3, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(471, 13);
            this.txtStatus.TabIndex = 3;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // prgTotalProgress
            // 
            this.prgTotalProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prgTotalProgress.Location = new System.Drawing.Point(480, 13);
            this.prgTotalProgress.Name = "prgTotalProgress";
            this.prgTotalProgress.Size = new System.Drawing.Size(274, 11);
            this.prgTotalProgress.TabIndex = 1;
            // 
            // prgCurrentItem
            // 
            this.prgCurrentItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prgCurrentItem.Location = new System.Drawing.Point(480, 0);
            this.prgCurrentItem.Name = "prgCurrentItem";
            this.prgCurrentItem.Size = new System.Drawing.Size(274, 11);
            this.prgCurrentItem.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTop.Controls.Add(this.btnUploadFolder);
            this.pnlTop.Controls.Add(this.btnPaste);
            this.pnlTop.Controls.Add(this.btnCopy);
            this.pnlTop.Controls.Add(this.btnCut);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnDelete);
            this.pnlTop.Controls.Add(this.btnUploadFile);
            this.pnlTop.Controls.Add(this.btnDownload);
            this.pnlTop.Location = new System.Drawing.Point(12, 27);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(760, 28);
            this.pnlTop.TabIndex = 2;
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuTools,
            this.mnuHelp});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(784, 24);
            this.mnuMainMenu.TabIndex = 3;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDownload,
            this.mnuUpload,
            this.mnuDelete,
            this.mnuRefresh,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuDownload
            // 
            this.mnuDownload.Name = "mnuDownload";
            this.mnuDownload.Size = new System.Drawing.Size(137, 22);
            this.mnuDownload.Text = "Download...";
            // 
            // mnuUpload
            // 
            this.mnuUpload.Name = "mnuUpload";
            this.mnuUpload.Size = new System.Drawing.Size(137, 22);
            this.mnuUpload.Text = "Upload...";
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(137, 22);
            this.mnuDelete.Text = "Delete...";
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(137, 22);
            this.mnuRefresh.Text = "Refresh";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(137, 22);
            this.mnuExit.Text = "Exit";
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuCut
            // 
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Size = new System.Drawing.Size(102, 22);
            this.mnuCut.Text = "Cut";
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(102, 22);
            this.mnuCopy.Text = "Copy";
            // 
            // mnuPaste
            // 
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Size = new System.Drawing.Size(102, 22);
            this.mnuPaste.Text = "Paste";
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptions,
            this.mnuDebug});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(48, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuOptions
            // 
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(116, 22);
            this.mnuOptions.Text = "Options";
            // 
            // mnuDebug
            // 
            this.mnuDebug.Name = "mnuDebug";
            this.mnuDebug.Size = new System.Drawing.Size(116, 22);
            this.mnuDebug.Text = "Debug";
            this.mnuDebug.Click += new System.EventHandler(this.mnuDebug_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuAbout.Text = "About";
            // 
            // bgwFTPGetDirList
            // 
            this.bgwFTPGetDirList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFTPGetDirList_DoWork);
            this.bgwFTPGetDirList.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwFTPGetDirList_ProgressChanged);
            this.bgwFTPGetDirList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwFTPGetDirList_RunWorkerCompleted);
            // 
            // tmrClearStatus
            // 
            this.tmrClearStatus.Interval = 5000;
            this.tmrClearStatus.Tick += new System.EventHandler(this.tmrClearStatus_Tick);
            // 
            // btnUploadFolder
            // 
            this.btnUploadFolder.Image = global::ZTT.Properties.Resources.uploadfolder;
            this.btnUploadFolder.Location = new System.Drawing.Point(74, 0);
            this.btnUploadFolder.Name = "btnUploadFolder";
            this.btnUploadFolder.Size = new System.Drawing.Size(28, 28);
            this.btnUploadFolder.TabIndex = 7;
            this.btnUploadFolder.UseVisualStyleBackColor = true;
            this.btnUploadFolder.Click += new System.EventHandler(this.btnUploadFolder_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Image = global::ZTT.Properties.Resources.paste;
            this.btnPaste.Location = new System.Drawing.Point(176, 0);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(28, 28);
            this.btnPaste.TabIndex = 6;
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::ZTT.Properties.Resources.copy;
            this.btnCopy.Location = new System.Drawing.Point(142, 0);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(28, 28);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCut
            // 
            this.btnCut.Image = global::ZTT.Properties.Resources.cut;
            this.btnCut.Location = new System.Drawing.Point(108, 0);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(28, 28);
            this.btnCut.TabIndex = 4;
            this.btnCut.UseVisualStyleBackColor = true;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::ZTT.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(729, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 28);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::ZTT.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(210, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Image = global::ZTT.Properties.Resources.uploadfile;
            this.btnUploadFile.Location = new System.Drawing.Point(40, 0);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(28, 28);
            this.btnUploadFile.TabIndex = 1;
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFiles_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Image = global::ZTT.Properties.Resources.download;
            this.btnDownload.Location = new System.Drawing.Point(6, 0);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(28, 28);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.mnuMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zero Transfer Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddleRight.ResumeLayout(false);
            this.pnlMiddleLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ProgressBar prgCurrentItem;
        private System.Windows.Forms.ProgressBar prgTotalProgress;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.Panel pnlMiddleRight;
        private System.Windows.Forms.Panel pnlMiddleLeft;
        private System.Windows.Forms.Button btnAdvancedSel;
        private System.Windows.Forms.Button btnInternalSel;
        private System.Windows.Forms.Button btnHomeSel;
        private System.Windows.Forms.Button btnExternalSel;
        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.TextBox txtStatus;
        private System.ComponentModel.BackgroundWorker bgwFTPGetDirList;
        private System.Windows.Forms.ImageList ilFBLarge;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.Timer tmrClearStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuDownload;
        private System.Windows.Forms.ToolStripMenuItem mnuUpload;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuDebug;
        private System.Windows.Forms.Button btnUploadFolder;





    }
}

