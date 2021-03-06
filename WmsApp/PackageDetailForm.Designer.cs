﻿namespace WmsApp
{
    partial class PackageDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbStore = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.tbPackageCode = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.packageCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skuCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outboundTaskCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageSplit1 = new Wms.Controls.Pager.PageSplit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.cbStore);
            this.groupBox1.Controls.Add(this.cbStatus);
            this.groupBox1.Controls.Add(this.tbPackageCode);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.dtBegin);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(927, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(708, 51);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "导出";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbStore
            // 
            this.cbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Items.AddRange(new object[] {
            "请选择门店"});
            this.cbStore.Location = new System.Drawing.Point(372, 14);
            this.cbStore.Name = "cbStore";
            this.cbStore.Size = new System.Drawing.Size(141, 24);
            this.cbStore.TabIndex = 4;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "请选择",
            "新建",
            "已包装",
            "已分拣",
            "已发运",
            "作废"});
            this.cbStatus.Location = new System.Drawing.Point(594, 11);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(98, 24);
            this.cbStatus.TabIndex = 4;
            // 
            // tbPackageCode
            // 
            this.tbPackageCode.Location = new System.Drawing.Point(113, 51);
            this.tbPackageCode.Name = "tbPackageCode";
            this.tbPackageCode.Size = new System.Drawing.Size(141, 26);
            this.tbPackageCode.TabIndex = 3;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(372, 46);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(141, 26);
            this.tbName.TabIndex = 3;
            // 
            // dtBegin
            // 
            this.dtBegin.CustomFormat = "yyyy-MM-dd";
            this.dtBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBegin.Location = new System.Drawing.Point(113, 19);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(137, 26);
            this.dtBegin.TabIndex = 2;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(579, 51);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "包装编号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "门店:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "状态:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "商品编码(名称):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "发货日期:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1219, 315);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "明细";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column13,
            this.packageCode,
            this.id,
            this.boxCode,
            this.status,
            this.weight,
            this.statusDes,
            this.skuCode,
            this.goodsName,
            this.modelNum,
            this.goodsUnit,
            this.createUser,
            this.createTime,
            this.outboundTaskCode,
            this.storedName,
            this.deliveryDate,
            this.updateTime,
            this.updateUser,
            this.warehouseName});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1213, 290);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // Column12
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column12.HeaderText = "重打签";
            this.Column12.Name = "Column12";
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column12.Text = "重打签";
            this.Column12.UseColumnTextForButtonValue = true;
            this.Column12.Width = 75;
            // 
            // Column13
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            this.Column13.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column13.HeaderText = "作废";
            this.Column13.Name = "Column13";
            this.Column13.Text = "作废";
            this.Column13.UseColumnTextForButtonValue = true;
            this.Column13.Width = 41;
            // 
            // packageCode
            // 
            this.packageCode.DataPropertyName = "packageCode";
            this.packageCode.HeaderText = "包装编码";
            this.packageCode.Name = "packageCode";
            this.packageCode.ReadOnly = true;
            this.packageCode.Width = 75;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 49;
            // 
            // boxCode
            // 
            this.boxCode.DataPropertyName = "boxCode";
            this.boxCode.HeaderText = "箱号";
            this.boxCode.Name = "boxCode";
            this.boxCode.ReadOnly = true;
            this.boxCode.Width = 60;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "status";
            this.status.Name = "status";
            this.status.Visible = false;
            this.status.Width = 81;
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            this.weight.HeaderText = "重量";
            this.weight.Name = "weight";
            this.weight.Width = 60;
            // 
            // statusDes
            // 
            this.statusDes.DataPropertyName = "statusDes";
            this.statusDes.HeaderText = "状态";
            this.statusDes.Name = "statusDes";
            this.statusDes.ReadOnly = true;
            this.statusDes.Width = 60;
            // 
            // skuCode
            // 
            this.skuCode.DataPropertyName = "skuCode";
            this.skuCode.HeaderText = "商品编码";
            this.skuCode.Name = "skuCode";
            this.skuCode.ReadOnly = true;
            this.skuCode.Width = 75;
            // 
            // goodsName
            // 
            this.goodsName.DataPropertyName = "goodsName";
            this.goodsName.HeaderText = "商品名称";
            this.goodsName.Name = "goodsName";
            this.goodsName.ReadOnly = true;
            this.goodsName.Width = 75;
            // 
            // modelNum
            // 
            this.modelNum.DataPropertyName = "modelNum";
            this.modelNum.HeaderText = "规格";
            this.modelNum.Name = "modelNum";
            this.modelNum.ReadOnly = true;
            this.modelNum.Width = 60;
            // 
            // goodsUnit
            // 
            this.goodsUnit.DataPropertyName = "goodsUnit";
            this.goodsUnit.HeaderText = "单位";
            this.goodsUnit.Name = "goodsUnit";
            this.goodsUnit.ReadOnly = true;
            this.goodsUnit.Width = 60;
            // 
            // createUser
            // 
            this.createUser.DataPropertyName = "createUser";
            this.createUser.HeaderText = "包装人员";
            this.createUser.Name = "createUser";
            this.createUser.ReadOnly = true;
            this.createUser.Width = 75;
            // 
            // createTime
            // 
            this.createTime.DataPropertyName = "createTime";
            this.createTime.HeaderText = "包装时间";
            this.createTime.Name = "createTime";
            this.createTime.ReadOnly = true;
            this.createTime.Width = 75;
            // 
            // outboundTaskCode
            // 
            this.outboundTaskCode.DataPropertyName = "outboundTaskCode";
            this.outboundTaskCode.HeaderText = "订单号";
            this.outboundTaskCode.Name = "outboundTaskCode";
            this.outboundTaskCode.ReadOnly = true;
            this.outboundTaskCode.Width = 75;
            // 
            // storedName
            // 
            this.storedName.DataPropertyName = "storedName";
            this.storedName.HeaderText = "商户名称";
            this.storedName.Name = "storedName";
            this.storedName.ReadOnly = true;
            this.storedName.Width = 75;
            // 
            // deliveryDate
            // 
            this.deliveryDate.DataPropertyName = "deliveryDate";
            this.deliveryDate.HeaderText = "配送日期";
            this.deliveryDate.Name = "deliveryDate";
            this.deliveryDate.ReadOnly = true;
            this.deliveryDate.Width = 75;
            // 
            // updateTime
            // 
            this.updateTime.DataPropertyName = "updateTime";
            this.updateTime.HeaderText = "状态更新时间";
            this.updateTime.Name = "updateTime";
            this.updateTime.ReadOnly = true;
            this.updateTime.Width = 89;
            // 
            // updateUser
            // 
            this.updateUser.DataPropertyName = "updateUser";
            this.updateUser.HeaderText = "状态更新人";
            this.updateUser.Name = "updateUser";
            this.updateUser.ReadOnly = true;
            this.updateUser.Width = 89;
            // 
            // warehouseName
            // 
            this.warehouseName.DataPropertyName = "warehouseName";
            this.warehouseName.HeaderText = "仓库名称";
            this.warehouseName.Name = "warehouseName";
            this.warehouseName.Width = 75;
            // 
            // pageSplit1
            // 
            this.pageSplit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pageSplit1.BackColor = System.Drawing.Color.LightGray;
            this.pageSplit1.Description = "";
            this.pageSplit1.Location = new System.Drawing.Point(15, 417);
            this.pageSplit1.Margin = new System.Windows.Forms.Padding(2);
            this.pageSplit1.Name = "pageSplit1";
            this.pageSplit1.PageCount = 1;
            this.pageSplit1.PageNo = 1;
            this.pageSplit1.Size = new System.Drawing.Size(735, 39);
            this.pageSplit1.TabIndex = 1;
            this.pageSplit1.PageChanged += new System.EventHandler(this.pageSplit1_PageChanged);
            // 
            // PackageDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 467);
            this.Controls.Add(this.pageSplit1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PackageDetailForm";
            this.Text = "包裹明细查询";
            this.Load += new System.EventHandler(this.PackageTaskForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStore;
        private System.Windows.Forms.TextBox tbPackageCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Wms.Controls.Pager.PageSplit pageSplit1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridViewButtonColumn Column12;
        private System.Windows.Forms.DataGridViewButtonColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn skuCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn createUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn outboundTaskCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn storedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseName;
    }
}