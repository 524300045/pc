using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WmsSDK;
using WmsSDK.Request;
using WmsSDK.Response;

namespace WmsApp
{
    public partial class WeightForm : TabWindow
    {
        private long packId;

        private string taskCode;

        private long curTaskDetailId = 0;

        private string curOutStockCode;

        private string curSkuCode;

        private IWMSClient client = null;

        public WeightForm()
        {
            InitializeComponent();
        }

        public WeightForm(long _packId,string _taskCode)
        {
            InitializeComponent();
            this.packId = _packId;
            this.taskCode = _taskCode;
            client = new DefalutWMSClient();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void WeightForm_Load(object sender, EventArgs e)
        {
            ShowDetail();
            tbWeight.Focus();
        }

        /// <summary>
        /// 显示商品明细
        /// </summary>
        private void ShowDetail()
        { 
          //获取可用的任务
            PackTaskCodeRequest request = new PackTaskCodeRequest();
            request.packTaskCode = taskCode;
            PackTaskDetailResponse response = client.Execute(request);
            if (!response.IsError)
            {
                if (response.result != null)
                {
                    lbSkuInfo.Text = response.result.skuCode + "  " + response.result.goodsName + "  " + response.result.modelNum + response.result.goodsUnit + "/" + response.result.physicsUnit;
                    lbProcess.Text = response.result.progress.ToString();
                    lbStore.Text = response.result.storedName;
                    lbOrderWeight.Text = "";//订单总量
                    lbUpDown.Text = response.result.upPlanNum + "--" + response.result.downPlanNum;//上下限
                    lbPackNUM.Text = "";//标注包数
                    curTaskDetailId = response.result.id;//当前任务明细ID
                    curOutStockCode = response.result.outboundTaskCode;
                    curSkuCode = response.result.skuCode;
                }
                else
                {
                    MessageBox.Show("当前没有要加工的订单!");
                }
            }

        }

        private void ClearForm()
        {
            lbSkuInfo.Text = "";
            lbProcess.Text = "";
            lbStore.Text = "";
            lbOrderWeight.Text = "";
            lbUpDown.Text = "";
            lbPackNUM.Text = "";

        }

        private void tbWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(tbWeight.Text.Trim()))
                {
                    MessageBox.Show("请录入重量!");
                    tbWeight.Focus();
                    return;
                }

                decimal weight = 0;
                decimal.TryParse(tbWeight.Text.Trim(), out weight);
                if (weight<=0)
                {
                     MessageBox.Show("录入重量必须大于0!");
                    tbWeight.Focus();
                    return;
                }

                PackageRequest request = new PackageRequest();
                request.packTaskDetailId = curTaskDetailId;
                request.processUser = UserInfo.UserName;
                request.weight =decimal.Parse(tbWeight.Text.Trim());
                request.packTaskCode = taskCode;
                request.outboundTaskCode = curOutStockCode;
                request.skuCode = curSkuCode;
                request.createUser = UserInfo.UserName;
                request.updateUser = UserInfo.UserName;

               PackageResponse response=client.Execute(request);
               if (!response.IsError)
               {
                   //打印，加载下一个
                   ShowDetail();
               }
            }
        }

        private void WeightForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
