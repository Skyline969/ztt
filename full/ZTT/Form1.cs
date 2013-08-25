using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZTT
{
    public partial class frmMain : Form
    {
        public bool ftpInProgress;
        int _accessMode;
        public int accessMode
        {
            get { return _accessMode; }
            set
            {
                _accessMode = value;
                if (_accessMode == MODE_ADVANCED)
                {
                    btnCut.Enabled = true;
                    btnCopy.Enabled = true;
                    btnPaste.Enabled = true;
                }
                else
                {
                    btnCut.Enabled = false;
                    btnCopy.Enabled = false;
                    btnPaste.Enabled = false;
                }
            }
        }
        public string ftpPath;
        public const string FTP_ADDR = "127.0.0.1";
        public const string FTP_INTERNAL_APPS_PATH = "/data/apps/";
        public const string FTP_EXTERNAL_APPS_PATH = "/sdcard/apps/";
        public const string FTP_HOME_PATH = "/data/local/home/";
        public const string FTP_ROOT = "/";
        public const int MODE_NONE = 1;
        public const int MODE_EZ_INTERNAL = 1;
        public const int MODE_EZ_EXTERNAL = 2;
        public const int MODE_EZ_HOME = 3;
        public const int MODE_ADVANCED = 4;

        public DebugWindow debug;
        public MouseButtons lastButtonUp;

        public frmMain()
        {
            InitializeComponent();
            debug = new DebugWindow();
            lastButtonUp = MouseButtons.None;
            debugWindow("Program initialized.");
        }

        delegate void DebugWindowDelegate(string value);

        private void debugWindow(string debugText)
        {
            if (InvokeRequired)
            {
                Invoke(new DebugWindowDelegate(debugWindow), debugText);
            }
            else
            {
                debug.addDebug(debugText);
            }
        }

        #region Event Handlers

        private void frmMain_Load(object sender, EventArgs e)
        {
            ftpInProgress = false;
            accessMode = MODE_NONE;

            //Generate tooltips
            ToolTip ttActionButtons = new ToolTip();
            ttActionButtons.AutoPopDelay = 5000;
            ttActionButtons.InitialDelay = 750;
            ttActionButtons.ReshowDelay = 100;

            ttActionButtons.SetToolTip(btnDownload, "Download");
            ttActionButtons.SetToolTip(btnUploadFile, "Upload Files");
            ttActionButtons.SetToolTip(btnUploadFolder, "Upload a Folder");
            ttActionButtons.SetToolTip(btnCut, "Cut");
            ttActionButtons.SetToolTip(btnCopy, "Copy");
            ttActionButtons.SetToolTip(btnPaste, "Paste");
            ttActionButtons.SetToolTip(btnDelete, "Delete");
            ttActionButtons.SetToolTip(btnRefresh, "Refresh");
        }

        private void btnInternalSel_Click(object sender, EventArgs e)
        {
            if (checkConnectivity())
            {
                debugWindow("Internal apps selected, connectivity found.");
                accessMode = MODE_EZ_INTERNAL;
                FTPParams internalAppsParams = new FTPParams
                {
                    address = FTP_ADDR,
                    root = FTP_INTERNAL_APPS_PATH,
                    file = "/",
                    navOut = false
                };

                setStatus("Getting internal apps listing, please wait.");
                bgwFTPGetDirList.RunWorkerAsync(internalAppsParams);
            }
            else
            {
                debugWindow("Internal apps selected, but no connectivity.");
                setStatus("Failed to connect to Zero. Double-check connection and try again.");
            }
        }

        private void btnExternalSel_Click(object sender, EventArgs e)
        {
            if (checkConnectivity())
            {
                debugWindow("External apps selected, connectivity found.");
                accessMode = MODE_EZ_EXTERNAL;
                FTPParams externalAppsParams = new FTPParams
                {
                    address = FTP_ADDR,
                    root = FTP_EXTERNAL_APPS_PATH,
                    file = "/",
                    navOut = false
                };

                setStatus("Getting external apps listing, please wait.");
                bgwFTPGetDirList.RunWorkerAsync(externalAppsParams);
            }
            else
            {
                debugWindow("External apps selected, but no connectivity.");
                setStatus("Failed to connect to Zero. Double-check connection and try again.");
            }
        }

        private void btnHomeSel_Click(object sender, EventArgs e)
        {
            if (checkConnectivity())
            {
                debugWindow("$HOME selected, connectivity found.");
                accessMode = MODE_EZ_HOME;
                FTPParams homeParams = new FTPParams
                {
                    address = FTP_ADDR,
                    root = FTP_HOME_PATH,
                    file = "",
                    navOut = false
                };

                setStatus("Getting home directory listing, please wait.");
                bgwFTPGetDirList.RunWorkerAsync(homeParams);
            }
            else
            {
                debugWindow("$HOME selected, but no connectivity.");
                setStatus("Failed to connect to Zero. Double-check connection and try again.");
            }
        }

        private void btnAdvancedSel_Click(object sender, EventArgs e)
        {
            if (checkConnectivity())
            {
                debugWindow("Advanced mode selected, connectivity found.");
                accessMode = MODE_ADVANCED;
                FTPParams advParams = new FTPParams
                {
                    address = FTP_ADDR,
                    root = FTP_ROOT,
                    file = "",
                    navOut = true
                };

                setStatus("Getting root directory listing, please wait.");
                bgwFTPGetDirList.RunWorkerAsync(advParams);
            }
            else
            {
                debugWindow("Advanced mode selected, but no connectivity.");
                setStatus("Failed to connect to Zero. Double-check connection and try again.");
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            downloadFiles();
        }

        private void btnUploadFiles_Click(object sender, EventArgs e)
        {
            uploadFiles();
        }

        private void btnUploadFolder_Click(object sender, EventArgs e)
        {
            uploadFolder();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            debugWindow("Cut button clicked.");
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            debugWindow("Copy button clicked.");
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            debugWindow("Paste button clicked.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            debugWindow("Delete button clicked.");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshFileList();
        }

        private void mnuDebug_Click(object sender, EventArgs e)
        {
            debug.Show();
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            debugWindow("txtStatus text was changed.");
            Size size = TextRenderer.MeasureText(txtStatus.Text, txtStatus.Font);
            while (size.Width > txtStatus.Width)
            {
                txtStatus.Text = txtStatus.Text.Substring(0, txtStatus.Text.Length - 4) + "...";
                size = TextRenderer.MeasureText(txtStatus.Text, txtStatus.Font);
            }
        }

        private void lstFiles_DragEnter(object sender, DragEventArgs e)
        {
            debugWindow("lstFiles was entered with drag/drop.");
            e.Effect = DragDropEffects.All;
        }

        private void lstFiles_DragDrop(object sender, DragEventArgs e)
        {
            debugWindow("lstFiles has had something dropped onto it.");
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            try
            {
                foreach (String file in files)
                {
                    debugWindow("Item dropped onto lstFiles: " + file);
                }
            }
            catch (NullReferenceException)
            {
                debugWindow("Unacceptable content dropped to lstFiles");
                setStatus("Only files and folders are droppable.");
            }
        }

        private void lstFiles_MouseUp(object sender, MouseEventArgs e)
        {
            lastButtonUp = e.Button;
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItems.Count == 1 && lastButtonUp == MouseButtons.Left)
            {
                debugWindow("Double-click event on lstFiles, exactly 1 item was selected.");
                if (isFTPDir(ftpPath + lstFiles.SelectedItems[0].Text))
                {
                    debugWindow("Item double-clicked in lstFiles was a folder.");
                    if (checkConnectivity())
                    {
                        debugWindow("Changing dir to double-clicked item in lstFiles.");
                        FTPParams cdParams = new FTPParams
                        {
                            address = FTP_ADDR,
                            root = ftpPath + lstFiles.SelectedItems[0].Text + "/",
                            file = "",
                            navOut = true
                        };

                        setStatus("Getting directory listing, please wait.");
                        bgwFTPGetDirList.RunWorkerAsync(cdParams);
                    }
                    else
                    {
                        debugWindow("Cannot change dir to double-clicked item in lstFiles - no connectivity.");
                        setStatus("Failed to connect to Zero. Double-check connection and try again.");
                    }
                }
                else
                {
                    debugWindow("Item double-clicked in lstFiles was not a folder.");
                }
            }
            else
            {
                debugWindow("Double-click event on lstFiles, but not exactly 1 item was selected.");
            }
        }

        private void bgwFTPGetDirList_DoWork(object sender, DoWorkEventArgs e)
        {
            while (ftpInProgress)
            {
                debugWindow("FTP in progress, waiting.");
                Thread.Sleep(1000);
            }

            if (checkConnectivity())
            {
                debugWindow("Calling getDirList.\nSetting ftpInProgress to true.");
                ftpInProgress = true;
                FTPParams parameters = e.Argument as FTPParams;
                e.Result = getDirList(parameters);
            }
            else
            {
                debugWindow("Attempted background getDirList, but no connectivity.");
                setStatus("Failed to connect to Zero. Double-check connection and try again.");
            }
        }

        private void bgwFTPGetDirList_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            debugWindow("Background getDirList progress changed. New value: " + e.ProgressPercentage);
            prgTotalProgress.Value = e.ProgressPercentage;
        }

        private void bgwFTPGetDirList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            debugWindow("getDirList completed. Setting ftpInProgress to false.");
            ftpInProgress = false;
            txtStatus.Text = "";
            List<string> files = e.Result as List<string>;
            try
            {
                if (files.Count == 0 || (files.Count == 1 && files.ElementAt(0) == ".."))
                {
                    debugWindow("Empty folder.");
                    setStatus("Empty folder.");
                }

                debugWindow("Clearing lstFiles.");
                lstFiles.Items.Clear();
                foreach (string file in files)
                {
                    debugWindow("Adding new item into lstFiles:");
                    ListViewItem item = new ListViewItem(file);
                    if (Path.GetExtension(file) == ".opk")
                    {
                        debugWindow("\tOPK");
                        item.ImageIndex = 2;
                    }
                    else if (isFTPDir(ftpPath + file))
                    {
                        debugWindow("\tDirectory");
                        item.ImageIndex = 0;
                    }
                    else
                    {
                        debugWindow("\tFile");
                        item.ImageIndex = 1;
                    }
                    debugWindow("\tAdding item.");
                    lstFiles.Items.Add(item);
                }
                lstFiles.Focus();
                string tmpPath = ftpPath;
                if (tmpPath.EndsWith("/"))
                {
                    debugWindow("tmpPath ends with /, stripping.");
                    tmpPath = tmpPath.Substring(0, tmpPath.Length - 1);
                }
                string lastFolder = tmpPath.Substring(tmpPath.LastIndexOf('/') + 1);
                if (lastFolder == "..")
                {
                    debugWindow("Last folder is .., correcting ftpPath.");
                    tmpPath = tmpPath.Substring(0, tmpPath.LastIndexOf('/'));
                    ftpPath = tmpPath.Substring(0, tmpPath.LastIndexOf('/') + 1);
                }
            }
            catch (NullReferenceException)
            {
                debugWindow("Caught NullReferenceException on background getDirList completion.");
                //Do nothing, user will have already been alerted of failure
            }
        }

        private void tmrClearStatus_Tick(object sender, EventArgs e)
        {
            txtStatus.Clear();
            tmrClearStatus.Stop();
        }

        private void refreshFileList()
        {
            if (checkConnectivity() && ftpPath != null && ftpPath != "")
            {
                debugWindow("Refresh button clicked, and criteria met.");
                lstFiles.Clear();
                FTPParams refParams = new FTPParams
                {
                    address = FTP_ADDR,
                    root = ftpPath,
                    file = "",
                    navOut = true
                };

                setStatus("Refreshing directory listing, please wait.");
                bgwFTPGetDirList.RunWorkerAsync(refParams);
            }
            else
            {
                if (!checkConnectivity())
                {
                    debugWindow("Refresh button clicked, but no connectivity.");
                    setStatus("Failed to connect to Zero. Double-check connection and try again.");
                }
                if (ftpPath == null || ftpPath == "")
                {
                    debugWindow("Refresh button clicked, but ftpPath not set.");
                    setStatus("Failed to refresh the listing. Please manually re-navigate to the directory.");
                }
            }
        }

        #endregion

        #region Helper Functions

        delegate void SetStatusDelegate(string value);

        public void setStatus(string status)
        {
            if (InvokeRequired)
            {
                debugWindow("Invoking SetStatusDelegate to set txtStatus' value.");
                Invoke(new SetStatusDelegate(setStatus), status);
            }
            else
            {
                debugWindow("Setting txtStatus' value to " + status + ".");
                txtStatus.Text = status;
                txtStatus.Refresh();
            }

            tmrClearStatus.Start();
        }

        private bool checkConnectivity()
        {
            Ping ping = new Ping();
            try
            {
                PingReply pingReply = ping.Send(FTP_ADDR, 50);
                return pingReply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                debugWindow("Ping encountered an exception.");
                return false;
            }
        }

        #endregion

        #region FTP Dir Functions

        public bool isFTPDir(string path)
        {
            debugWindow("isFTPDir called for " + path);
            bool IsExists = false;
            try
            {
                string parent = path.Substring(0, path.LastIndexOf('/'));
                string dir = path.Substring(path.LastIndexOf('/') + 1);
                if (dir == "..")
                {
                    debugWindow("\tDir is .., returning true.");
                    return true;
                }
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + FTP_ADDR + parent));
                request.Credentials = new NetworkCredential("anonymous", "");
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string line = reader.ReadLine();
                List<String> files = new List<string>();
                while (line != null)
                {
                    files.Add(line);
                    line = reader.ReadLine();
                }
                foreach (string file in files)
                {
                    if (file.Contains(dir) && file[0] == 'd')
                    {
                        debugWindow("\t\tDirectory found.");
                        IsExists = true;
                    }
                }
                reader.Close();
                response.Close();
            }
            catch (WebException)
            {
                debugWindow("\tException encountered.");
                IsExists = false;
            }
            debugWindow("Returning " + IsExists);
            return IsExists;
        }

        private bool ftpFileExists(string file)
        {
            debugWindow("ftpFileExists called.");
            try
            {
                FtpWebRequest reqExists = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + file));
                reqExists.Credentials = new NetworkCredential("anonymous", "");
                reqExists.Method = WebRequestMethods.Ftp.GetFileSize;
                reqExists.UseBinary = true;

                FtpWebResponse response = (FtpWebResponse)reqExists.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                else
                {
                    debugWindow(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                    MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                    return false;
                }
            }
        }

        public long getFileSize(FTPParams parameters)
        {
            debugWindow("getFileSize called.");
            FtpWebRequest reqSize = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + parameters.address + parameters.file));
            reqSize.Credentials = new NetworkCredential("anonymous", "");
            reqSize.Method = WebRequestMethods.Ftp.GetFileSize;
            reqSize.UseBinary = true;

            FtpWebResponse response = (FtpWebResponse)reqSize.GetResponse();

            long size = response.ContentLength;

            response.Close();

            debugWindow("\tReturning " + size);
            return size;
        }

        public List<string> getDirList(FTPParams parameters, bool recursive = false)
        {
            debugWindow("getDirList called");
            StringBuilder result = new StringBuilder();
            FtpWebRequest ftp;

            if (recursive)
            {
                debugWindow("\tRecursive.");
                List<String> items = new List<string>();

                try
                {
                    debugWindow("\tChecking " + "ftp://" + parameters.address + parameters.root);
                    ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + parameters.address + parameters.root));
                    ftp.UseBinary = true;
                    ftp.Credentials = new NetworkCredential("anonymous", "");
                    ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                    WebResponse resp = ftp.GetResponse();
                    StreamReader reader = new StreamReader(resp.GetResponseStream());

                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        items.Add(parameters.root + line);
                        if (isFTPDir(parameters.root + line))
                        {
                            debugWindow("\tRecursing into " + parameters.root + line + "/");
                            string tmpRoot = parameters.root;
                            parameters.root = parameters.root + line + "/";

                            items.AddRange(getDirList(parameters, true));

                            parameters.root = tmpRoot;
                        }
                        debugWindow("\tAdding " + line);
                        line = reader.ReadLine();
                    }
                    reader.Close();
                    resp.Close();
                }
                // Getting a WebException likely means that the directory was empty
                catch (WebException)
                {
                    debugWindow("\tWebException encountered.");
                }
                catch (Exception ex)
                {
                    debugWindow(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                    MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                    return null;
                }
                return items;
            }
            else
            {
                debugWindow("\tNot recursive.");
                List<String> files = new List<string>();
                List<String> folders = new List<string>();

                try
                {
                    debugWindow("\tChecking " + "ftp://" + parameters.address + parameters.root);
                    ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + parameters.address + parameters.root));
                    ftp.UseBinary = true;
                    ftp.Credentials = new NetworkCredential("anonymous", "");
                    ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                    WebResponse resp = ftp.GetResponse();
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    ftpPath = parameters.root;

                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        if (isFTPDir(parameters.root + line))
                        {
                            debugWindow("\tAdding folder " + line);
                            folders.Add(line);
                        }
                        else
                        {
                            debugWindow("\tAdding file " + line);
                            files.Add(line);
                        }
                        line = reader.ReadLine();
                    }
                    reader.Close();
                    resp.Close();
                    files.Sort();
                    folders.Sort();

                    string path = resp.ResponseUri.PathAndQuery;
                    switch (accessMode)
                    {
                        case MODE_EZ_INTERNAL:
                            if (path != FTP_INTERNAL_APPS_PATH && parameters.navOut)
                            {
                                debugWindow("\tEZ_INTERNAL selected and navOut true - Adding the .. folder.");
                                folders.Insert(0, "..");
                            }
                            break;
                        case MODE_EZ_EXTERNAL:
                            if (path != FTP_EXTERNAL_APPS_PATH && parameters.navOut)
                            {
                                debugWindow("\tEZ_EXTERNAL selected and navOut true - Adding the .. folder.");
                                folders.Insert(0, "..");
                            }
                            break;
                        case MODE_EZ_HOME:
                            if (path != FTP_HOME_PATH && parameters.navOut)
                            {
                                debugWindow("\t$HOME selected and navOut true - Adding the .. folder.");
                                folders.Insert(0, "..");
                            }
                            break;
                        case MODE_ADVANCED:
                            if (path != FTP_ROOT && parameters.navOut)
                            {
                                debugWindow("\tRoot selected and navOut true - Adding the .. folder.");
                                folders.Insert(0, "..");
                            }
                            break;
                    }
                }
                // Getting a WebException likely means that the directory was empty
                catch (WebException)
                {
                    debugWindow("\tWebException encountered.");
                    if (parameters.navOut)
                    {
                        debugWindow("\tAdding .. folder.");
                        folders.Add("..");
                    }
                }
                catch (Exception ex)
                {
                    debugWindow(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                    MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                    return null;
                }
                debugWindow("\tAdding files and returning folders.");
                folders.AddRange(files);
                return folders;
            }
        }

        private void downloadFile(FTPParams parameters, string location)
        {
            debugWindow("downloadFile called. Saving " + parameters.file + " to " + location);
            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + parameters.address + parameters.file));
            ftp.Method = WebRequestMethods.Ftp.DownloadFile;
            ftp.Credentials = new NetworkCredential("anonymous", "");
            FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
            Stream responseStream = response.GetResponseStream();
            FileStream fileStream = new FileStream(location, FileMode.Create);

            int bytesRead = 0;
            byte[] buffer = new byte[2048];

            prgCurrentItem.Minimum = 0;
            prgCurrentItem.Maximum = Convert.ToInt32(getFileSize(parameters));
            prgCurrentItem.Value = 0;
            prgCurrentItem.Step = buffer.Length;

            while (true)
            {
                debugWindow("\tReading bytes and writing to file.");
                bytesRead = responseStream.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    break;
                }

                fileStream.Write(buffer, 0, bytesRead);
                prgCurrentItem.PerformStep();
                prgCurrentItem.Refresh();
            }

            fileStream.Close();
            responseStream.Close();
            response.Close();
        }

        private void uploadFile(string location, FTPParams parameters)
        {
            debugWindow("uploadFile called. Saving " + parameters.file + " to ftp://" + parameters.address + location + Path.GetFileName(parameters.file));
            
            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + parameters.address + location + Path.GetFileName(parameters.file)));
            ftp.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            ftp.Credentials = new NetworkCredential("anonymous", "");

            // Copy the contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader(parameters.file);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            ftp.ContentLength = fileContents.Length;

            Stream requestStream = ftp.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();

            response.Close();
        }

        private void downloadFiles()
        {
            debugWindow("downloadFiles called.");
            if (ftpPath != null && ftpPath != "" && lstFiles.SelectedItems.Count > 0)
            {
                debugWindow("\tCriteria met.");
                bool upLevelSelected = false;
                foreach (ListViewItem item in lstFiles.SelectedItems)
                {
                    if (item.Text == "..")
                    {
                        debugWindow("\t.. folder is selected.");
                        upLevelSelected = true;
                        break;
                    }
                }

                if (!upLevelSelected)
                {
                    debugWindow("\t.. folder not selected.");
                    if (checkConnectivity())
                    {
                        debugWindow("\tConnection established. Prompting where to save files.");
                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                        fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                        fbd.Description = "Choose where to save the downloaded items.";
                        DialogResult result = fbd.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            setStatus("Preparing to download, please wait....");

                            debugWindow("\tWill save to " + fbd.SelectedPath);
                            List<string> selectedItems = new List<string>();
                            foreach (ListViewItem item in lstFiles.SelectedItems)
                            {
                                debugWindow("\tAdded " + ftpPath + item.Text + " to selectedItems.");
                                selectedItems.Add(ftpPath + item.Text);
                            }

                            foreach (string item in selectedItems.ToList<string>())
                            {
                                debugWindow("\tProcessing " + item);
                                if (isFTPDir(item))
                                {
                                    debugWindow("\t\tIs a directory.");
                                    FTPParams recParams = new FTPParams
                                    {
                                        address = FTP_ADDR,
                                        root = item + "/",
                                        file = "",
                                        navOut = false
                                    };
                                    ftpInProgress = true;
                                    List<string> subitems = getDirList(recParams, true);
                                    ftpInProgress = false;
                                    foreach (string subitem in subitems)
                                    {
                                        debugWindow("\t\tAdding " + subitem);
                                        selectedItems.Add(subitem);
                                    }
                                }
                            }

                            foreach (string item in selectedItems)
                            {
                                string tmpLine = item.Substring(ftpPath.Length).Replace('/', '\\');
                                debugWindow("\tWill write " + item + " to " + fbd.SelectedPath + "\\" + tmpLine);
                            }

                            debugWindow("\tSetting overwriteAll and skipAll to false.");
                            bool overwriteAll = false;
                            bool skipAll = false;

                            try
                            {
                                prgTotalProgress.Minimum = 0;
                                prgTotalProgress.Maximum = selectedItems.Count;
                                prgTotalProgress.Value = 0;
                                prgTotalProgress.Step = 1;
                                int overwrite = -1;

                                foreach (string item in selectedItems)
                                {
                                    debugWindow("\tProcessing " + item);
                                    prgTotalProgress.PerformStep();
                                    prgTotalProgress.Refresh();
                                    string tmpLine = item.Substring(ftpPath.Length).Replace('/', '\\');

                                    if (overwrite == OverwriteDialogResponse.Cancel)
                                    {
                                        debugWindow("\t\toverwrite is set to Cancel, breaking out of foreach loop.");
                                        prgTotalProgress.Value = prgTotalProgress.Maximum;
                                        prgTotalProgress.Refresh();
                                        prgCurrentItem.Value = prgCurrentItem.Maximum;
                                        prgCurrentItem.Refresh();
                                        break; // Handled outside of the following switch statement to break out of the foreach
                                    }

                                    if (isFTPDir(item))
                                    {
                                        debugWindow("\t\tIs a directory.");
                                        if (!Directory.Exists(fbd.SelectedPath + "\\" + tmpLine))
                                        {
                                            debugWindow("\t\tDirectory does not exist. Creating it.");
                                            txtStatus.Text = "Creating directory " + fbd.SelectedPath + "\\" + tmpLine;
                                            txtStatus.Refresh();
                                            Directory.CreateDirectory(fbd.SelectedPath + "\\" + tmpLine);
                                        }
                                        else
                                        {
                                            debugWindow("\t\tDirectory exists.");
                                        }
                                    }
                                    else
                                    {
                                        txtStatus.Text = "Downloading " + item;
                                        txtStatus.Refresh();

                                        debugWindow("\tDownload " + item + " to " + fbd.SelectedPath + "\\" + tmpLine);

                                        if (File.Exists(fbd.SelectedPath + "\\" + tmpLine) && !skipAll)
                                        {
                                            debugWindow("\t\tFile exists and skipAll is false.");
                                            if (overwriteAll)
                                            {
                                                debugWindow("\t\toverwriteAll selected. Proceeding to download file.");
                                                FTPParams dwnParams = new FTPParams
                                                {
                                                    address = FTP_ADDR,
                                                    root = "",
                                                    file = item,
                                                    navOut = false
                                                };
                                                ftpInProgress = true;
                                                try
                                                {
                                                    downloadFile(dwnParams, fbd.SelectedPath + "\\" + tmpLine);
                                                }
                                                catch (Exception ex)
                                                {
                                                    debugWindow(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                                    MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                                }
                                                
                                                ftpInProgress = false;
                                            }
                                            else
                                            {
                                                debugWindow("\t\tAsking user what to do with file.");
                                                OverwriteDialog od = new OverwriteDialog("The file " + fbd.SelectedPath + "\\" + tmpLine + " already exists." +
                                                    Environment.NewLine + Environment.NewLine + "Overwrite?");
                                                od.ShowDialog();
                                                overwrite = od.Result;

                                                debugWindow("\t\tGot result " + overwrite);
                                                switch (overwrite)
                                                {
                                                    case OverwriteDialogResponse.SkipAll:
                                                        debugWindow("\t\t\tSkipAll selected. Setting skipAll to true.");
                                                        skipAll = true;
                                                        continue;
                                                    case OverwriteDialogResponse.Skip:
                                                        debugWindow("\t\t\tSkip selected.");
                                                        continue;
                                                    case OverwriteDialogResponse.Cancel:
                                                        debugWindow("\t\t\tCancel selected.");
                                                        debugWindow("\t\t\tCalling break.");
                                                        break; // Handled elsewhere in the code
                                                    case OverwriteDialogResponse.OverwriteAll:
                                                        debugWindow("\t\t\tOverwriteAll selected. Setting overwriteAll to true.");
                                                        overwriteAll = true;
                                                        continue;
                                                    case OverwriteDialogResponse.Overwrite:
                                                        debugWindow("\t\t\tOverwriting.");
                                                        FTPParams dwnParams = new FTPParams
                                                        {
                                                            address = FTP_ADDR,
                                                            root = "",
                                                            file = item,
                                                            navOut = false
                                                        };
                                                        ftpInProgress = true;
                                                        try
                                                        {
                                                            downloadFile(dwnParams, fbd.SelectedPath + "\\" + tmpLine);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            debugWindow(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                                            MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                                        }
                                                        ftpInProgress = false;
                                                        debugWindow("\t\t\tCalling break.");
                                                        break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            debugWindow("\t\tFile does not exist. Downloading.");
                                            FTPParams dwnParams = new FTPParams
                                            {
                                                address = FTP_ADDR,
                                                root = "",
                                                file = item,
                                                navOut = false
                                            };
                                            ftpInProgress = true;
                                            try
                                            {
                                                downloadFile(dwnParams, fbd.SelectedPath + "\\" + tmpLine);
                                            }
                                            catch (Exception ex)
                                            {
                                                debugWindow(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                                MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                            }
                                            ftpInProgress = false;
                                        }
                                    }
                                }
                                debugWindow("\tFinished download.");
                                setStatus("Download complete.");
                            }
                            catch (Exception ex)
                            {
                                debugWindow(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                prgTotalProgress.Value = 0;
                                prgTotalProgress.Refresh();
                                prgCurrentItem.Value = 0;
                                prgCurrentItem.Refresh();
                            }
                        }
                    }
                    else
                    {
                        debugWindow("\tNo connection.");
                        setStatus("Failed to connect to Zero. Double-check connection and try again.");
                    }
                }
            }
        }

        //NOTE: STILL BROKEN, SKIP/OVERWRITE ALL NOT WORKING!
        private void uploadFiles()
        {
            if (checkConnectivity() && ftpPath != null && ftpPath != "")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Choose files to upload";
                ofd.Filter = "All files|*.*";
                ofd.Multiselect = true;
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    prgTotalProgress.Minimum = 0;
                    prgTotalProgress.Maximum = ofd.FileNames.Count();
                    prgTotalProgress.Value = 0;
                    prgTotalProgress.Step = 1;
                    int overwrite = -1;
                    bool overwriteAll = false;
                    bool skipAll = false;

                    foreach (string file in ofd.FileNames)
                    {
                        if (overwrite == OverwriteDialogResponse.Cancel)
                        {
                            debugWindow("\t\toverwrite is set to Cancel, breaking out of foreach loop.");
                            prgTotalProgress.Value = prgTotalProgress.Maximum;
                            prgTotalProgress.Refresh();
                            prgCurrentItem.Value = prgCurrentItem.Maximum;
                            prgCurrentItem.Refresh();
                            break; // Handled outside of the following switch statement to break out of the foreach
                        }

                        if (!Directory.Exists(file))
                        {
                            FTPParams uplParams = new FTPParams
                            {
                                address = FTP_ADDR,
                                root = ftpPath,
                                file = file,
                                navOut = true
                            };

                            if (ftpFileExists(FTP_ADDR + ftpPath + Path.GetFileName(file)) && !skipAll)
                            {
                                debugWindow("\t\tFile exists and skipAll is false.");
                                if (overwriteAll)
                                {
                                    debugWindow("\t\toverwriteAll selected. Proceeding to download file.");

                                    ftpInProgress = true;
                                    try
                                    {
                                        uploadFile(ftpPath, uplParams);
                                    }
                                    catch (Exception ex)
                                    {
                                        debugWindow(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                        MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                    }
                                    ftpInProgress = false;
                                }
                                else
                                {
                                    debugWindow("\t\tAsking user what to do with file.");
                                    OverwriteDialog od = new OverwriteDialog("The file " + uplParams.root + Path.GetFileName(uplParams.file) + " already exists." +
                                        Environment.NewLine + Environment.NewLine + "Overwrite?");
                                    od.ShowDialog();
                                    overwrite = od.Result;

                                    debugWindow("\t\tGot result " + overwrite);
                                    switch (overwrite)
                                    {
                                        case OverwriteDialogResponse.SkipAll:
                                            debugWindow("\t\t\tSkipAll selected. Setting skipAll to true.");
                                            skipAll = true;
                                            continue;
                                        case OverwriteDialogResponse.Skip:
                                            debugWindow("\t\t\tSkip selected.");
                                            continue;
                                        case OverwriteDialogResponse.Cancel:
                                            debugWindow("\t\t\tCancel selected.");
                                            debugWindow("\t\t\tCalling break.");
                                            break; // Handled elsewhere in the code
                                        case OverwriteDialogResponse.OverwriteAll:
                                            debugWindow("\t\t\tOverwriteAll selected. Setting overwriteAll to true.");
                                            overwriteAll = true;
                                            continue;
                                        case OverwriteDialogResponse.Overwrite:
                                            debugWindow("\t\t\tOverwriting.");
                                            ftpInProgress = true;
                                            try
                                            {
                                                uploadFile(ftpPath, uplParams);
                                            }
                                            catch (Exception ex)
                                            {
                                                debugWindow(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                                MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                                            }
                                            ftpInProgress = false;
                                            debugWindow("\t\t\tCalling break.");
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                setStatus("Uploading " + file);
                                uploadFile(ftpPath, uplParams);
                            }
                        }
                        prgTotalProgress.PerformStep();
                        prgTotalProgress.Refresh();
                    }
                    setStatus("Upload complete.");
                    refreshFileList();
                }
                ofd.Dispose();
            }
        }

        private void uploadFolder()
        {
            if (checkConnectivity() && ftpPath != null && ftpPath != "")
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowNewFolderButton = false;
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    MessageBox.Show(fbd.SelectedPath);
                }
            }
        }

        #endregion
    }

    public class FTPParams
    {
        public string address { get; set; }
        public string root { get; set; }
        public string file { get; set; }
        public bool navOut { get; set; }
    }
}
