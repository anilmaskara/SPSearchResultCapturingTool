using ExcelDataReader;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Query;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTWSearchTestAutomationWin
{
    public partial class FrmSearch : System.Windows.Forms.Form
    {
        public ClientContext spclientContext;
        public static FrmSearch FrmSearchInstace;
        public String SiteURL;

        public FrmSearch()
        {
            FrmSearchInstace = this;
            InitializeComponent();
        
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
           
            if (txtinputfile.Text.Trim()=="" || txtoutput.Text.Trim() =="") {
                MyMessageBox msgb = new MyMessageBox("Please select Input file and output folder location.", "Validation Failed!!!");
                msgb.Show();
               
                return;
            }
            btnsearch.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            string strQueryRule = string.Empty;
            String strSourceID = String.Empty;
            String strRankID = String.Empty;
            String strScope = String.Empty;
            try
            {
                if (!String.IsNullOrEmpty(txtSortBy.Text.Trim()) && cmbsortdir.Text=="Select Order")
                {
                    MyMessageBox msgb1 = new MyMessageBox("Please select sort order.", "Validation Failed!!!");
                    msgb1.Show();
                  
                    cmbsortdir.Focus();
                    btnsearch.Enabled = true;
                    return;
                }
                if(chkuseQueryRules.Checked)
                {
                    strQueryRule = "True";
                }
                else
                {
                    strQueryRule = "False";
                }
                if(cmbResultSource.SelectedValue !=null && cmbResultSource.SelectedValue.ToString()!="-1")
                {           
                 strSourceID = cmbResultSource.SelectedValue.ToString();
   
                }
                if(cmbResultSource.SelectedValue == null && cmbResultSource.Text.Trim()!="")
                {
                    strSourceID = cmbResultSource.Text.Trim();
                }

                if (cmbRank.SelectedValue != null && cmbRank.SelectedValue.ToString() != "-1")
                {
                    strRankID = cmbRank.SelectedValue.ToString();

                }
                if (cmbRank.SelectedValue == null && cmbRank.Text.Trim() != "")
                {
                    strRankID = cmbRank.Text.Trim();
                }
                if(cmbScope.SelectedIndex!=0)
                {
                    strScope = cmbScope.Text;
                }

                List<String> Keywords = Common.ReadInputFile(txtinputfile.Text);
                Common.SearchMethod(spclientContext, Keywords, textQueryPath.Text.Trim(), txtQueryTemplate.Text.Trim(), strSourceID, txtoutput.Text.Trim(), strRankID, txtRefinedBy.Text.Trim(),txtSortBy.Text.Trim(),cmbsortdir.Text,txtgroupBy.Text,strQueryRule, strScope,this.SiteURL);

                Common.UpdateConfig("InputFileLocation", txtinputfile.Text.Trim());
                Common.UpdateConfig("OutputFolderLocation", txtoutput.Text.Trim());
                Common.UpdateConfig("QueryText", txtQueryTemplate.Text.Trim());
                Common.UpdateConfig("SearchPath", textQueryPath.Text.Trim());
                Common.UpdateConfig("ResultSourceID",strSourceID);
                Common.UpdateConfig("RankingModelID", strRankID);
                Common.UpdateConfig("RefinedBy", txtRefinedBy.Text.Trim());
                Common.UpdateConfig("SortBy", txtSortBy.Text.Trim());
                Common.UpdateConfig("SortDir",cmbsortdir.Text);
                Common.UpdateConfig("GroupBy", txtgroupBy.Text.Trim());
                Common.UpdateConfig("UseQueryRule",strQueryRule);
                Common.UpdateConfig("Scope", strScope);


                Cursor.Current = Cursors.Default;
                MyMessageBox msgb = new MyMessageBox("Search results exported to excel successfully.", "Success!!");
                msgb.Show();
                
                btnsearch.Enabled = true;
            }
            catch(Exception ex)
            {
                MyMessageBox msgb = new MyMessageBox(ex.Message, "Error!!");
                msgb.Show();
                btnsearch.Enabled = true;
                Cursor.Current = Cursors.Default;
                Common.ErrorLog(ex.Message + " Stack Trace:" + ex.StackTrace);
            }
        }

        private void btnInputBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogInput.InitialDirectory = @"C:\";
            openFileDialogInput.Title = "Browse input file";
            openFileDialogInput.DefaultExt = "xlsx";
            openFileDialogInput.Filter = "Excel files (*.xlsx)|*.xlsx";
            openFileDialogInput.CheckFileExists = true;
            openFileDialogInput.CheckPathExists = true;
            openFileDialogInput.ShowDialog();
        }

        private void openFileDialogInput_FileOk(object sender, CancelEventArgs e)
        {
            txtinputfile.Text = openFileDialogInput.FileName;

        }

        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtoutput.Text = fbd.SelectedPath;

                }
            }
        }
        
        private void FrmSearch_Load(object sender, EventArgs e)
        {
            try
            {


                this.CenterToScreen();
                LoadRankList();
                LoadSourceList();
                cmbsortdir.SelectedIndex = 0;
                cmbScope.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                Common.ErrorLog(ex.Message + " Stack Trace:" + ex.StackTrace);
            }
        }
        public void ClearControl()
        {
            txtinputfile.Text = "";
            txtoutput.Text = "";
            textQueryPath.Text = "";
            cmbResultSource.Text = "";
            txtQueryTemplate.Text = "";
            openFileDialogInput.FileName = "";
            btnsearch.Enabled = true;
        }
        private void FrmSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            spclientContext.Dispose();
            System.Windows.Forms.Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            spclientContext.Dispose();
            System.Windows.Forms.Application.Exit();
            //this.Hide();
            //FrmLogin.FrmLoginInstace.clearFrom();
            //FrmLogin.FrmLoginInstace.Show();
        }

       
        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(FrmSettings.FrmSettingsInstace==null)
            {
                FrmSettings frm = new FrmSettings();
                frm.Show();
            }
            else
            {
                FrmSettings.FrmSettingsInstace.Show();
            }
        }

        

       
        private void LoadSourceList()
        {
            cmbResultSource.DataSource = Common.ReadSourceFile();
            cmbResultSource.DisplayMember = "Name";
            cmbResultSource.ValueMember = "ID";
        }
        private void LoadRankList()
        {
            cmbRank.DataSource = Common.ReadRankListFile();
            cmbRank.DisplayMember = "Name";
            cmbRank.ValueMember = "ID";
        }

        private void cmbScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbResultSource.SelectedIndex = 0;
        }

        private void cmbResultSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbScope.SelectedIndex = 0;
        }

       
    }
}
