using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Net;
using System.IO.Compression;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Data.Sql;
using System.Data.SqlClient;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;

namespace Installer
{
    public partial class Main : Form
    {
        public static bool start = false;
        public static string host = "gamer.mn";
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        
        public Main()
        {
            
            bool osok = false;
            if (System.Environment.OSVersion.Version.Major == 6 && System.Environment.OSVersion.Version.Minor == 1)
            {
                osok = true;
            }
            if (osok == false)
            {
                MessageBox.Show("Үйлдлийн систем дэмжихгүй. Зөвхөн Windows 7 зөвшөөрнө.", "Анхаар", MessageBoxButtons.OK);
                System.Environment.Exit(0);
            }
            bool isElevated;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if (isElevated == false)
            {
                MessageBox.Show(this, "Үйлдлийн системийн хэрэглэгчийн эрх хүрэлцэхгүй байна. 'Run as Administrator' ашиглана уу.", "Mastercafe Installer");
                System.Environment.Exit(0);
            }
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            InitializeComponent();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Process[] ps = Process.GetProcesses();
            for (int i = 0; i < ps.Length; i++)
            {
                if (ps[i].ProcessName == "pcaui")
                {
                    ps[i].Kill();
                }
            }
            /*
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() => { Text = c+""; }));
            else Text = c+"";
            */
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                label_installing.Visible = true;
                pictureBox.Visible = true;
                label_choose.Visible = false;
                radioButton_client.Visible = false;
                radioButton_monitor.Visible = false;
                radioButton_server.Visible = false;
                progressBar.Visible = false;
                button_install.Visible = false;
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Суулгац татахад алдаа гарлаа.","Анхаар",MessageBoxButtons.OK);
                System.Environment.Exit(0);
            }
        }

        private void button_install_Click(object sender, EventArgs e)
        {
            start = true;
            radioButton_client.Enabled = false;
            radioButton_monitor.Enabled = false;
            radioButton_server.Enabled = false;
            button_install.Enabled = false;

            if (System.IO.Directory.Exists(@"C:\mc")==false)
            {
                System.IO.Directory.CreateDirectory(@"C:\mc");
            }
            if (System.IO.Directory.Exists(@"C:\mc\server") == false)
            {
                System.IO.Directory.CreateDirectory(@"C:\mc\server");
            }
            if (radioButton_server.Checked)
            {
                if (System.IO.File.Exists(@"C:\mc\server.tar.gz"))
                {
                    System.IO.File.Delete(@"C:\mc\server.tar.gz");
                }
                WebClient webClientVersion = new WebClient();
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(@"http://"+host+@"/api/installs/server.tar.gz"), @"C:\mc\server\server.tar.gz");
            }
        }   

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (start)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (radioButton_server.Checked)
            {
                Stream inStream = File.OpenRead(@"C:\mc\server\server.tar.gz");
                Stream gzipStream = new GZipInputStream(inStream);

                TarArchive tarArchive = TarArchive.CreateInputTarArchive(gzipStream);
                tarArchive.ExtractContents(@"C:\mc\server");
                tarArchive.Close();

                gzipStream.Close();
                inStream.Close();
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Text = "MasterCafe суулгах" + " ("+e.ProgressPercentage+"%)";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (radioButton_server.Checked)
            {
                bool ge = true;
                RegistryKey RKN = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\NET Framework Setup\NDP\v4.0");
                if (RKN == null)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = @"C:\mc\server\dotnet\setup.exe";
                    process.StartInfo.Arguments = @" /q";
                    process.StartInfo.ErrorDialog = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    process.Start();
                    process.WaitForExit();
                }
                //pcaui.exe
                RegistryKey RKS = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Microsoft SQL Server\90");
                if (RKS == null)
                {
                    
                    Process process = new Process();
                    process.StartInfo.FileName = @"C:\mc\server\sqlexpr\setup.exe";
                    process.StartInfo.Arguments = @" /qn ADDLOCAL=ALL SECURITYMODE=SQL SAPWD=pldifvzz7x DISABLENETWORKPROTOCOLS=0 ENABLERANU=0 INSTANCENAME=mastercafe";
                    process.StartInfo.ErrorDialog = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    process.Start();
                    process.WaitForExit();

                    SqlConnection con = new SqlConnection(@"Data Source=127.0.0.1\MASTERCAFE;Persist Security Info=True;User ID=sa;Password=pldifvzz7x;MultipleActiveResultSets=True;");
                    con.Open();

                    SqlCommand cmd = new SqlCommand(Installer.Properties.Resources.create, con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd = null;

                    cmd = new SqlCommand(Installer.Properties.Resources.dbcfg, con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd = null;

                    cmd = new SqlCommand(Installer.Properties.Resources.generate, con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd = null;
                     
                    cmd = new SqlCommand(Installer.Properties.Resources.insert, con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd = null;

                    con.Close();
                    con.Dispose();
                    con = null;
                }
                
                string deskdir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                if (File.Exists(deskdir + @"\server.lnk"))
                {
                    File.Delete(deskdir + @"\server.lnk");
                }
                File.Copy(@"C:\mc\server\server.lnk", deskdir + @"\server.lnk");
                Process.Start(@"C:\mc\server\server.exe");
                System.Environment.Exit(0);
            }
        }
        
    }
}
