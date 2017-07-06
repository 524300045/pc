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
    public partial class PackageDetailForm : TabWindow
    {
        public PackageDetailForm()
        {
            InitializeComponent();
        }

        private void PackageTaskForm_Load(object sender, EventArgs e)
        {
            cbCust.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            int i = dataGridView1.Rows.Add();

            this.dataGridView1.Rows[i].Cells[3].Value = "10035229770001";
            this.dataGridView1.Rows[i].Cells[4].Value = "新建";
            this.dataGridView1.Rows[i].Cells[5].Value = "1234";
            this.dataGridView1.Rows[i].Cells[6].Value = "大白菜";
            this.dataGridView1.Rows[i].Cells[7].Value = "3";
            this.dataGridView1.Rows[i].Cells[8].Value = "斤";
            this.dataGridView1.Rows[i].Cells[9].Value = "15";
            this.dataGridView1.Rows[i].Cells[10].Value = "3";
            this.dataGridView1.Rows[i].Cells[11].Value = "3";
            this.dataGridView1.Rows[i].Cells[12].Value = "123";
            this.dataGridView1.Rows[i].Cells[13].Value = "123";
            this.dataGridView1.Rows[i].Cells[14].Value = "123";
            this.dataGridView1.Rows[i].Cells[15].Value = "123";
            this.dataGridView1.Rows[i].Cells[16].Value = "123";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    //这里可以编写你需要的任意关于按钮事件的操作~
                    WeightForm weightForm = new WeightForm();
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
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
