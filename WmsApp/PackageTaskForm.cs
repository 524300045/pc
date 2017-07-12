using Common;
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
    public partial class PackageTaskForm : TabWindow
    {

        private PaginatorDTO paginator;

        private SortableBindingList<PackTask> sortList = null;

        private IWMSClient client = null;
        public PackageTaskForm()
        {
            InitializeComponent();
            client = new DefalutWMSClient();
        }

        private void PackageTaskForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtBegin.Value = DateTime.Now.AddDays(-10);
                this.dtEnd.Value = DateTime.Now.AddDays(10);
                this.dataGridView1.AutoGenerateColumns = false;
                paginator = new PaginatorDTO { PageNo = 1, PageSize = 30 };
                cbStatus.SelectedIndex = 0;
                BindDgv();
            }
            catch (Exception ex)
            {
                LogHelper.Log("PackageTaskForm_Load" + ex.Message);
                MessageBox.Show(ex.Message);
            }
       
           
        }

        private void BindDgv()
        {
            PackTaskRequest request = new PackTaskRequest();
            request.PageIndex = paginator.PageNo;
            request.PageSize = paginator.PageSize;
            request.startTime = dtBegin.Value.ToString("yyyy-MM-dd HH:mm:ss");
            request.endTime = dtEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
           // request.deliveryDate = dtBegin.Value;
            request.skuCode = tbName.Text.Trim();
            //request.status = 1;

           PackTaskResponse  response=client.Execute(request);
           if (!response.IsError)
           {
               if (response.result==null)
               {
                   this.dataGridView1.DataSource = null;

                   return;
               }
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
               IPagedList<PackTask> pageList = new PagedList<PackTask>(response.result, recordCount, totalPage);
               sortList = new SortableBindingList<PackTask>(pageList.ContentList);
               this.dataGridView1.DataSource = sortList;
               pageSplit1.Description = "共查询到" + pageList.RecordCount + "条记录";
               pageSplit1.PageCount = pageList.PageCount;
               pageSplit1.PageNo = paginator.PageNo;
               pageSplit1.DataBind();
           }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    long id =long.Parse(this.dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                    string taskCode = this.dataGridView1.CurrentRow.Cells["PackTaskCode"].Value.ToString();
                    //这里可以编写你需要的任意关于按钮事件的操作~
                    WeightForm weightForm = new WeightForm(id,taskCode);
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


    }
}
