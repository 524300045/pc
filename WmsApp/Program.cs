using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WmsSDK;

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

            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            string proc = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(proc);
            if (processes.Length == 2)
            {
                MessageBox.Show("请不要运行多个系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            log4net.Config.XmlConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //DefalutWMSClient.DefaultServiceAddress = " http://192.168.0.113:8089/webservice/services";


            DefalutWMSClient.DefaultServiceAddress = " http://api.cooperate.bjkalf.net:8080/services";


            // Application.Run(new Form1());
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

        /// <summary>
        /// 处理应用程序域内的未处理异常（非UI线程异常）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.ExceptionObject as Exception;
                MessageBox.Show(ex.Message);
            }
            catch { }
        }

        /// <summary>
        /// 处理应用程序的未处理异常（UI线程异常）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
