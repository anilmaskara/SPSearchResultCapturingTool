using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using System.Security;
using System.Configuration;

namespace WTWSearchTestAutomationWin
{
    public partial class FrmLogin : System.Windows.Forms.Form
    {
        public static FrmLogin FrmLoginInstace;
        public FrmLogin()
        {
            FrmLoginInstace = this;
            InitializeComponent();
        }
        public void clearFrom()
        {
            txtUserName.Text = "";
            txtPass.Text = "";
            txtURL.Text = "";
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {


            this.CenterToScreen();
               

        }
            

          private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            string userName = txtUserName.Text;
            string Password = txtPass.Text;
            string SiteURL = txtURL.Text;
            SecureString securePassword = null;
            ClientContext spclientContext = null;
            try
            {


                if (!String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(SiteURL))
                {
                    securePassword = new SecureString();
                    foreach (char c in Password)
                    {
                        securePassword.AppendChar(c);
                    }
                    if (spclientContext != null)
                    {
                        spclientContext.Dispose();
                    }

                   
                    spclientContext = new ClientContext(SiteURL);
                

                    spclientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                    spclientContext.ExecuteQuery();

                    Common.UpdateConfig("UserName", userName);
                    Common.UpdateConfig("Password", Common.EncodePasswordToBase64(Password));
                    Common.UpdateConfig("SiteURL", SiteURL);


                    if (FrmSearch.FrmSearchInstace == null)
                    {
                        FrmSearch searchfrom = new FrmSearch();
                        searchfrom.spclientContext = spclientContext;
                        searchfrom.SiteURL = SiteURL;
                        this.Hide();
                        searchfrom.Show();
                    }
                    else
                    {
                        FrmSearch.FrmSearchInstace.ClearControl();
                        FrmSearch.FrmSearchInstace.spclientContext = spclientContext;
                        FrmSearch.FrmSearchInstace.SiteURL = SiteURL;
                        this.Hide();
                        FrmSearch.FrmSearchInstace.Show();
                    }
                    Cursor.Current = Cursors.Default;
                    btnLogin.Enabled = true;


                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    btnLogin.Enabled = true;

                    

                    MyMessageBox msgb = new MyMessageBox("Please enter username, password and site url.", "Validation Failed !!!");
                    msgb.Show();
                 }
            }
            catch(Exception ex)
            {
                Cursor.Current = Cursors.Default;
                btnLogin.Enabled = true;
                MyMessageBox msgb = new MyMessageBox(ex.Message, "Error!!!");
                msgb.Show();
                Common.ErrorLog(ex.Message + " Stack Trace:" + ex.StackTrace);
            }
        }

        

        

        
    }
}
