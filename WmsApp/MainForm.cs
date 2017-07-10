using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WmsApp
{
    public partial class MainForm : Form, IFrame
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private static MainForm instance;
        internal static MainForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainForm();
                }
                return instance;
            }
        }

        public void AddToFrame(IDockContent fx)
        {
            DockContent f = (DockContent)fx;
            f.TabText = f.Text;
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Show(dockPanel1);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CloseAllTab();
        }

        public void CloseCurrentTab()
        {
            if (dockPanel1.ActiveDocument != null)
            {
                dockPanel1.ActiveDocument.DockHandler.Close();
            }
        }

        public void CloseAllTab()
        {
            while (dockPanel1.DocumentsCount > 0)
            {
                dockPanel1.ActiveDocument.DockHandler.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddToFrame(new PackageTaskForm());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddToFrame(new PackageDetailForm());
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出系统吗?")==DialogResult.OK)
            {
                Application.Exit();
            }
       
        }

        private void tsbPrePack_Click(object sender, EventArgs e)
        {

            AddToFrame(new PrePackageForm());
        }

        private void tsbBox_Click(object sender, EventArgs e)
        {

            AddToFrame(new BoxPrintForm());
        }

        private void tsbTaskQuery_Click(object sender, EventArgs e)
        {

            AddToFrame(new PackageTaskQueryForm());
        }
    }
}
