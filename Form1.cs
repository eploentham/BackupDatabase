using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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


                //DateTime startDate = Convert.ToDateTime(System.DateTime.Now).AddDays(-1);
                //selectCar(startDate.Year.ToString() + "-" + startDate.ToString("MM-dd"), startDate.Year.ToString() + "-" + startDate.ToString("MM-dd"));
                txtTimeEnd.Text = String.Format("{0:HHmm}", System.DateTime.Now);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

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
            
            string constring = "server=localhost;user=root;pwd=Ekartc2c5;database=xtrim_erp;";
            string file = "D:\\backup.sql";
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
        }
        static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            //* Do your stuff with the output (write to console/log/StringBuilder)
            Console.WriteLine(outLine.Data);
        }
    }
}
