﻿using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WmsSDK;
using WmsSDK.Model;
using WmsSDK.Request;
using WmsSDK.Response;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace WmsApp
{
    public partial class PreWeightForm : TabWindow
    {
        public PreWeightForm()
        {
            InitializeComponent();
        }
        private IWMSClient client = null;


        private decimal curWeight = 0;

        private Goods goods;

        private List<PreprocessInfo> preprocessInfoList;

        private PreprocessInfo curPreprocessInfo;

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
                tbUnit.Visible = true;
            }
            else
            {
                //标准包裹数
                lbStandPackage.Visible = true;
            }
            lbSkuInfo.Text = goods.skuCode + "  " + goods.goodsName + "  " + goods.modelNum + goods.goodsUnit + "/" + goods.physicsUnit;

            decimal downWeight = goods.modelNum - (goods.downLimit * goods.modelNum)/100;
            decimal upWeight = goods.modelNum + (goods.upLimit * goods.modelNum)/100;

            lbUpDown.Text = downWeight.ToString("f2") + goods.goodsUnit + "--" + upWeight.ToString("f2") + goods.goodsUnit;
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
                    tbWeight.Enabled = false;
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

                        curWeight = Util.ConvertGToJin(weight);

                        decimal downWeight =goods.modelNum-(goods.downLimit * goods.modelNum)/100;
                        decimal upWeight = goods.modelNum+(goods.upLimit * goods.modelNum)/100;
                        if (curWeight<downWeight)
                        {
                            MessageBox.Show("商品重量小于下限");
                            return;
                        }

                        if (curWeight>upWeight)
                        {
                            MessageBox.Show("重量不能大于上限");
                            return;
                        }

                        PreprocessInfoAdd add = new PreprocessInfoAdd();
                        add.createUser = UserInfo.RealName;
                        add.goodsName = goods.goodsName;
                        add.goodsUnit = goods.goodsUnit;
                        add.modelNum = goods.modelNum;
                        add.operateUser = UserInfo.RealName;
                        
                        add.packWeight = curWeight;
                        add.partnerCode = UserInfo.PartnerCode;
                        add.partnerName = UserInfo.PartnerName;
                        add.physicsUnit = goods.physicsUnit;
                        add.skuCode = goods.skuCode;
                        add.status = 0;
                        add.updateUser = UserInfo.RealName;
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
                        if (weight > 20)
                        {
                            MessageBox.Show("录入包裹数不能大于20!");
                            tbWeight.Focus();
                            return;
                        }

                        for (int i = 0; i < weight; i++)
                        {
                            PreprocessInfoAdd add = new PreprocessInfoAdd();
                            add.createUser = UserInfo.RealName;
                            add.goodsName = goods.goodsName;
                            add.goodsUnit = goods.goodsUnit;
                            add.modelNum = goods.modelNum;
                            add.operateUser = UserInfo.RealName;
                            add.packWeight = goods.modelNum;
                            add.partnerCode = UserInfo.PartnerCode;
                            add.partnerName = UserInfo.PartnerName;
                            add.physicsUnit = goods.physicsUnit;
                            add.skuCode = goods.skuCode;
                            add.status = 0;
                            add.updateUser = UserInfo.RealName;
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

                        if (response.result != null)
                        {

                            preprocessInfoList = response.result;
                            foreach (PreprocessInfo item in preprocessInfoList)
                            {
                                curPreprocessInfo = item;
                                PrintDocument document = new PrintDocument();
                                document.DefaultPageSettings.PaperSize = new PaperSize("Custum", 270, 180);




#if(!DEBUG)
                                PrintDialog dialog = new PrintDialog();
                                document.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                                dialog.Document = document;
#else
                                PrintPreviewDialog dialog = new PrintPreviewDialog();
                                document.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                                dialog.Document = document;
#endif

                                try
                                {
                                    document.Print();
                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show("打印异常" + exception);
                                    document.PrintController.OnEndPrint(document, new PrintEventArgs());
                                }
                            }


                        }
                        GetCount();
                    }

                    tbWeight.Text = "";
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
                finally
                {
                    tbWeight.Enabled = true;
                    tbWeight.Focus();
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


        private void pd_PrintPage(object sender, PrintPageEventArgs e) //触发打印事件
        {
            Bitmap bt = CreateQRCode(curPreprocessInfo.preprocessCode);
            GetPrintPicture(bt, e, curPreprocessInfo);
        }

        public static Bitmap CreateQRCode(string asset)
        {
            EncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 80,
                Height =80
            };
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            return writer.Write(asset);
        }


        public void GetPrintPicture(Bitmap image, PrintPageEventArgs g, PreprocessInfo preprocessInfo)
        {
          

            Font fontCu = new Font("宋体", 12f, FontStyle.Bold);
            int height = 15;
            int heightRight = 15;

            Font font = new Font("宋体", 10f);
            Brush brush = new SolidBrush(Color.Black);
            g.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            int interval = 5;
            int pointX = 35;

            RectangleF layoutRectangleRight = new RectangleF(135f, 5, 130f, 85f);
            //g.Graphics.DrawString(preprocessInfo.preprocessCode, font, brush, layoutRectangleRight);

            Rectangle destRect = new Rectangle(200, -15, image.Width, image.Height);
            g.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            //heightRight =image.Width-20;

            //layoutRectangleRight = new RectangleF(155, heightRight, 150f, 85f);
            //g.Graphics.DrawString(UserInfo.CompanyName, font, brush, layoutRectangleRight);

            heightRight += 20;

            layoutRectangleRight = new RectangleF(155, heightRight, 150f, 85f);
            g.Graphics.DrawString(UserInfo.RealName, font, brush, layoutRectangleRight);


            heightRight += 15;
            layoutRectangleRight = new RectangleF(155, heightRight, 150f, 85f);
            g.Graphics.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), font, brush, layoutRectangleRight);


            //门店名称

            RectangleF layoutRectangle = new RectangleF(pointX, height, 120f, 30f);


       
            //商品名称
            layoutRectangle = new RectangleF(pointX, 5, 180f, 30f);
            g.Graphics.DrawString(preprocessInfo.goodsName, font, brush, layoutRectangle);

            height += interval+20;
            //重量

            layoutRectangle = new RectangleF(pointX, height, 120f, 40f);
            g.Graphics.DrawString(preprocessInfo.packWeight.ToString("f2") + "斤", fontCu, brush, layoutRectangle);

            height += interval+13 ;

            Rectangle dest2Rect = new Rectangle(pointX, 80, image.Width, image.Height);
            g.Graphics.DrawImage(image, dest2Rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

            height = 80+image.Height-15;

            layoutRectangle = new RectangleF(pointX, height, 150f, 30f);
            g.Graphics.DrawString(preprocessInfo.preprocessCode, font, brush, layoutRectangle);

        }
    }
}
