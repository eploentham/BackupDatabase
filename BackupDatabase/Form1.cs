using ICSharpCode.SharpZipLib.Zip;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupDatabase
{
    public partial class Form1 : Form
    {
        Timer timer1;
        IniFile iniF;
        InitConfig iniC;

        public Form1()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            String appName = "";
            appName = System.AppDomain.CurrentDomain.FriendlyName;
            appName = appName.ToLower().Replace(".exe", "");
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\" + appName + ".ini"))
            {
                appName = Environment.CurrentDirectory + "\\" + appName + ".ini";
            }
            else
            {
                appName = Environment.CurrentDirectory + "\\" + Application.ProductName + ".ini";
            }
            iniF = new IniFile(appName);
            iniC = new InitConfig();

            iniC.hostDB = iniF.Read("hostDB");
                        
            iniC.nameDB = iniF.Read("nameDB");
            iniC.passDB = iniF.Read("passDB");
            iniC.portDB = iniF.Read("portDB");
            iniC.userDB = iniF.Read("userDB");
            iniC.pathBackupDatabase = iniF.Read("pathBackupDatabase");

            timer1 = new Timer();
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            timer1.Interval = 1000 * 60;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTimeCurrent.Text = String.Format("{0:HHmm}", System.DateTime.Now);
            if (txtTimeCurrent.Text.Equals(txtAutoStart.Text))
            {
                txtTimeStart.Text = String.Format("{0:HHmm}", System.DateTime.Now);
                backupDatabase();
                //DateTime startDate = Convert.ToDateTime(System.DateTime.Now).AddDays(-1);
                //selectCar(startDate.Year.ToString() + "-" + startDate.ToString("MM-dd"), startDate.Year.ToString() + "-" + startDate.ToString("MM-dd"));
                txtTimeEnd.Text = String.Format("{0:HHmm}", System.DateTime.Now);
            }
        }
        

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Process process = new Process();
            //process.StartInfo.FileName = "mysqldump.exe";
            //process.StartInfo.Arguments = @"--user=root --host=localhost --password=Ekartc2c5 --port=3306 --default-character-set=utf8 --skip-triggers --databases xtrim_erp >> d:\backup.sql";
            //process.StartInfo.UseShellExecute = false;
            //process.StartInfo.RedirectStandardOutput = true;
            //process.StartInfo.RedirectStandardError = true;
            ////* Set ONLY ONE handler here.
            //process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            ////* Start process
            //process.Start();
            ////* Read one element asynchronously
            //process.BeginErrorReadLine();
            ////* Read the other one synchronously
            //string output = process.StandardOutput.ReadToEnd();
            //Console.WriteLine(output);
            //process.WaitForExit();
            txtTimeStart.Text = String.Format("{0:HHmm}", System.DateTime.Now);
            backupDatabase();
            txtTimeEnd.Text = String.Format("{0:HHmm}", System.DateTime.Now);
        }
        private void backupDatabase()
        {
            string constring = "server=" + iniC.hostDB + ";user=" + iniC.userDB + ";pwd=" + iniC.passDB + ";database=" + iniC.nameDB + ";port=" + iniC.portDB + ";";
            string file = iniC.pathBackupDatabase;
            
            if (file.Equals(""))
            {
                MessageBox.Show("ไม่พบ Path Backup", "");
                return;
            }
            try
            {
                if (!Directory.Exists(file))
                {
                    Directory.CreateDirectory(file);
                }
                file = file + "\\"+ iniC.nameDB + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".sql";
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }

                try
                {
                    String filezip = file.Replace(".sql", ".zip");
                    // Depending on the directory this could be very large and would require more attention
                    // in a commercial package.
                    //string[] filenames = Directory.GetFiles(args[0]);

                    // 'using' statements guarantee the stream is closed properly which is a big source
                    // of problems otherwise.  Its exception safe as well which is great.
                    using (ZipOutputStream s = new ZipOutputStream(File.Create(filezip)))
                    {

                        s.SetLevel(9); // 0 - store only to 9 - means best compression

                        byte[] buffer = new byte[4096];

                        // Using GetFileName makes the result compatible with XP
                        // as the resulting path is not absolute.
                        var entry = new ZipEntry(Path.GetFileName(file));

                        // Setup the entry data as required.

                        // Crc and size are handled by the library for seakable streams
                        // so no need to do them here.

                        // Could also use the last write time or similar for the file.
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {

                            // Using a fixed size buffer here makes no noticeable difference for output
                            // but keeps a lid on memory usage.
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                        

                        // Finish/Close arent needed strictly as the using statement does this automatically

                        // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                        // the created file would be invalid.
                        s.Finish();

                        // Close is important to wrap things up and unlock the file.
                        s.Close();

                        File.Delete(file);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception during processing {0}", ex);

                    // No need to rethrow the exception as for our purposes its handled.
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("ไม่สามารถ สร้าง folder ได้ "+ ioex.Message + " " + ioex.InnerException, "");
                return;
            }
        }
        static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            //* Do your stuff with the output (write to console/log/StringBuilder)
            Console.WriteLine(outLine.Data);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
