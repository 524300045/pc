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
using WmsSDK.Request;
using WmsSDK.Response;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace WmsApp
{
    public partial class WeightForm : TabWindow
    {
        private long packId;

        private string taskCode;

        private long curTaskDetailId = 0;

        private string curOutStockCode;

        private string curSkuCode;

        private decimal orderCount;

        private int standNum;


        private string processDes;

        private int orderNum;

        private  string curStoreName;

        private string curGoodsName;

        private string curUnit;

        private string curPackageCode;

        private IWMSClient client = null;

        public WeightForm()
        {
            InitializeComponent();
        }

        public WeightForm(long _packId,string _taskCode,decimal _orderCount,int _standNum,string _processDes,int _orderNum)
        {
            InitializeComponent();
            this.packId = _packId;
            this.taskCode = _taskCode;
            this.orderCount = _orderCount;
            standNum = _standNum;
            this.processDes = _processDes;
            this.orderNum = _orderNum;
            client = new DefalutWMSClient();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {

          

          this.DialogResult = DialogResult.Cancel;
        }

        private void WeightForm_Load(object sender, EventArgs e)
        {
            ClearForm();

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

                    lbProcess.Text = response.result.finishNum + "/"+orderNum +"  "+ (response.result.finishNum / orderNum).ToString() + "%";
                    lbStore.Text = response.result.storedName;
                    lbOrderWeight.Text = orderCount.ToString("f0");//订单总量
                    lbUpDown.Text = response.result.upPlanNum.ToString("f0") + response.result.goodsUnit + "--" + response.result.downPlanNum.ToString("f0") + response.result.goodsUnit;//上下限
                    lbPackNUM.Text = standNum.ToString();//标注包数
                    curTaskDetailId = response.result.id;//当前任务明细ID
                    curOutStockCode = response.result.outboundTaskCode;
                    curSkuCode = response.result.skuCode;

                    curStoreName = response.result.storedName;
                    curGoodsName = response.result.goodsName;
                    curUnit = response.result.goodsUnit;
                   
                }
                else
                {
                    MessageBox.Show("当前任务已经完成!");
                    curTaskDetailId = 0;
                    curOutStockCode = "";
                    curSkuCode = "";
                    ClearForm();
                    this.DialogResult = DialogResult.OK;
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
                   curPackageCode = response.result;
                   PrintDocument document = new PrintDocument();
                   Margins margins = new Margins(0x87, 20, 5, 20);
                   document.DefaultPageSettings.Margins = margins;
                   PrintPreviewDialog dialog = new PrintPreviewDialog();
                   document.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                   dialog.Document = document;
                   try
                   {
                       document.Print();
                   }
                   catch (Exception exception)
                   {
                       MessageBox.Show("打印异常" + exception);
                       document.PrintController.OnEndPrint(document, new PrintEventArgs());
                   }
                   //打印，加载下一个
                   ShowDetail();
               }
            }
        }



        public  void GetPrintPicture(Bitmap image, PrintPageEventArgs g)
        {
            int height = 5;
            Font font = new Font("宋体", 12f);
            Brush brush = new SolidBrush(Color.Black);
            g.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            int interval = 20;
            int pointX = 5;
            Rectangle destRect = new Rectangle(190, 10, image.Width, image.Height);
            g.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            height += 8;

            //门店名称
            RectangleF layoutRectangle = new RectangleF(pointX, height, 260f, 85f);
            g.Graphics.DrawString(curStoreName, font, brush, layoutRectangle);
           
            height += interval;
            //商品名称
            layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            g.Graphics.DrawString(curGoodsName, font, brush, layoutRectangle);

            height += interval;
            //重量
            string weight = (decimal.Parse(tbWeight.Text.Trim())*2).ToString("f0");
            layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            g.Graphics.DrawString(weight + curUnit, font, brush, layoutRectangle);

            height += interval;
            //条码
           // layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
         //   g.Graphics.DrawString("规格型号:", font, brush, layoutRectangle);
            Rectangle dest2Rect = new Rectangle(pointX, height, image.Width, image.Height);
            g.Graphics.DrawImage(image, dest2Rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.Graphics.DrawString("生产厂家:" , font, brush, layoutRectangle);


            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.Graphics.DrawString("启用时间:" , font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.Graphics.DrawString("资产价格:" , font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.Graphics.DrawString("保管单位:" , font, brush, layoutRectangle);

            ////height += interval;
            //layoutRectangle = new RectangleF(pointX + 150, height, 230f, 85f);
            //g.Graphics.DrawString("保管人:" , font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.Graphics.DrawString("存放地点:" , font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 240f, 85f);
            //g.Graphics.DrawString("备    注:" , font, brush, layoutRectangle);

        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e) //触发打印事件
        {
            Bitmap bt = CreateQRCode(curPackageCode);
            GetPrintPicture(bt, e);
        }

        public static Bitmap CreateQRCode(string asset)
        {
            EncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 120,
                Height = 120
            };
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            return writer.Write(asset);
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
