using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WmsApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginForm = new LoginForm();
            loginForm.StartPosition = FormStartPosition.CenterParent;
            loginForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            loginForm.ShowDialog();
            if (loginForm.DialogResult != DialogResult.OK)
            {
                Application.Exit();
                return;
            }

            Application.Run(MainForm.Instance);
           
        }
    }
}
