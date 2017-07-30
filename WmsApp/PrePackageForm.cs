using Sdbs.Wms.Controls.Pager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wms.Controls.Pager;
using WmsSDK;
using WmsSDK.Model;
using WmsSDK.Request;
using WmsSDK.Response;

namespace WmsApp
{
    public partial class PrePackageForm : TabWindow
    {

        private PaginatorDTO paginator;

        private SortableBindingList<Goods> sortList = null;

        List<Goods> goodsList;
        private IWMSClient client = null;
        public PrePackageForm()
        {
            InitializeComponent();
            client = new DefalutWMSClient();
        }

        private void PackageTaskForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;

            paginator = new PaginatorDTO { PageNo = 1, PageSize = 100 };
            BindDgv();
        }

        private void BindDgv()
        {
            GoodsRequest request = new GoodsRequest();
            request.PageIndex = paginator.PageNo;
            request.PageSize = paginator.PageSize;
            //request.skuCode= "%"+tbName.Text.Trim()+"%";
            if (!string.IsNullOrWhiteSpace(tbName.Text.Trim()))
            {
                request.goodsName = "%" + tbName.Text.Trim() + "%";
            }
            request.partnerCode = UserInfo.PartnerCode;
            request.isPreprocess = 1;

            GoodsResponse response = client.Execute(request);
           if (!response.IsError)
           {
               if (response.result == null)
               {
                   this.dataGridView1.DataSource = null;
               }
               else
               {
                   int recordCount = response.pageUtil.totalRow;
                   int totalPage;
                   if (recordCount % paginator.PageSize == 0)
                   {
                       totalPage = recordCount / paginator.PageSize;
                   }
                   else
                   {
                       totalPage = recordCount / paginator.PageSize + 1;
                   }
                   IPagedList<Goods> pageList = new PagedList<Goods>(response.result, recordCount, totalPage);
                   sortList = new SortableBindingList<Goods>(pageList.ContentList);
                   goodsList = response.result;
                   this.dataGridView1.DataSource = sortList;
                   pageSplit1.Description = "共查询到" + pageList.RecordCount + "条记录";
                   pageSplit1.PageCount = pageList.PageCount;
                   pageSplit1.PageNo = paginator.PageNo;
                   pageSplit1.DataBind();
               }
            
           }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {

                    string skucode = this.dataGridView1.CurrentRow.Cells["skuCode"].Value.ToString();
                    string goodsName = this.dataGridView1.CurrentRow.Cells["goodsName"].Value.ToString();
                   // int weighted =int.Parse(this.dataGridView1.CurrentRow.Cells["weighed"].Value.ToString());
                    //这里可以编写你需要的任意关于按钮事件的操作~
                    Goods goods = goodsList.Where(p => p.skuCode==skucode).FirstOrDefault();
                    PreWeightForm weightForm = new PreWeightForm(goods);
                    if (weightForm.ShowDialog()==DialogResult.OK)
                    {
                        
                    }
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            paginator.PageNo = 1;
            BindDgv();
        }

        private void pageSplit1_PageChanged(object sender, EventArgs e)
        {
            paginator.PageNo = pageSplit1.PageNo;
            BindDgv();
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnQuery_Click(null,null);
            }
        }


    }
}
