using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTWSearchTestAutomationWin
{
    public partial class FrmSettings : Form
    {
        public static FrmSettings FrmSettingsInstace;
        public FrmSettings()
        {
            InitializeComponent();
            FrmSettingsInstace = this;
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Int32 intNumberOfResults = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfResults"]);
            Int32 intCoumnIndexOfKeyword = Convert.ToInt32(ConfigurationManager.AppSettings["CoumnIndexOfKeyword"]);
            Int32 intInputFileSheetIndex = Convert.ToInt32(ConfigurationManager.AppSettings["InputFileSheetIndex"]);
            Int32 intNoOfRowsToIgnoreInInputFile = Convert.ToInt32(ConfigurationManager.AppSettings["NoOfRowsToIgnoreInInputFile"]);
            String strLogFolderLocation = ConfigurationManager.AppSettings["LogFolderLocation"];
            String AppMode= ConfigurationManager.AppSettings["AppMode"];


            txtNumberOfRecors.Text = intNumberOfResults.ToString();
            txtNumberOfRowsToIgnore.Text = intNoOfRowsToIgnoreInInputFile.ToString();
            txtKeywordColumn.Text = intCoumnIndexOfKeyword.ToString();
            txtScheetIndiex.Text = intInputFileSheetIndex.ToString();
            txtLogFolderLoation.Text = strLogFolderLocation;

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void FrmSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSearch.FrmSearchInstace.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSearch.FrmSearchInstace.Show();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtLogFolderLoation.Text = fbd.SelectedPath;

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtNumberOfRowsToIgnore.Text.Trim()))
                {
                    MyMessageBox msgb2 = new MyMessageBox("Please enter 'No of Rows to Ignore'", "Validation Failed!!");
                    msgb2.Show();

                   
                    return;
                }
                if (string.IsNullOrEmpty(txtKeywordColumn.Text.Trim()))
                {
                    MyMessageBox msgb3 = new MyMessageBox("Please enter 'Index of keword column'", "Validation Failed!!");
                    msgb3.Show();

                    return;
                }
                if (string.IsNullOrEmpty(txtScheetIndiex.Text.Trim()))
                {
                    MyMessageBox msgb4 = new MyMessageBox("Please enter 'Sheet Index'", "Validation Failed!!");
                    msgb4.Show();
                    return;
                }
                if (string.IsNullOrEmpty(txtNumberOfRecors.Text.Trim()))
                {
                    MyMessageBox msgb5 = new MyMessageBox("Please enter 'Number of Records to Search'", "Validation Failed!!");
                    msgb5.Show();
                    return;
                }

                Common.UpdateConfig("NoOfRowsToIgnoreInInputFile", txtNumberOfRowsToIgnore.Text.Trim());
                Common.UpdateConfig("CoumnIndexOfKeyword", txtKeywordColumn.Text.Trim());
                Common.UpdateConfig("InputFileSheetIndex", txtScheetIndiex.Text.Trim());
                Common.UpdateConfig("NumberOfResults", txtNumberOfRecors.Text.Trim());

                if (!String.IsNullOrEmpty(txtLogFolderLoation.Text.Trim()))
                {
                    Common.UpdateConfig("LogFolderLocation", txtLogFolderLoation.Text.Trim());
                }
                if (chkSchedulerMode.Checked)
                {
                    Common.UpdateConfig("AppMode", "Scheduler");

                }

            
                MessageBox.Show("Settings updated successfully", "Success!!");

                this.Hide();
                FrmSearch.FrmSearchInstace.Show();
            }
            catch(Exception ex)
            {
                Common.ErrorLog(ex.Message + " Stack Trace:" + ex.StackTrace);
            }
        }

        private void txtNumberOfRowsToIgnore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtKeywordColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtScheetIndiex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

       
        private void txtNumberOfRecors_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
