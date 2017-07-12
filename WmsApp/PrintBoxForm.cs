using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WmsSDK;
using WmsSDK.Model;
using WmsSDK.Request;
using WmsSDK.Response;

namespace WmsApp
{
    public partial class PrintBoxForm : Form
    {
        private IWMSClient client = null;
        public PrintBoxForm()
        {
            InitializeComponent();
            client = new DefalutWMSClient();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (tbNum.Text.Trim()=="")
            {
                MessageBox.Show("请输入大于数量");
                return;
            }

            int num = 0;
            int.TryParse(tbNum.Text.Trim(), out num);
            if (num<=0)
            {
                MessageBox.Show("打印数量必须大于0");
                return;
            }

            try
            {
             
                List<BoxInfo> list = new List<BoxInfo>();
                for (int i = 0; i < num; i++)
                {
                    BoxInfo boxInfo = new BoxInfo();
                    boxInfo.customerCode = UserInfo.PartnerCode;
                    boxInfo.customerName = UserInfo.PartnerName;
                    boxInfo.warehouseCode = UserInfo.WareHouseCode;
                    boxInfo.warehouseName = UserInfo.WareHouseName;
                    boxInfo.storedCode = cbStore.SelectedValue.ToString();
                    boxInfo.storedName = cbStore.Text;
                    boxInfo.printMan = UserInfo.UserName;
                    boxInfo.updateUser = UserInfo.UserName;
                    boxInfo.createUser = UserInfo.UserName;
                    list.Add(boxInfo);
                }


                BoxInfoAddRequest request = new BoxInfoAddRequest();
                request.request = list;
                BoxInfoAddResponse response =client.Execute(request);
                if (!response.IsError)
                {
                    //开始打印

                }

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void PrintBoxForm_Load(object sender, EventArgs e)
        {
            bindStore();
        }

        private void bindStore()
        {
            StoreInfoRequest request = new StoreInfoRequest();
            StoreInfoResponse response = client.Execute(request);
            if (!response.IsError)
            {
                if (response.result != null)
                {
                    List<StoreInfo> storeList = new List<StoreInfo>();

                    storeList = response.result;
              
                    this.cbStore.DataSource = storeList;
                    this.cbStore.DisplayMember = "storedName";
                    this.cbStore.ValueMember = "storedCode";
                    cbStore.SelectedIndex = 0;
                }
            }
        }
    }
}
