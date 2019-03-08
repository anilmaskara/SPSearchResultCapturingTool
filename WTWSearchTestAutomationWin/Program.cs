using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WTWSearchTestAutomationWin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

            

            try
            {
                string AppMode = ConfigurationManager.AppSettings["AppMode"];
                if (AppMode == "Scheduler")
                {


                    Application.Run(new FrmSchedulerMode());


                }
                else
                {
                    Application.Run(new FrmLogin());
                }
            }

            



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");

                Common.ErrorLog(ex.Message + " Stack Trace:" + ex.StackTrace);
            }

        }
    }
}
