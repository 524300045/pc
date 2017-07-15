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
    public partial class PackageDetailForm : TabWindow
    {

        private PaginatorDTO paginator;

        private SortableBindingList<PackageDetailQuery> sortList = null;


        private IWMSClient client = null;

        public PackageDetailForm()
        {
            InitializeComponent();
            client = new DefalutWMSClient();
        }

        private void PackageTaskForm_Load(object sender, EventArgs e)
        {
            cbStore.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            this.dtBegin.Value = DateTime.Now.AddDays(-10);
            this.dtEnd.Value = DateTime.Now.AddDays(10);
            this.dataGridView1.AutoGenerateColumns = false;
            paginator = new PaginatorDTO { PageNo = 1, PageSize = 30 };

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    //这里可以编写你需要的任意关于按钮事件的操作~
                    if (column.Name == "Column13")
                    {
                        long id = long.Parse(this.dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                        //作废
                        PackageDelRequest delRequest = new PackageDelRequest();
                        delRequest.id = id;
                        delRequest.updateUser = UserInfo.UserName;
                        PackageDelResponse response = client.Execute(delRequest);
                        if (!response.IsError)
                        {
                            BindDgv();
                        }
                        else
                        {
                            MessageBox.Show("作废失败");
                        }
                    }
                    if (column.Name == "Column12")
                    {
                        //重打印

                    }
                }
            }
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                BindDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindDgv()
        {
            PackageDetailQueryRequest request = new PackageDetailQueryRequest();
            request.skuCode = tbName.Text.Trim();
            if (cbStore.SelectedValue != null)
            {
                request.storedCode = cbStore.SelectedValue.ToString();
            }

            request.packageCode = tbPackageCode.Text.Trim();
            request.startTime = dtBegin.Value.ToString("yyyy-MM-dd HH:mm:ss");
            request.endTime = dtEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
            request.PageIndex = paginator.PageNo;
            request.PageSize = paginator.PageSize;


            PackageDetailQueryResponse response = client.Execute(request);
            if (!response.IsError)
            {
                if (response.result == null)
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
                IPagedList<PackageDetailQuery> pageList = new PagedList<PackageDetailQuery>(response.result, recordCount, totalPage);
                sortList = new SortableBindingList<PackageDetailQuery>(pageList.ContentList);
                this.dataGridView1.DataSource = sortList;
                pageSplit1.Description = "共查询到" + pageList.RecordCount + "条记录";
                pageSplit1.PageCount = pageList.PageCount;
                pageSplit1.PageNo = paginator.PageNo;
                pageSplit1.DataBind();
            }
            else
            {

            }

        }
    }
}
