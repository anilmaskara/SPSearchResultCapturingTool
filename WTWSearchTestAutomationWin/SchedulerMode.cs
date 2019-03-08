using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTWSearchTestAutomationWin
{
    public partial class FrmSchedulerMode : System.Windows.Forms.Form
    {
        public FrmSchedulerMode()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkManualMode.Checked)
                {
                    Common.UpdateConfig("AppMode", "Windows");
                    MessageBox.Show("Mode Updated", "Message!!");
                }
                System.Windows.Forms.Application.Exit();
            }
            catch (Exception ex)
            {
                Common.ErrorLog(ex.Message + " Stack Trace:" + ex.StackTrace);
            }
        }

        private void SchedulerMode_Load(object sender, EventArgs e)
        {
            try
            {
                string userName = ConfigurationManager.AppSettings["UserName"];
                string EnCodedpassword = ConfigurationManager.AppSettings["Password"];
                string SiteURL = ConfigurationManager.AppSettings["SiteURL"];
                string InputPath = ConfigurationManager.AppSettings["InputFileLocation"];
                string SearchPath = ConfigurationManager.AppSettings["SearchPath"];
                string QueryTemplate = ConfigurationManager.AppSettings["QueryText"];
                string ResultSourceID = ConfigurationManager.AppSettings["ResultSourceID"];
                string OutputFolderLocation = ConfigurationManager.AppSettings["OutputFolderLocation"];
                string RankingMOdelID = ConfigurationManager.AppSettings["RankingModelID"];
                string RefinedBy = ConfigurationManager.AppSettings["RefinedBy"];
                string SortBy = ConfigurationManager.AppSettings["SortBy"];
                string SortDir = ConfigurationManager.AppSettings["SortDir"];
                string GroupBy = ConfigurationManager.AppSettings["GroupBy"];
                string UseQueryRule = ConfigurationManager.AppSettings["UseQueryRule"];
                string strScope = ConfigurationManager.AppSettings["Scope"];



                SecureString securePassword = null;

                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(EnCodedpassword) && !string.IsNullOrEmpty(SiteURL) && !string.IsNullOrEmpty(InputPath))
                {

                    string decodedPass = Common.DecodeFrom64(EnCodedpassword);
                    securePassword = new SecureString();

                    foreach (char c in decodedPass)
                    {
                        securePassword.AppendChar(c);
                    }
                    using (ClientContext clientContext = new ClientContext(SiteURL))
                    {

                        clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                        List<String> Keywords = Common.ReadInputFile(InputPath);
                        Common.SearchMethod(clientContext, Keywords, SearchPath, QueryTemplate, ResultSourceID, OutputFolderLocation, RankingMOdelID, RefinedBy, SortBy, SortDir, GroupBy, UseQueryRule, strScope, SiteURL);
                    }
                }
                System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
                tmr.Tick += delegate
                {
                    this.Close();
                };
                tmr.Interval = (int)TimeSpan.FromSeconds(30).TotalMilliseconds;
                tmr.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");
                Common.ErrorLog(ex.Message + " Stack Trace:" + ex.StackTrace);
            }

        }
    }
}
