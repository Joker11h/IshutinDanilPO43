namespace EnterpriseLinqAnalytics
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvSalesDto = new System.Windows.Forms.DataGridView();
            this.panelTop1 = new System.Windows.Forms.Panel();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblChannel = new System.Windows.Forms.Label();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnShowGroupJoin = new System.Windows.Forms.Button();
            this.btnDeferredDemo = new System.Windows.Forms.Button();
            this.lblDeferredInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvGrouping = new System.Windows.Forms.DataGridView();
            this.txtAggregateAudit = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvSets = new System.Windows.Forms.DataGridView();
            this.panelTop3 = new System.Windows.Forms.Panel();
            this.btnExcept = new System.Windows.Forms.Button();
            this.btnIntersect = new System.Windows.Forms.Button();
            this.btnUnion = new System.Windows.Forms.Button();
            this.lblSetStatus = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvPaging = new System.Windows.Forms.DataGridView();
            this.panelTop4 = new System.Windows.Forms.Panel();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesDto)).BeginInit();
            this.panelTop1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrouping)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSets)).BeginInit();
            this.panelTop3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaging)).BeginInit();
            this.panelTop4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.SuspendLayout();

            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Controls.Add(this.tabPage3);
            this.tabControlMain.Controls.Add(this.tabPage4);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1080, 640);
            this.tabControlMain.TabIndex = 0;

            this.tabPage1.Controls.Add(this.dgvSalesDto);
            this.tabPage1.Controls.Add(this.panelTop1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1072, 608);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1. Реестр продаж и DTO";
            this.tabPage1.UseVisualStyleBackColor = true;

            this.dgvSalesDto.AllowUserToAddRows = false;
            this.dgvSalesDto.AllowUserToDeleteRows = false;
            this.dgvSalesDto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesDto.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalesDto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesDto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesDto.Location = new System.Drawing.Point(3, 98);
            this.dgvSalesDto.Name = "dgvSalesDto";
            this.dgvSalesDto.ReadOnly = true;
            this.dgvSalesDto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesDto.Size = new System.Drawing.Size(1066, 507);
            this.dgvSalesDto.TabIndex = 1;

            this.panelTop1.Controls.Add(this.lblCategory);
            this.panelTop1.Controls.Add(this.cmbCategory);
            this.panelTop1.Controls.Add(this.lblChannel);
            this.panelTop1.Controls.Add(this.cmbChannel);
            this.panelTop1.Controls.Add(this.btnApplyFilter);
            this.panelTop1.Controls.Add(this.btnResetFilter);
            this.panelTop1.Controls.Add(this.btnShowGroupJoin);
            this.panelTop1.Controls.Add(this.btnDeferredDemo);
            this.panelTop1.Controls.Add(this.lblDeferredInfo);
            this.panelTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop1.Location = new System.Drawing.Point(3, 3);
            this.panelTop1.Name = "panelTop1";
            this.panelTop1.Size = new System.Drawing.Size(1066, 95);
            this.panelTop1.TabIndex = 0;

            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(10, 15);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(74, 17);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Категория:";

            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(95, 12);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 25);
            this.cmbCategory.TabIndex = 1;

            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(290, 15);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(48, 17);
            this.lblChannel.TabIndex = 2;
            this.lblChannel.Text = "Канал:";

            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Location = new System.Drawing.Point(345, 12);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(130, 25);
            this.cmbChannel.TabIndex = 3;

            this.btnApplyFilter.Location = new System.Drawing.Point(490, 10);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(145, 30);
            this.btnApplyFilter.TabIndex = 4;
            this.btnApplyFilter.Text = "Применить фильтр";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);

            this.btnResetFilter.Location = new System.Drawing.Point(645, 10);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(95, 30);
            this.btnResetFilter.TabIndex = 5;
            this.btnResetFilter.Text = "Сбросить";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);

            this.btnShowGroupJoin.Location = new System.Drawing.Point(750, 10);
            this.btnShowGroupJoin.Name = "btnShowGroupJoin";
            this.btnShowGroupJoin.Size = new System.Drawing.Size(140, 30);
            this.btnShowGroupJoin.TabIndex = 6;
            this.btnShowGroupJoin.Text = "Показать GroupJoin";
            this.btnShowGroupJoin.UseVisualStyleBackColor = true;
            this.btnShowGroupJoin.Click += new System.EventHandler(this.btnShowGroupJoin_Click);

            this.btnDeferredDemo.Location = new System.Drawing.Point(900, 10);
            this.btnDeferredDemo.Name = "btnDeferredDemo";
            this.btnDeferredDemo.Size = new System.Drawing.Size(150, 30);
            this.btnDeferredDemo.TabIndex = 7;
            this.btnDeferredDemo.Text = "Тест Deferred vs ToList";
            this.btnDeferredDemo.UseVisualStyleBackColor = true;
            this.btnDeferredDemo.Click += new System.EventHandler(this.btnDeferredDemo_Click);

            this.lblDeferredInfo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblDeferredInfo.Location = new System.Drawing.Point(10, 48);
            this.lblDeferredInfo.Name = "lblDeferredInfo";
            this.lblDeferredInfo.Size = new System.Drawing.Size(1040, 42);
            this.lblDeferredInfo.TabIndex = 8;
            this.lblDeferredInfo.Text = "Нажмите \'Тест Deferred vs ToList\', чтобы добавить продажу в SQLite и сравнить отложенный запрос с ToList().";

            this.tabPage2.Controls.Add(this.dgvGrouping);
            this.tabPage2.Controls.Add(this.txtAggregateAudit);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1072, 608);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2. Группировка и Агрегация";
            this.tabPage2.UseVisualStyleBackColor = true;

            this.dgvGrouping.AllowUserToAddRows = false;
            this.dgvGrouping.AllowUserToDeleteRows = false;
            this.dgvGrouping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrouping.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrouping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrouping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrouping.Location = new System.Drawing.Point(3, 3);
            this.dgvGrouping.Name = "dgvGrouping";
            this.dgvGrouping.ReadOnly = true;
            this.dgvGrouping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrouping.Size = new System.Drawing.Size(1066, 442);
            this.dgvGrouping.TabIndex = 0;

            this.txtAggregateAudit.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.txtAggregateAudit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtAggregateAudit.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtAggregateAudit.Location = new System.Drawing.Point(3, 445);
            this.txtAggregateAudit.Multiline = true;
            this.txtAggregateAudit.Name = "txtAggregateAudit";
            this.txtAggregateAudit.ReadOnly = true;
            this.txtAggregateAudit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAggregateAudit.Size = new System.Drawing.Size(1066, 160);
            this.txtAggregateAudit.TabIndex = 1;

            this.tabPage3.Controls.Add(this.dgvSets);
            this.tabPage3.Controls.Add(this.panelTop3);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1072, 608);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3. Анализ каналов (Множества)";
            this.tabPage3.UseVisualStyleBackColor = true;

            this.dgvSets.AllowUserToAddRows = false;
            this.dgvSets.AllowUserToDeleteRows = false;
            this.dgvSets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSets.BackgroundColor = System.Drawing.Color.White;
            this.dgvSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSets.Location = new System.Drawing.Point(3, 58);
            this.dgvSets.Name = "dgvSets";
            this.dgvSets.ReadOnly = true;
            this.dgvSets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSets.Size = new System.Drawing.Size(1066, 547);
            this.dgvSets.TabIndex = 1;

            this.panelTop3.Controls.Add(this.btnExcept);
            this.panelTop3.Controls.Add(this.btnIntersect);
            this.panelTop3.Controls.Add(this.btnUnion);
            this.panelTop3.Controls.Add(this.lblSetStatus);
            this.panelTop3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop3.Location = new System.Drawing.Point(3, 3);
            this.panelTop3.Name = "panelTop3";
            this.panelTop3.Size = new System.Drawing.Size(1066, 55);
            this.panelTop3.TabIndex = 0;

            this.btnExcept.Location = new System.Drawing.Point(10, 12);
            this.btnExcept.Name = "btnExcept";
            this.btnExcept.Size = new System.Drawing.Size(180, 32);
            this.btnExcept.TabIndex = 0;
            this.btnExcept.Text = "Online Only (Except)";
            this.btnExcept.UseVisualStyleBackColor = true;
            this.btnExcept.Click += new System.EventHandler(this.btnExcept_Click);

            this.btnIntersect.Location = new System.Drawing.Point(200, 12);
            this.btnIntersect.Name = "btnIntersect";
            this.btnIntersect.Size = new System.Drawing.Size(190, 32);
            this.btnIntersect.TabIndex = 1;
            this.btnIntersect.Text = "Общие товары (Intersect)";
            this.btnIntersect.UseVisualStyleBackColor = true;
            this.btnIntersect.Click += new System.EventHandler(this.btnIntersect_Click);

            this.btnUnion.Location = new System.Drawing.Point(400, 12);
            this.btnUnion.Name = "btnUnion";
            this.btnUnion.Size = new System.Drawing.Size(190, 32);
            this.btnUnion.TabIndex = 2;
            this.btnUnion.Text = "Все уникальные (Union)";
            this.btnUnion.UseVisualStyleBackColor = true;
            this.btnUnion.Click += new System.EventHandler(this.btnUnion_Click);

            this.lblSetStatus.AutoSize = true;
            this.lblSetStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSetStatus.Location = new System.Drawing.Point(605, 18);
            this.lblSetStatus.Name = "lblSetStatus";
            this.lblSetStatus.Size = new System.Drawing.Size(268, 17);
            this.lblSetStatus.TabIndex = 3;
            this.lblSetStatus.Text = "Выберите операцию над множествами";

            this.tabPage4.Controls.Add(this.dgvPaging);
            this.tabPage4.Controls.Add(this.panelTop4);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1072, 608);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "4. Постраничный просмотр (Paging)";
            this.tabPage4.UseVisualStyleBackColor = true;

            this.dgvPaging.AllowUserToAddRows = false;
            this.dgvPaging.AllowUserToDeleteRows = false;
            this.dgvPaging.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaging.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPaging.Location = new System.Drawing.Point(3, 58);
            this.dgvPaging.Name = "dgvPaging";
            this.dgvPaging.ReadOnly = true;
            this.dgvPaging.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaging.Size = new System.Drawing.Size(1066, 547);
            this.dgvPaging.TabIndex = 1;

            this.panelTop4.Controls.Add(this.btnPrevPage);
            this.panelTop4.Controls.Add(this.btnNextPage);
            this.panelTop4.Controls.Add(this.lblPageSize);
            this.panelTop4.Controls.Add(this.numPageSize);
            this.panelTop4.Controls.Add(this.lblPageInfo);
            this.panelTop4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop4.Location = new System.Drawing.Point(3, 3);
            this.panelTop4.Name = "panelTop4";
            this.panelTop4.Size = new System.Drawing.Size(1066, 55);
            this.panelTop4.TabIndex = 0;

            this.btnPrevPage.Location = new System.Drawing.Point(10, 12);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(100, 32);
            this.btnPrevPage.TabIndex = 0;
            this.btnPrevPage.Text = "◀ Назад";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);

            this.btnNextPage.Location = new System.Drawing.Point(120, 12);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(100, 32);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Text = "Вперед ▶";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);

            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(240, 18);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(118, 17);
            this.lblPageSize.TabIndex = 2;
            this.lblPageSize.Text = "Размер страницы:";

            this.numPageSize.Location = new System.Drawing.Point(365, 14);
            this.numPageSize.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numPageSize.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(70, 25);
            this.numPageSize.TabIndex = 3;
            this.numPageSize.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.numPageSize.ValueChanged += new System.EventHandler(this.numPageSize_ValueChanged);

            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPageInfo.Location = new System.Drawing.Point(455, 18);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(123, 19);
            this.lblPageInfo.TabIndex = 4;
            this.lblPageInfo.Text = "Страница 1 из 1";

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.Controls.Add(this.tabControlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Комплексный анализ данных и отчетность на LINQ в WinForms и SQLite";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesDto)).EndInit();
            this.panelTop1.ResumeLayout(false);
            this.panelTop1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrouping)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSets)).EndInit();
            this.panelTop3.ResumeLayout(false);
            this.panelTop3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaging)).EndInit();
            this.panelTop4.ResumeLayout(false);
            this.panelTop4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvSalesDto;
        private System.Windows.Forms.Panel panelTop1;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.Button btnShowGroupJoin;
        private System.Windows.Forms.Button btnDeferredDemo;
        private System.Windows.Forms.Label lblDeferredInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvGrouping;
        private System.Windows.Forms.TextBox txtAggregateAudit;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvSets;
        private System.Windows.Forms.Panel panelTop3;
        private System.Windows.Forms.Button btnExcept;
        private System.Windows.Forms.Button btnIntersect;
        private System.Windows.Forms.Button btnUnion;
        private System.Windows.Forms.Label lblSetStatus;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvPaging;
        private System.Windows.Forms.Panel panelTop4;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.NumericUpDown numPageSize;
        private System.Windows.Forms.Label lblPageInfo;
    }
}