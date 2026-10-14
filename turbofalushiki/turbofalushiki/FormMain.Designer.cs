namespace turbofalushiki
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            txtVersion = new TextBox();
            txtLicenseKey = new TextBox();
            numPrice = new NumericUpDown();
            numLicenseDays = new NumericUpDown();
            btnAdd = new Button();
            btnSort = new Button();
            btnClone = new Button();
            btnModifyClone = new Button();
            lstSoftware = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLicenseDays).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 233);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(100, 23);
            txtTitle.TabIndex = 0;
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(118, 233);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(100, 23);
            txtVersion.TabIndex = 1;
            // 
            // txtLicenseKey
            // 
            txtLicenseKey.Location = new Point(224, 233);
            txtLicenseKey.Name = "txtLicenseKey";
            txtLicenseKey.Size = new Size(100, 23);
            txtLicenseKey.TabIndex = 2;
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(12, 275);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(120, 23);
            numPrice.TabIndex = 3;
            // 
            // numLicenseDays
            // 
            numLicenseDays.Location = new Point(138, 275);
            numLicenseDays.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numLicenseDays.Name = "numLicenseDays";
            numLicenseDays.Size = new Size(120, 23);
            numLicenseDays.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 325);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSort
            // 
            btnSort.Location = new Point(93, 325);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(93, 23);
            btnSort.TabIndex = 6;
            btnSort.Text = "Сортировать";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // btnClone
            // 
            btnClone.Location = new Point(192, 325);
            btnClone.Name = "btnClone";
            btnClone.Size = new Size(89, 23);
            btnClone.TabIndex = 7;
            btnClone.Text = "Клонировать";
            btnClone.UseVisualStyleBackColor = true;
            btnClone.Click += btnClone_Click;
            // 
            // btnModifyClone
            // 
            btnModifyClone.Location = new Point(287, 325);
            btnModifyClone.Name = "btnModifyClone";
            btnModifyClone.Size = new Size(113, 23);
            btnModifyClone.TabIndex = 8;
            btnModifyClone.Text = "Модифицировать";
            btnModifyClone.UseVisualStyleBackColor = true;
            btnModifyClone.Click += btnClone_Click;
            // 
            // lstSoftware
            // 
            lstSoftware.FormattingEnabled = true;
            lstSoftware.Location = new Point(12, 12);
            lstSoftware.Name = "lstSoftware";
            lstSoftware.Size = new Size(471, 199);
            lstSoftware.TabIndex = 9;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 359);
            Controls.Add(lstSoftware);
            Controls.Add(btnModifyClone);
            Controls.Add(btnClone);
            Controls.Add(btnSort);
            Controls.Add(btnAdd);
            Controls.Add(numLicenseDays);
            Controls.Add(numPrice);
            Controls.Add(txtLicenseKey);
            Controls.Add(txtVersion);
            Controls.Add(txtTitle);
            Name = "FormMain";
            Text = "67";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLicenseDays).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtVersion;
        private TextBox txtLicenseKey;
        private NumericUpDown numPrice;
        private NumericUpDown numLicenseDays;
        private Button btnAdd;
        private Button btnSort;
        private Button btnClone;
        private Button btnModifyClone;
        private ListBox lstSoftware;
    }
}
