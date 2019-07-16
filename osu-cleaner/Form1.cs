/**
* osu-cleaner
* Version: 1.00
* Author: henntix
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
namespace osu_cleaner
{
    public partial class MainApp : Form
    {
        private List<string> skinElements = new List<string>();
        private List<string> hitSounds = new List<string>();
        BackgroundWorker worker;
        private long filesSize = 0;
        private long forRemovalSize = 0;
        private List<string> foundElements = new List<string>();

        public MainApp()
        {
            InitializeComponent();
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            directoryPath.Text = getOsuPath();
            setSkinList();
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(findElements);
            worker.ProgressChanged += new ProgressChangedEventHandler(progressBar);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(findComplete);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
        }

        private void directorySelectButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = false;
            folder.RootFolder = Environment.SpecialFolder.MyComputer;
            folder.Description = "Select an osu! root directory:";
            folder.SelectedPath = directoryPath.Text;
            DialogResult path = folder.ShowDialog();
            if (path == DialogResult.OK)
            {
                //check if osu!.exe is present
                if (!File.Exists(folder.SelectedPath + "\\osu!.exe"))
                {
                    MessageBox.Show("Not a valid osu! directory!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    directorySelectButton_Click(sender, e);
                    return;
                }
            }
            directoryPath.Text = folder.SelectedPath + "\\";
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            FindProgressBar.Visible = true;
            cancelButton.Visible = true;
            elementList.Items.Clear();
            filesSize = 0;
            filesSizeLabel.Text = "Found: " + Math.Round((double)(filesSize) / 1048576, 4) + " MB";
            forRemovalSize = 0;
            forRemovalSizeLabel.Text = "Selected for removal: " + Math.Round((double)(forRemovalSize) / 1048576, 4) + " MB";
            worker.RunWorkerAsync();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
                worker.CancelAsync();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            List<string> delete = new List<string>();
            foreach (string file in elementList.CheckedItems)//adding items to temporary collection to let me delete items from on-screen list
                delete.Add(file);
            if (moveCheckBox.Checked) Directory.CreateDirectory(directoryPath.Text + "Cleaned");

            foreach (string file in delete)
            {
                try
                {
                    filesSize -= getFileSize(file);
                    if (DeletePermanentlyCheckbox.Checked) FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
                    else if (moveCheckBox.Checked)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        string relativePath = fileInfo.Directory.FullName.Replace(directoryPath.Text + "Songs", directoryPath.Text + "Cleaned\\");
                        if (!Directory.Exists(relativePath))
                            Directory.CreateDirectory(relativePath);
                        File.Move(file, relativePath + "\\" + fileInfo.Name);
                    }
                    else FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
                catch (FileNotFoundException) { }
                catch (NotSupportedException) { }

                elementList.Items.Remove(file);
                filesSizeLabel.Text = "Found: " + Math.Round((double)(filesSize) / 1048576, 4) + " MB";
            }
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < elementList.Items.Count; i++)
                elementList.SetItemChecked(i, true);
            forRemovalSize = 0;
            foreach (string file in elementList.CheckedItems)
            {
                FileInfo sizeInfo = new FileInfo(file);
                forRemovalSize += sizeInfo.Length;
            }
            forRemovalSizeLabel.Text = "Selected for removal: " + Math.Round((double)(forRemovalSize) / 1048576, 4) + " MB";
        }

        private void deselectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < elementList.Items.Count; i++)
                elementList.SetItemChecked(i, false);
            forRemovalSize = 0;
            forRemovalSizeLabel.Text = "Selected for removal: " + Math.Round((double)(forRemovalSize) / 1048576, 4) + " MB";
        }

        private void elementList_SelectedIndexChanged(object sender, EventArgs e)
        {
            forRemovalSize = 0;
            foreach (string file in elementList.CheckedItems)
            {
                FileInfo sizeInfo = new FileInfo(file);
                forRemovalSize += sizeInfo.Length;
            }
            forRemovalSizeLabel.Text = "Selected for removal: " + Math.Round((double)(forRemovalSize) / 1048576, 4) + " MB";
        }

        private void DeletePermanentlyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(DeletePermanentlyCheckbox.Checked) moveCheckBox.Checked = false;
        }

        private void moveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(moveCheckBox.Checked) DeletePermanentlyCheckbox.Checked = false;
            if (moveCheckBox.Checked) deleteButton.Text = "Move";
            else deleteButton.Text = "Delete";
        }

        private bool RegexMatch(string str, string regex)
        {
            Regex r = new Regex(regex);
            return r.IsMatch(str);
        }

        private void findElements(object sender, DoWorkEventArgs e)
        {
            int folderCount = Directory.GetDirectories(directoryPath.Text + "Songs").Length;
            Console.WriteLine(folderCount);
            int current = 0;
            foreach (string d in Directory.GetDirectories(directoryPath.Text + "Songs"))
            {
                if (sbDeleteCheckbox.Checked)
                {
                    //whitelisting BG from deletion (often BG files are used in SB)
                    List<string> whitelist = new List<string>();
                    foreach (string file in Directory.GetFiles(d))
                        if (Regex.IsMatch(file, "osu$"))
                        {
                            string bg = getBGPath(file);
                            if (bg != null && !whitelist.Contains(bg))
                                whitelist.Add(bg);
                        }

                    foreach (string file in Directory.GetFiles(d))
                    {
                        if (Regex.IsMatch(file, "osb$"))
                        {
                            List<string> sbElements = getSBElements(file);
                            foreach (string sbElement in sbElements)
                            {
                                if (!whitelist.Contains(sbElement))
                                {
                                    long size = getFileSize(d + sbElement);
                                    if (size != 0)
                                    {
                                        foundElements.Add(d + sbElement);
                                        filesSize += size;
                                    }
                                }
                            }
                        }
                    }
                }

                if (backgroundDeleteCheckbox.Checked)
                {
                    List<string> bgElements = new List<string>();
                    foreach (string file in Directory.GetFiles(d))
                        if (Regex.IsMatch(file, "osu$"))
                        {
                            string bg = getBGPath(file);
                            if (bg != null && !bgElements.Contains(bg))
                            {
                                long size = getFileSize(d + bg);
                                if (size != 0)
                                {
                                    bgElements.Add(bg);
                                    foundElements.Add(d + bg);
                                    filesSize += size;
                                }
                            }
                        }
                }

                foreach (string file in Directory.GetFiles(d))
                {
                    if (videoDeleteCheckbox.Checked)
                        if (RegexMatch(file, "avi$") || RegexMatch(file, "flv$") || RegexMatch(file, "mp4$"))
                        {
                            foundElements.Add(file);
                            filesSize += getFileSize(file);
                        }
                    if (skinDeleteCheckbox.Checked)
                    {
                        foreach (string regex in skinElements)
                            if (RegexMatch(file, regex))
                            {
                                foundElements.Add(file);
                                filesSize += getFileSize(file);
                            }
                    }
                    if (hitSoundsDeleteCheckbox.Checked)
                    {

                        if (RegexMatch(file, "\\\\drum-") || RegexMatch(file, "\\\\normal-") || RegexMatch(file, "\\\\soft-"))
                        {
                            foundElements.Add(file);
                            filesSize += getFileSize(file);
                        }
                    }
                }
                if (worker.CancellationPending) return;
                current++;
                worker.ReportProgress((int)((double)current / folderCount * 100));
            }
            worker.ReportProgress(100);
        }

        private void progressBar(object sender, ProgressChangedEventArgs e)
        {
            FindProgressBar.Value = e.ProgressPercentage;
            filesSizeLabel.Text = "Found: " + Math.Round((double)(filesSize) / 1048576, 4) + " MB";
        }

        private void findComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (string file in foundElements)
                    elementList.Items.Add(file);
            filesSizeLabel.Text = "Found: " + Math.Round((double)(filesSize) / 1048576, 4) + " MB";
            foundElements.Clear();
            FindProgressBar.Visible = false;
            cancelButton.Visible = false;
            FindProgressBar.Value = 0;
        }

        private string getOsuPath()
        {
            using (RegistryKey osureg = Registry.ClassesRoot.OpenSubKey("osu\\DefaultIcon"))
            {
                if (osureg != null)
                {
                    string osukey = osureg.GetValue(null).ToString();
                    string osupath = osukey.Remove(0, 1);
                    osupath = osupath.Remove(osupath.Length - 11);
                    return osupath;
                }
                else return "";
            }
        }

        private string getBGPath(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (Regex.IsMatch(line, "^//Background and Video events"))
                    {
                        line = file.ReadLine();
                        string[] items = line.Split(',');
                        if (items[0] == "0")
                        {
                            string tmp = "\\" + items[2].Replace("\"", string.Empty);
                            return tmp;
                        }
                    }
                }
                return null;
            }
        }

        private List<string> getSBElements(string file)
        {
            List<string> sbElements = new List<string>();
            using (StreamReader sbFile = File.OpenText(file))
            {
                string line;
                while ((line = sbFile.ReadLine()) != null)
                {
                    string[] items = line.Split(',');
                    if (items[0] == "Sprite")
                    {
                        string tmp = "\\" + items[3].Replace("\"", string.Empty);
                        tmp = tmp.Replace("/", "\\");
                        if (!sbElements.Contains(tmp))
                            sbElements.Add(tmp);
                    }
                }
            }
            return sbElements;
        }

        private long getFileSize(string path)
        {
            try
            {
                FileInfo sizeInfo = new FileInfo(path);
                return sizeInfo.Length;
            }
            catch (FileNotFoundException)
            {
                return 0;
            }
            catch (NotSupportedException)
            {
                return 0;
            }
        }

        private void setSkinList()
        {
            skinElements.Add("\\\\applause"); ;
            skinElements.Add("\\\\approachcircle"); ;
            skinElements.Add("\\\\button-"); ;
            skinElements.Add("\\\\combobreak");
            skinElements.Add("\\\\comboburst");
            skinElements.Add("\\\\count");
            skinElements.Add("\\\\cursor");
            skinElements.Add("\\\\default-");
            skinElements.Add("\\\\failsound");
            skinElements.Add("\\\\followpoint");
            skinElements.Add("\\\\fruit-");
            skinElements.Add("\\\\go\\.png");
            skinElements.Add("\\\\go@2x\\.png");
            skinElements.Add("\\\\gos\\.png");
            skinElements.Add("\\\\gos@2x\\.png");
            skinElements.Add("\\\\hit0");
            skinElements.Add("\\\\hit100");
            skinElements.Add("\\\\hit300");
            skinElements.Add("\\\\hit50");
            skinElements.Add("\\\\hitcircle");
            skinElements.Add("\\\\inputoverlay-");
            skinElements.Add("\\\\lighting\\.png");
            skinElements.Add("\\\\lighting@2x\\.png");
            skinElements.Add("\\\\mania-");
            skinElements.Add("\\\\menu\\.");
            skinElements.Add("\\\\menu-back");
            skinElements.Add("\\\\particle100");
            skinElements.Add("\\\\particle300");
            skinElements.Add("\\\\particle50");
            skinElements.Add("\\\\pause-");
            skinElements.Add("\\\\pippidon");
            skinElements.Add("\\\\play-");
            skinElements.Add("\\\\ranking-");
            skinElements.Add("\\\\ready");
            skinElements.Add("\\\\reversearrow");
            skinElements.Add("\\\\score-");
            skinElements.Add("\\\\scorebar-");
            skinElements.Add("\\\\sectionfail");
            skinElements.Add("\\\\sectionpass");
            skinElements.Add("\\\\section-");
            skinElements.Add("\\\\selection-");
            skinElements.Add("\\\\sliderb");
            skinElements.Add("\\\\sliderfollowcircle");
            skinElements.Add("\\\\sliderscorepoint");
            skinElements.Add("\\\\spinnerbonus");
            skinElements.Add("\\\\spinner-");
            skinElements.Add("\\\\spinnerspin");
            skinElements.Add("\\\\star\\.png");
            skinElements.Add("\\\\star@2x\\.png");
            skinElements.Add("\\\\star2\\.png");
            skinElements.Add("\\\\star2@2x\\.png");
            skinElements.Add("\\\\taiko-");
            skinElements.Add("\\\\taikobigcircle");
            skinElements.Add("\\\\taikohitcircle");
        }
    }
}
