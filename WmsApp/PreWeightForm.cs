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
    public partial class PreWeightForm : TabWindow
    {
        public PreWeightForm()
        {
            InitializeComponent();
        }
        private IWMSClient client = null;

        private Goods goods;

        public PreWeightForm(Goods _goods)
        {
            InitializeComponent();
            this.goods = _goods;
            client = new DefalutWMSClient();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void WeightForm_Load(object sender, EventArgs e)
        {
            GetCount();
            if (goods.weighed == 1)
            {
                //称重
                lbWeight.Visible = true;
            }
            else
            {
                //标准包裹数
                lbStandPackage.Visible = true;
            }
            lbSkuInfo.Text = goods.skuCode + "  " + goods.goodsName + "  " + goods.modelNum + goods.goodsUnit + "/" + goods.physicsUnit;
            lbUpDown.Text = goods.upLimit + goods.goodsUnit + "--" + goods.downLimit + goods.goodsUnit;
            lbModelNum.Text = goods.modelNum + goods.goodsUnit + "/" + goods.physicsUnit;
            tbWeight.Focus();
        }

        private void GetCount()
        {
            PreprocessInfoCountRequest request = new PreprocessInfoCountRequest();
            request.status = 0;
            request.skuCode = goods.skuCode;
            PreprocessInfoCountResponse response = client.Execute(request);
            if (!response.IsError)
            {
                lbCount.Text = response.result.ToString();
            }
        }

        private void tbWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    List<PreprocessInfoAdd> list = new List<PreprocessInfoAdd>();

                    if (goods.weighed == 1)
                    {
                        #region 称重


                        if (string.IsNullOrWhiteSpace(tbWeight.Text.Trim()))
                        {
                            MessageBox.Show("请录入重量!");
                            tbWeight.Focus();
                            return;
                        }

                        decimal weight = 0;
                        decimal.TryParse(tbWeight.Text.Trim(), out weight);
                        if (weight <= 0)
                        {
                            MessageBox.Show("录入重量必须大于0!");
                            tbWeight.Focus();
                            return;
                        }

                        PreprocessInfoAdd add = new PreprocessInfoAdd();
                        add.createUser = UserInfo.UserName;
                        add.goodsName = goods.goodsName;
                        add.goodsUnit = goods.goodsUnit;
                        add.modelNum = goods.modelNum;
                        add.operateUser = UserInfo.UserName;
                        add.packWeight = weight * 2;
                        add.partnerCode = UserInfo.PartnerCode;
                        add.partnerName = UserInfo.PartnerName;
                        add.physicsUnit = goods.physicsUnit;
                        add.skuCode = goods.skuCode;
                        add.status = 0;
                        add.updateUser = UserInfo.UserName;
                        list.Add(add);

                        #endregion
                    }
                    else
                    {
                        #region 包裹数

                        if (string.IsNullOrWhiteSpace(tbWeight.Text.Trim()))
                        {
                            MessageBox.Show("请录入包裹数!");
                            tbWeight.Focus();
                            return;
                        }

                        int weight = 0;
                        int.TryParse(tbWeight.Text.Trim(), out weight);
                        if (weight <= 0)
                        {
                            MessageBox.Show("录入包裹数必须大于0!");
                            tbWeight.Focus();
                            return;
                        }
                        if (weight > 100)
                        {
                            MessageBox.Show("录入数量不能大于100!");
                            tbWeight.Focus();
                            return;
                        }

                        for (int i = 0; i < weight; i++)
                        {
                            PreprocessInfoAdd add = new PreprocessInfoAdd();
                            add.createUser = UserInfo.UserName;
                            add.goodsName = goods.goodsName;
                            add.goodsUnit = goods.goodsUnit;
                            add.modelNum = goods.modelNum;
                            add.operateUser = UserInfo.UserName;
                            add.packWeight = goods.modelNum;
                            add.partnerCode = UserInfo.PartnerCode;
                            add.partnerName = UserInfo.PartnerName;
                            add.physicsUnit = goods.physicsUnit;
                            add.skuCode = goods.skuCode;
                            add.status = 0;
                            add.updateUser = UserInfo.UserName;
                            list.Add(add);
                        }
                        #endregion
                    }

                    PreprocessInfoRequest request = new PreprocessInfoRequest();
                    request.wareHouseId = UserInfo.WareHouseCode;
                    request.request = list;
                    PreprocessInfoAddResponse response = client.Execute(request);
                    if (!response.IsError)
                    {
                        if (response.result!=null)
                        {
                            #region 循环打印

                            foreach (var item in response.result)
                            {

                            }

                            #endregion
                       
                        }
                        GetCount();
                    }
                    tbWeight.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常"+ex.Message);
                }
           
            }
        }

        private void WeightForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {


                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
