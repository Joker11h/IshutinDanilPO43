namespace CorpFleetAnalytics
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
            this.txtOopOutputTab1 = new System.Windows.Forms.TextBox();
            this.btnEqualsTab1 = new System.Windows.Forms.Button();
            this.btnExportTab1 = new System.Windows.Forms.Button();
            this.btnSortTab1 = new System.Windows.Forms.Button();
            this.btnCloneTab1 = new System.Windows.Forms.Button();
            this.lstVehiclesTab1 = new System.Windows.Forms.ListBox();
            this.grpInputTab1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteTab1 = new System.Windows.Forms.Button();
            this.btnAddTab1 = new System.Windows.Forms.Button();
            this.numExtraTab1 = new System.Windows.Forms.NumericUpDown();
            this.lblExtraTab1 = new System.Windows.Forms.Label();
            this.numPriceTab1 = new System.Windows.Forms.NumericUpDown();
            this.lblPriceTab1 = new System.Windows.Forms.Label();
            this.numPowerTab1 = new System.Windows.Forms.NumericUpDown();
            this.lblPowerTab1 = new System.Windows.Forms.Label();
            this.cmbTypeTab1 = new System.Windows.Forms.ComboBox();
            this.lblTypeTab1 = new System.Windows.Forms.Label();
            this.txtModelTab1 = new System.Windows.Forms.TextBox();
            this.lblModelTab1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblQuantifiersTab2 = new System.Windows.Forms.Label();
            this.dgvDtoTab2 = new System.Windows.Forms.DataGridView();
            this.grpFilterTab2 = new System.Windows.Forms.GroupBox();
            this.btnResetLinqTab2 = new System.Windows.Forms.Button();
            this.btnApplyLinqTab2 = new System.Windows.Forms.Button();
            this.numMaxPriceTab2 = new System.Windows.Forms.NumericUpDown();
            this.lblMaxPriceTab2 = new System.Windows.Forms.Label();
            this.numMinPriceTab2 = new System.Windows.Forms.NumericUpDown();
            this.lblMinPriceTab2 = new System.Windows.Forms.Label();
            this.txtSearchTab2 = new System.Windows.Forms.TextBox();
            this.lblSearchTab2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtAggregateSummaryTab3 = new System.Windows.Forms.TextBox();
            this.lblAggTab3 = new System.Windows.Forms.Label();
            this.grpSetsTab3 = new System.Windows.Forms.GroupBox();
            this.lstSetsTab3 = new System.Windows.Forms.ListBox();
            this.btnUnionTab3 = new System.Windows.Forms.Button();
            this.btnExceptTab3 = new System.Windows.Forms.Button();
            this.btnIntersectTab3 = new System.Windows.Forms.Button();
            this.dgvGroupsTab3 = new System.Windows.Forms.DataGridView();
            this.lblGroupsTab3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grpEventsTab4 = new System.Windows.Forms.GroupBox();
            this.lstEventsTab4 = new System.Windows.Forms.ListBox();
            this.grpPageTab4 = new System.Windows.Forms.GroupBox();
            this.dgvPageTab4 = new System.Windows.Forms.DataGridView();
            this.btnClosureTab4 = new System.Windows.Forms.Button();
            this.lblPageInfoTab4 = new System.Windows.Forms.Label();
            this.btnNextPageTab4 = new System.Windows.Forms.Button();
            this.btnPrevPageTab4 = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpInputTab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExtraTab1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceTab1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPowerTab1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtoTab2)).BeginInit();
            this.grpFilterTab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPriceTab2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPriceTab2)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.grpSetsTab3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupsTab3)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.grpEventsTab4.SuspendLayout();
            this.grpPageTab4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPageTab4)).BeginInit();
            this.SuspendLayout();

            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Controls.Add(this.tabPage3);
            this.tabControlMain.Controls.Add(this.tabPage4);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1164, 721);
            this.tabControlMain.TabIndex = 0;

            this.tabPage1.Controls.Add(this.txtOopOutputTab1);
            this.tabPage1.Controls.Add(this.btnEqualsTab1);
            this.tabPage1.Controls.Add(this.btnExportTab1);
            this.tabPage1.Controls.Add(this.btnSortTab1);
            this.tabPage1.Controls.Add(this.btnCloneTab1);
            this.tabPage1.Controls.Add(this.lstVehiclesTab1);
            this.tabPage1.Controls.Add(this.grpInputTab1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1156, 688);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1. Реестр ТС и ООП-Модель";
            this.tabPage1.UseVisualStyleBackColor = true;

            this.txtOopOutputTab1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOopOutputTab1.Location = new System.Drawing.Point(15, 480);
            this.txtOopOutputTab1.Multiline = true;
            this.txtOopOutputTab1.Name = "txtOopOutputTab1";
            this.txtOopOutputTab1.ReadOnly = true;
            this.txtOopOutputTab1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOopOutputTab1.Size = new System.Drawing.Size(1120, 185);
            this.txtOopOutputTab1.TabIndex = 6;

            this.btnEqualsTab1.Location = new System.Drawing.Point(820, 425);
            this.btnEqualsTab1.Name = "btnEqualsTab1";
            this.btnEqualsTab1.Size = new System.Drawing.Size(315, 40);
            this.btnEqualsTab1.TabIndex = 5;
            this.btnEqualsTab1.Text = "Проверка Equals / GetHashCode и IStorable";
            this.btnEqualsTab1.UseVisualStyleBackColor = true;
            this.btnEqualsTab1.Click += new System.EventHandler(this.btnEqualsTab1_Click);

            this.btnExportTab1.Location = new System.Drawing.Point(545, 425);
            this.btnExportTab1.Name = "btnExportTab1";
            this.btnExportTab1.Size = new System.Drawing.Size(265, 40);
            this.btnExportTab1.TabIndex = 4;
            this.btnExportTab1.Text = "Явный метод IExportable (is pattern)";
            this.btnExportTab1.UseVisualStyleBackColor = true;
            this.btnExportTab1.Click += new System.EventHandler(this.btnExportTab1_Click);

            this.btnSortTab1.Location = new System.Drawing.Point(285, 425);
            this.btnSortTab1.Name = "btnSortTab1";
            this.btnSortTab1.Size = new System.Drawing.Size(250, 40);
            this.btnSortTab1.TabIndex = 3;
            this.btnSortTab1.Text = "Сортировка по цене (IComparable)";
            this.btnSortTab1.UseVisualStyleBackColor = true;
            this.btnSortTab1.Click += new System.EventHandler(this.btnSortTab1_Click);

            this.btnCloneTab1.Location = new System.Drawing.Point(15, 425);
            this.btnCloneTab1.Name = "btnCloneTab1";
            this.btnCloneTab1.Size = new System.Drawing.Size(260, 40);
            this.btnCloneTab1.TabIndex = 2;
            this.btnCloneTab1.Text = "Глубокое Клонирование (ICloneable)";
            this.btnCloneTab1.UseVisualStyleBackColor = true;
            this.btnCloneTab1.Click += new System.EventHandler(this.btnCloneTab1_Click);

            this.lstVehiclesTab1.FormattingEnabled = true;
            this.lstVehiclesTab1.HorizontalScrollbar = true;
            this.lstVehiclesTab1.ItemHeight = 20;
            this.lstVehiclesTab1.Location = new System.Drawing.Point(15, 120);
            this.lstVehiclesTab1.Name = "lstVehiclesTab1";
            this.lstVehiclesTab1.Size = new System.Drawing.Size(1120, 284);
            this.lstVehiclesTab1.TabIndex = 1;

            this.grpInputTab1.Controls.Add(this.btnDeleteTab1);
            this.grpInputTab1.Controls.Add(this.btnAddTab1);
            this.grpInputTab1.Controls.Add(this.numExtraTab1);
            this.grpInputTab1.Controls.Add(this.lblExtraTab1);
            this.grpInputTab1.Controls.Add(this.numPriceTab1);
            this.grpInputTab1.Controls.Add(this.lblPriceTab1);
            this.grpInputTab1.Controls.Add(this.numPowerTab1);
            this.grpInputTab1.Controls.Add(this.lblPowerTab1);
            this.grpInputTab1.Controls.Add(this.cmbTypeTab1);
            this.grpInputTab1.Controls.Add(this.lblTypeTab1);
            this.grpInputTab1.Controls.Add(this.txtModelTab1);
            this.grpInputTab1.Controls.Add(this.lblModelTab1);
            this.grpInputTab1.Location = new System.Drawing.Point(15, 12);
            this.grpInputTab1.Name = "grpInputTab1";
            this.grpInputTab1.Size = new System.Drawing.Size(1120, 95);
            this.grpInputTab1.TabIndex = 0;
            this.grpInputTab1.TabStop = false;
            this.grpInputTab1.Text = "Добавление нового ТС в БД SQLite и ООП-реестр";

            this.btnDeleteTab1.Location = new System.Drawing.Point(970, 44);
            this.btnDeleteTab1.Name = "btnDeleteTab1";
            this.btnDeleteTab1.Size = new System.Drawing.Size(135, 34);
            this.btnDeleteTab1.TabIndex = 11;
            this.btnDeleteTab1.Text = "Удалить выбранное";
            this.btnDeleteTab1.UseVisualStyleBackColor = true;
            this.btnDeleteTab1.Click += new System.EventHandler(this.btnDeleteTab1_Click);

            this.btnAddTab1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAddTab1.Location = new System.Drawing.Point(825, 44);
            this.btnAddTab1.Name = "btnAddTab1";
            this.btnAddTab1.Size = new System.Drawing.Size(135, 34);
            this.btnAddTab1.TabIndex = 10;
            this.btnAddTab1.Text = "Добавить ТС";
            this.btnAddTab1.UseVisualStyleBackColor = false;
            this.btnAddTab1.Click += new System.EventHandler(this.btnAddTab1_Click);

            this.numExtraTab1.Location = new System.Drawing.Point(685, 48);
            this.numExtraTab1.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            this.numExtraTab1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numExtraTab1.Name = "numExtraTab1";
            this.numExtraTab1.Size = new System.Drawing.Size(120, 27);
            this.numExtraTab1.TabIndex = 9;
            this.numExtraTab1.Value = new decimal(new int[] { 22, 0, 0, 0 });

            this.lblExtraTab1.AutoSize = true;
            this.lblExtraTab1.Location = new System.Drawing.Point(685, 25);
            this.lblExtraTab1.Name = "lblExtraTab1";
            this.lblExtraTab1.Size = new System.Drawing.Size(116, 20);
            this.lblExtraTab1.TabIndex = 8;
            this.lblExtraTab1.Text = "Тоннаж / Места:";

            this.numPriceTab1.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numPriceTab1.Location = new System.Drawing.Point(520, 48);
            this.numPriceTab1.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numPriceTab1.Minimum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numPriceTab1.Name = "numPriceTab1";
            this.numPriceTab1.Size = new System.Drawing.Size(150, 27);
            this.numPriceTab1.TabIndex = 7;
            this.numPriceTab1.Value = new decimal(new int[] { 8900000, 0, 0, 0 });

            this.lblPriceTab1.AutoSize = true;
            this.lblPriceTab1.Location = new System.Drawing.Point(520, 25);
            this.lblPriceTab1.Name = "lblPriceTab1";
            this.lblPriceTab1.Size = new System.Drawing.Size(142, 20);
            this.lblPriceTab1.TabIndex = 6;
            this.lblPriceTab1.Text = "Базовая цена (руб.):";

            this.numPowerTab1.Location = new System.Drawing.Point(395, 48);
            this.numPowerTab1.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.numPowerTab1.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numPowerTab1.Name = "numPowerTab1";
            this.numPowerTab1.Size = new System.Drawing.Size(110, 27);
            this.numPowerTab1.TabIndex = 5;
            this.numPowerTab1.Value = new decimal(new int[] { 420, 0, 0, 0 });

            this.lblPowerTab1.AutoSize = true;
            this.lblPowerTab1.Location = new System.Drawing.Point(395, 25);
            this.lblPowerTab1.Name = "lblPowerTab1";
            this.lblPowerTab1.Size = new System.Drawing.Size(119, 20);
            this.lblPowerTab1.TabIndex = 4;
            this.lblPowerTab1.Text = "Мощность (л.с.):";

            this.cmbTypeTab1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeTab1.FormattingEnabled = true;
            this.cmbTypeTab1.Items.AddRange(new object[] {
                "Грузовой (Cargo)",
                "Пассажирский (Passenger)"
            });
            this.cmbTypeTab1.Location = new System.Drawing.Point(210, 48);
            this.cmbTypeTab1.Name = "cmbTypeTab1";
            this.cmbTypeTab1.Size = new System.Drawing.Size(170, 28);
            this.cmbTypeTab1.TabIndex = 3;

            this.lblTypeTab1.AutoSize = true;
            this.lblTypeTab1.Location = new System.Drawing.Point(210, 25);
            this.lblTypeTab1.Name = "lblTypeTab1";
            this.lblTypeTab1.Size = new System.Drawing.Size(58, 20);
            this.lblTypeTab1.TabIndex = 2;
            this.lblTypeTab1.Text = "Тип ТС:";

            this.txtModelTab1.Location = new System.Drawing.Point(15, 48);
            this.txtModelTab1.Name = "txtModelTab1";
            this.txtModelTab1.Size = new System.Drawing.Size(180, 27);
            this.txtModelTab1.TabIndex = 1;
            this.txtModelTab1.Text = "KAMAZ-65802";

            this.lblModelTab1.AutoSize = true;
            this.lblModelTab1.Location = new System.Drawing.Point(15, 25);
            this.lblModelTab1.Name = "lblModelTab1";
            this.lblModelTab1.Size = new System.Drawing.Size(65, 20);
            this.lblModelTab1.TabIndex = 0;
            this.lblModelTab1.Text = "Модель:";

            this.tabPage2.Controls.Add(this.lblQuantifiersTab2);
            this.tabPage2.Controls.Add(this.dgvDtoTab2);
            this.tabPage2.Controls.Add(this.grpFilterTab2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1156, 688);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2. LINQ-Аналитика и DTO";
            this.tabPage2.UseVisualStyleBackColor = true;

            this.lblQuantifiersTab2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblQuantifiersTab2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblQuantifiersTab2.Location = new System.Drawing.Point(15, 610);
            this.lblQuantifiersTab2.Name = "lblQuantifiersTab2";
            this.lblQuantifiersTab2.Size = new System.Drawing.Size(1120, 50);
            this.lblQuantifiersTab2.TabIndex = 2;

            this.dgvDtoTab2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDtoTab2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDtoTab2.Location = new System.Drawing.Point(15, 115);
            this.dgvDtoTab2.Name = "dgvDtoTab2";
            this.dgvDtoTab2.ReadOnly = true;
            this.dgvDtoTab2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDtoTab2.Size = new System.Drawing.Size(1120, 480);
            this.dgvDtoTab2.TabIndex = 1;

            this.grpFilterTab2.Controls.Add(this.btnResetLinqTab2);
            this.grpFilterTab2.Controls.Add(this.btnApplyLinqTab2);
            this.grpFilterTab2.Controls.Add(this.numMaxPriceTab2);
            this.grpFilterTab2.Controls.Add(this.lblMaxPriceTab2);
            this.grpFilterTab2.Controls.Add(this.numMinPriceTab2);
            this.grpFilterTab2.Controls.Add(this.lblMinPriceTab2);
            this.grpFilterTab2.Controls.Add(this.txtSearchTab2);
            this.grpFilterTab2.Controls.Add(this.lblSearchTab2);
            this.grpFilterTab2.Location = new System.Drawing.Point(15, 12);
            this.grpFilterTab2.Name = "grpFilterTab2";
            this.grpFilterTab2.Size = new System.Drawing.Size(1120, 90);
            this.grpFilterTab2.TabIndex = 0;
            this.grpFilterTab2.TabStop = false;
            this.grpFilterTab2.Text = "Параметры фильтрации LINQ (Where), Проекции (Join/GroupJoin -> FleetReportDto) и Составной сортировки (OrderBy + ThenByDescending)";

            this.btnResetLinqTab2.Location = new System.Drawing.Point(825, 42);
            this.btnResetLinqTab2.Name = "btnResetLinqTab2";
            this.btnResetLinqTab2.Size = new System.Drawing.Size(160, 36);
            this.btnResetLinqTab2.TabIndex = 7;
            this.btnResetLinqTab2.Text = "Сбросить фильтры";
            this.btnResetLinqTab2.UseVisualStyleBackColor = true;
            this.btnResetLinqTab2.Click += new System.EventHandler(this.btnResetLinqTab2_Click);

            this.btnApplyLinqTab2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnApplyLinqTab2.Location = new System.Drawing.Point(590, 42);
            this.btnApplyLinqTab2.Name = "btnApplyLinqTab2";
            this.btnApplyLinqTab2.Size = new System.Drawing.Size(220, 36);
            this.btnApplyLinqTab2.TabIndex = 6;
            this.btnApplyLinqTab2.Text = "Выполнить LINQ-Конвейер";
            this.btnApplyLinqTab2.UseVisualStyleBackColor = false;
            this.btnApplyLinqTab2.Click += new System.EventHandler(this.btnApplyLinqTab2_Click);

            this.numMaxPriceTab2.Increment = new decimal(new int[] { 500000, 0, 0, 0 });
            this.numMaxPriceTab2.Location = new System.Drawing.Point(420, 48);
            this.numMaxPriceTab2.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numMaxPriceTab2.Name = "numMaxPriceTab2";
            this.numMaxPriceTab2.Size = new System.Drawing.Size(150, 27);
            this.numMaxPriceTab2.TabIndex = 5;
            this.numMaxPriceTab2.Value = new decimal(new int[] { 25000000, 0, 0, 0 });

            this.lblMaxPriceTab2.AutoSize = true;
            this.lblMaxPriceTab2.Location = new System.Drawing.Point(420, 25);
            this.lblMaxPriceTab2.Name = "lblMaxPriceTab2";
            this.lblMaxPriceTab2.Size = new System.Drawing.Size(126, 20);
            this.lblMaxPriceTab2.TabIndex = 4;
            this.lblMaxPriceTab2.Text = "Макс. цена (руб.):";

            this.numMinPriceTab2.Increment = new decimal(new int[] { 500000, 0, 0, 0 });
            this.numMinPriceTab2.Location = new System.Drawing.Point(255, 48);
            this.numMinPriceTab2.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numMinPriceTab2.Name = "numMinPriceTab2";
            this.numMinPriceTab2.Size = new System.Drawing.Size(150, 27);
            this.numMinPriceTab2.TabIndex = 3;

            this.lblMinPriceTab2.AutoSize = true;
            this.lblMinPriceTab2.Location = new System.Drawing.Point(255, 25);
            this.lblMinPriceTab2.Name = "lblMinPriceTab2";
            this.lblMinPriceTab2.Size = new System.Drawing.Size(120, 20);
            this.lblMinPriceTab2.TabIndex = 2;
            this.lblMinPriceTab2.Text = "Мин. цена (руб.):";

            this.txtSearchTab2.Location = new System.Drawing.Point(15, 48);
            this.txtSearchTab2.Name = "txtSearchTab2";
            this.txtSearchTab2.Size = new System.Drawing.Size(220, 27);
            this.txtSearchTab2.TabIndex = 1;

            this.lblSearchTab2.AutoSize = true;
            this.lblSearchTab2.Location = new System.Drawing.Point(15, 25);
            this.lblSearchTab2.Name = "lblSearchTab2";
            this.lblSearchTab2.Size = new System.Drawing.Size(198, 20);
            this.lblSearchTab2.TabIndex = 0;
            this.lblSearchTab2.Text = "Поиск по модели/категории:";

            this.tabPage3.Controls.Add(this.txtAggregateSummaryTab3);
            this.tabPage3.Controls.Add(this.lblAggTab3);
            this.tabPage3.Controls.Add(this.grpSetsTab3);
            this.tabPage3.Controls.Add(this.dgvGroupsTab3);
            this.tabPage3.Controls.Add(this.lblGroupsTab3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1156, 688);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3. Группировка, Агрегаты и Множества";
            this.tabPage3.UseVisualStyleBackColor = true;

            this.txtAggregateSummaryTab3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAggregateSummaryTab3.Location = new System.Drawing.Point(15, 540);
            this.txtAggregateSummaryTab3.Multiline = true;
            this.txtAggregateSummaryTab3.Name = "txtAggregateSummaryTab3";
            this.txtAggregateSummaryTab3.ReadOnly = true;
            this.txtAggregateSummaryTab3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAggregateSummaryTab3.Size = new System.Drawing.Size(1120, 125);
            this.txtAggregateSummaryTab3.TabIndex = 4;

            this.lblAggTab3.AutoSize = true;
            this.lblAggTab3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAggTab3.Location = new System.Drawing.Point(15, 515);
            this.lblAggTab3.Name = "lblAggTab3";
            this.lblAggTab3.Size = new System.Drawing.Size(555, 20);
            this.lblAggTab3.TabIndex = 3;
            this.lblAggTab3.Text = "Итоговая сводка предприятия (сформирована через LINQ Aggregate):";

            this.grpSetsTab3.Controls.Add(this.lstSetsTab3);
            this.grpSetsTab3.Controls.Add(this.btnUnionTab3);
            this.grpSetsTab3.Controls.Add(this.btnExceptTab3);
            this.grpSetsTab3.Controls.Add(this.btnIntersectTab3);
            this.grpSetsTab3.Location = new System.Drawing.Point(15, 275);
            this.grpSetsTab3.Name = "grpSetsTab3";
            this.grpSetsTab3.Size = new System.Drawing.Size(1120, 230);
            this.grpSetsTab3.TabIndex = 2;
            this.grpSetsTab3.TabStop = false;
            this.grpSetsTab3.Text = "Операции LINQ над множествами сервисных логов (\'Online\' vs \'Offline\' по переопределенным Equals/GetHashCode)";

            this.lstSetsTab3.FormattingEnabled = true;
            this.lstSetsTab3.ItemHeight = 20;
            this.lstSetsTab3.Location = new System.Drawing.Point(15, 75);
            this.lstSetsTab3.Name = "lstSetsTab3";
            this.lstSetsTab3.Size = new System.Drawing.Size(1085, 144);
            this.lstSetsTab3.TabIndex = 3;

            this.btnUnionTab3.Location = new System.Drawing.Point(725, 28);
            this.btnUnionTab3.Name = "btnUnionTab3";
            this.btnUnionTab3.Size = new System.Drawing.Size(375, 36);
            this.btnUnionTab3.TabIndex = 2;
            this.btnUnionTab3.Text = "Union (Все уникальные виды ТО)";
            this.btnUnionTab3.UseVisualStyleBackColor = true;
            this.btnUnionTab3.Click += new System.EventHandler(this.btnUnionTab3_Click);

            this.btnExceptTab3.Location = new System.Drawing.Point(370, 28);
            this.btnExceptTab3.Name = "btnExceptTab3";
            this.btnExceptTab3.Size = new System.Drawing.Size(340, 36);
            this.btnExceptTab3.TabIndex = 1;
            this.btnExceptTab3.Text = "Except (Только Online без Offline)";
            this.btnExceptTab3.UseVisualStyleBackColor = true;
            this.btnExceptTab3.Click += new System.EventHandler(this.btnExceptTab3_Click);

            this.btnIntersectTab3.Location = new System.Drawing.Point(15, 28);
            this.btnIntersectTab3.Name = "btnIntersectTab3";
            this.btnIntersectTab3.Size = new System.Drawing.Size(340, 36);
            this.btnIntersectTab3.TabIndex = 0;
            this.btnIntersectTab3.Text = "Intersect (Общие услуги Online и Offline)";
            this.btnIntersectTab3.UseVisualStyleBackColor = true;
            this.btnIntersectTab3.Click += new System.EventHandler(this.btnIntersectTab3_Click);

            this.dgvGroupsTab3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroupsTab3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupsTab3.Location = new System.Drawing.Point(15, 40);
            this.dgvGroupsTab3.Name = "dgvGroupsTab3";
            this.dgvGroupsTab3.ReadOnly = true;
            this.dgvGroupsTab3.Size = new System.Drawing.Size(1120, 220);
            this.dgvGroupsTab3.TabIndex = 1;

            this.lblGroupsTab3.AutoSize = true;
            this.lblGroupsTab3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGroupsTab3.Location = new System.Drawing.Point(15, 15);
            this.lblGroupsTab3.Name = "lblGroupsTab3";
            this.lblGroupsTab3.Size = new System.Drawing.Size(735, 20);
            this.lblGroupsTab3.TabIndex = 0;
            this.lblGroupsTab3.Text = "Группировка ТС по категориям (GroupBy) и вычисление агрегатов (Count, Sum, Average, Min, Max):";

            this.tabPage4.Controls.Add(this.grpEventsTab4);
            this.tabPage4.Controls.Add(this.grpPageTab4);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1156, 688);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "4. Постраничный просмотр и События";
            this.tabPage4.UseVisualStyleBackColor = true;

            this.grpEventsTab4.Controls.Add(this.lstEventsTab4);
            this.grpEventsTab4.Location = new System.Drawing.Point(15, 315);
            this.grpEventsTab4.Name = "grpEventsTab4";
            this.grpEventsTab4.Size = new System.Drawing.Size(1120, 350);
            this.grpEventsTab4.TabIndex = 1;
            this.grpEventsTab4.TabStop = false;
            this.grpEventsTab4.Text = "Журнал событий FleetManager.StatusChanged (подписка через лямбда-выражение и безопасный вызов ?.Invoke)";

            this.lstEventsTab4.FormattingEnabled = true;
            this.lstEventsTab4.HorizontalScrollbar = true;
            this.lstEventsTab4.ItemHeight = 20;
            this.lstEventsTab4.Location = new System.Drawing.Point(15, 30);
            this.lstEventsTab4.Name = "lstEventsTab4";
            this.lstEventsTab4.Size = new System.Drawing.Size(1085, 304);
            this.lstEventsTab4.TabIndex = 0;

            this.grpPageTab4.Controls.Add(this.dgvPageTab4);
            this.grpPageTab4.Controls.Add(this.btnClosureTab4);
            this.grpPageTab4.Controls.Add(this.lblPageInfoTab4);
            this.grpPageTab4.Controls.Add(this.btnNextPageTab4);
            this.grpPageTab4.Controls.Add(this.btnPrevPageTab4);
            this.grpPageTab4.Location = new System.Drawing.Point(15, 12);
            this.grpPageTab4.Name = "grpPageTab4";
            this.grpPageTab4.Size = new System.Drawing.Size(1120, 290);
            this.grpPageTab4.TabIndex = 0;
            this.grpPageTab4.TabStop = false;
            this.grpPageTab4.Text = "Постраничная навигация по реестру (LINQ Skip / Take)";

            this.dgvPageTab4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPageTab4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPageTab4.Location = new System.Drawing.Point(15, 75);
            this.dgvPageTab4.Name = "dgvPageTab4";
            this.dgvPageTab4.ReadOnly = true;
            this.dgvPageTab4.Size = new System.Drawing.Size(1085, 195);
            this.dgvPageTab4.TabIndex = 4;

            this.btnClosureTab4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClosureTab4.Location = new System.Drawing.Point(740, 28);
            this.btnClosureTab4.Name = "btnClosureTab4";
            this.btnClosureTab4.Size = new System.Drawing.Size(360, 36);
            this.btnClosureTab4.TabIndex = 3;
            this.btnClosureTab4.Text = "Выполнить расчет с Замыканием (Predicate + Func)";
            this.btnClosureTab4.UseVisualStyleBackColor = false;
            this.btnClosureTab4.Click += new System.EventHandler(this.btnClosureTab4_Click);

            this.lblPageInfoTab4.AutoSize = true;
            this.lblPageInfoTab4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPageInfoTab4.Location = new System.Drawing.Point(470, 36);
            this.lblPageInfoTab4.Name = "lblPageInfoTab4";
            this.lblPageInfoTab4.Size = new System.Drawing.Size(120, 23);
            this.lblPageInfoTab4.TabIndex = 2;
            this.lblPageInfoTab4.Text = "Страница 1";

            this.btnNextPageTab4.Location = new System.Drawing.Point(240, 28);
            this.btnNextPageTab4.Name = "btnNextPageTab4";
            this.btnNextPageTab4.Size = new System.Drawing.Size(210, 36);
            this.btnNextPageTab4.TabIndex = 1;
            this.btnNextPageTab4.Text = "Следующая страница >>";
            this.btnNextPageTab4.UseVisualStyleBackColor = true;
            this.btnNextPageTab4.Click += new System.EventHandler(this.btnNextPageTab4_Click);

            this.btnPrevPageTab4.Location = new System.Drawing.Point(15, 28);
            this.btnPrevPageTab4.Name = "btnPrevPageTab4";
            this.btnPrevPageTab4.Size = new System.Drawing.Size(210, 36);
            this.btnPrevPageTab4.TabIndex = 0;
            this.btnPrevPageTab4.Text = "<< Предыдущая страница";
            this.btnPrevPageTab4.UseVisualStyleBackColor = true;
            this.btnPrevPageTab4.Click += new System.EventHandler(this.btnPrevPageTab4_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 721);
            this.Controls.Add(this.tabControlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CorpFleet Analytics — Итоговая работа (ООП, Интерфейсы, Делегаты, LINQ, SQLite)";
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpInputTab1.ResumeLayout(false);
            this.grpInputTab1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExtraTab1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceTab1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPowerTab1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtoTab2)).EndInit();
            this.grpFilterTab2.ResumeLayout(false);
            this.grpFilterTab2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPriceTab2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPriceTab2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.grpSetsTab3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupsTab3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.grpEventsTab4.ResumeLayout(false);
            this.grpPageTab4.ResumeLayout(false);
            this.grpPageTab4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPageTab4)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtOopOutputTab1;
        private System.Windows.Forms.Button btnEqualsTab1;
        private System.Windows.Forms.Button btnExportTab1;
        private System.Windows.Forms.Button btnSortTab1;
        private System.Windows.Forms.Button btnCloneTab1;
        private System.Windows.Forms.ListBox lstVehiclesTab1;
        private System.Windows.Forms.GroupBox grpInputTab1;
        private System.Windows.Forms.Button btnDeleteTab1;
        private System.Windows.Forms.Button btnAddTab1;
        private System.Windows.Forms.NumericUpDown numExtraTab1;
        private System.Windows.Forms.Label lblExtraTab1;
        private System.Windows.Forms.NumericUpDown numPriceTab1;
        private System.Windows.Forms.Label lblPriceTab1;
        private System.Windows.Forms.NumericUpDown numPowerTab1;
        private System.Windows.Forms.Label lblPowerTab1;
        private System.Windows.Forms.ComboBox cmbTypeTab1;
        private System.Windows.Forms.Label lblTypeTab1;
        private System.Windows.Forms.TextBox txtModelTab1;
        private System.Windows.Forms.Label lblModelTab1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblQuantifiersTab2;
        private System.Windows.Forms.DataGridView dgvDtoTab2;
        private System.Windows.Forms.GroupBox grpFilterTab2;
        private System.Windows.Forms.Button btnResetLinqTab2;
        private System.Windows.Forms.Button btnApplyLinqTab2;
        private System.Windows.Forms.NumericUpDown numMaxPriceTab2;
        private System.Windows.Forms.Label lblMaxPriceTab2;
        private System.Windows.Forms.NumericUpDown numMinPriceTab2;
        private System.Windows.Forms.Label lblMinPriceTab2;
        private System.Windows.Forms.TextBox txtSearchTab2;
        private System.Windows.Forms.Label lblSearchTab2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtAggregateSummaryTab3;
        private System.Windows.Forms.Label lblAggTab3;
        private System.Windows.Forms.GroupBox grpSetsTab3;
        private System.Windows.Forms.ListBox lstSetsTab3;
        private System.Windows.Forms.Button btnUnionTab3;
        private System.Windows.Forms.Button btnExceptTab3;
        private System.Windows.Forms.Button btnIntersectTab3;
        private System.Windows.Forms.DataGridView dgvGroupsTab3;
        private System.Windows.Forms.Label lblGroupsTab3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox grpEventsTab4;
        private System.Windows.Forms.ListBox lstEventsTab4;
        private System.Windows.Forms.GroupBox grpPageTab4;
        private System.Windows.Forms.DataGridView dgvPageTab4;
        private System.Windows.Forms.Button btnClosureTab4;
        private System.Windows.Forms.Label lblPageInfoTab4;
        private System.Windows.Forms.Button btnNextPageTab4;
        private System.Windows.Forms.Button btnPrevPageTab4;
    }
}