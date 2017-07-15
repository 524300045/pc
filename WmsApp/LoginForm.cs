
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WmsApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUserName.Text.Trim()))
            {
                MessageBox.Show("用户名不能为空!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbPwd.Text.Trim()))
            {
                MessageBox.Show("密码不能为空!");
                return;
            }

            try
            {

                UserInfo.UserName = tbUserName.Text.Trim();
                UserInfo.PartnerName = tbUserName.Text.Trim();
                UserInfo.PartnerCode ="1";
                UserInfo.WareHouseCode = "1";
                UserInfo.WareHouseName = "北京";
                
            }
            catch (Exception ex)
            {
                LogHelper.Log("Login:"+ex.Message);
                MessageBox.Show("出现异常"+ex.Message);
            }
           

            this.DialogResult = DialogResult.OK;
        }
    }
}
