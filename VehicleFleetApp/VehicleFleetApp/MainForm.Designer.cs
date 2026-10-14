namespace VehicleFleetApp
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox cmbVehicleType;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.NumericUpDown numPower;
        private System.Windows.Forms.CheckBox chkIsElectric;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstFleet;
        private System.Windows.Forms.Button btnCalculateTax;
        private System.Windows.Forms.Label lblTotalTax;
        private System.Windows.Forms.Button btnSaveStorable;

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblFleetTitle;

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
            grpInput = new GroupBox();
            lblType = new Label();
            cmbVehicleType = new ComboBox();
            lblModel = new Label();
            txtModel = new TextBox();
            lblPower = new Label();
            numPower = new NumericUpDown();
            chkIsElectric = new CheckBox();
            lblCapacity = new Label();
            numCapacity = new NumericUpDown();
            btnAdd = new Button();
            lblFleetTitle = new Label();
            lstFleet = new ListBox();
            btnCalculateTax = new Button();
            btnSaveStorable = new Button();
            lblTotalTax = new Label();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPower).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCapacity).BeginInit();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Controls.Add(lblType);
            grpInput.Controls.Add(cmbVehicleType);
            grpInput.Controls.Add(lblModel);
            grpInput.Controls.Add(txtModel);
            grpInput.Controls.Add(lblPower);
            grpInput.Controls.Add(numPower);
            grpInput.Controls.Add(chkIsElectric);
            grpInput.Controls.Add(lblCapacity);
            grpInput.Controls.Add(numCapacity);
            grpInput.Controls.Add(btnAdd);
            grpInput.Location = new Point(16, 14);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(680, 145);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Добавление транспортного средства";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(16, 30);
            lblType.Name = "lblType";
            lblType.Size = new Size(49, 15);
            lblType.TabIndex = 0;
            lblType.Text = "Тип ТС:";
            // 
            // cmbVehicleType
            // 
            cmbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehicleType.Location = new Point(110, 26);
            cmbVehicleType.Name = "cmbVehicleType";
            cmbVehicleType.Size = new Size(180, 23);
            cmbVehicleType.TabIndex = 1;
            cmbVehicleType.SelectedIndexChanged += cmbVehicleType_SelectedIndexChanged;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Location = new Point(16, 65);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(94, 15);
            lblModel.TabIndex = 2;
            lblModel.Text = "Марка/Модель:";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(110, 62);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(180, 23);
            txtModel.TabIndex = 2;
            // 
            // lblPower
            // 
            lblPower.AutoSize = true;
            lblPower.Location = new Point(16, 102);
            lblPower.Name = "lblPower";
            lblPower.Size = new Size(100, 15);
            lblPower.TabIndex = 3;
            lblPower.Text = "Мощность (л.с.):";
            // 
            // numPower
            // 
            numPower.Location = new Point(110, 99);
            numPower.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numPower.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPower.Name = "numPower";
            numPower.Size = new Size(180, 23);
            numPower.TabIndex = 3;
            numPower.Value = new decimal(new int[] { 150, 0, 0, 0 });
            // 
            // chkIsElectric
            // 
            chkIsElectric.AutoSize = true;
            chkIsElectric.Location = new Point(330, 28);
            chkIsElectric.Name = "chkIsElectric";
            chkIsElectric.Size = new Size(203, 19);
            chkIsElectric.TabIndex = 4;
            chkIsElectric.Text = "Электромобиль (ставка 5 р/л.с.)";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Location = new Point(330, 65);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(130, 15);
            lblCapacity.TabIndex = 5;
            lblCapacity.Text = "Грузоподъемность (т):";
            // 
            // numCapacity
            // 
            numCapacity.DecimalPlaces = 1;
            numCapacity.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numCapacity.Location = new Point(480, 62);
            numCapacity.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            numCapacity.Name = "numCapacity";
            numCapacity.Size = new Size(180, 23);
            numCapacity.TabIndex = 5;
            numCapacity.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(330, 96);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(330, 30);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Добавить в автопарк";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblFleetTitle
            // 
            lblFleetTitle.AutoSize = true;
            lblFleetTitle.Location = new Point(16, 170);
            lblFleetTitle.Name = "lblFleetTitle";
            lblFleetTitle.Size = new Size(185, 15);
            lblFleetTitle.TabIndex = 10;
            lblFleetTitle.Text = "Список транспорта в автопарке:";
            // 
            // lstFleet
            // 
            lstFleet.FormattingEnabled = true;
            lstFleet.Location = new Point(16, 190);
            lstFleet.Name = "lstFleet";
            lstFleet.Size = new Size(680, 184);
            lstFleet.TabIndex = 7;
            // 
            // btnCalculateTax
            // 
            btnCalculateTax.Location = new Point(16, 390);
            btnCalculateTax.Name = "btnCalculateTax";
            btnCalculateTax.Size = new Size(210, 35);
            btnCalculateTax.TabIndex = 8;
            btnCalculateTax.Text = "Рассчитать суммарный налог";
            btnCalculateTax.UseVisualStyleBackColor = true;
            btnCalculateTax.Click += btnCalculateTax_Click;
            // 
            // btnSaveStorable
            // 
            btnSaveStorable.Location = new Point(240, 390);
            btnSaveStorable.Name = "btnSaveStorable";
            btnSaveStorable.Size = new Size(220, 35);
            btnSaveStorable.TabIndex = 9;
            btnSaveStorable.Text = "Сохранить грузовики (IStorable)";
            btnSaveStorable.UseVisualStyleBackColor = true;
            btnSaveStorable.Click += btnSaveStorable_Click;
            // 
            // lblTotalTax
            // 
            lblTotalTax.AutoSize = true;
            lblTotalTax.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalTax.Location = new Point(475, 398);
            lblTotalTax.Name = "lblTotalTax";
            lblTotalTax.Size = new Size(208, 19);
            lblTotalTax.TabIndex = 0;
            lblTotalTax.Text = "Суммарный налог: 0,00 руб.";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 445);
            Controls.Add(lblTotalTax);
            Controls.Add(btnSaveStorable);
            Controls.Add(btnCalculateTax);
            Controls.Add(lstFleet);
            Controls.Add(lblFleetTitle);
            Controls.Add(grpInput);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Учет и управление объектами автопарка";
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPower).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}