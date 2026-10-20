namespace StoreLinqApp
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.GroupBox grpAggregates;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label lblAvg;
        private System.Windows.Forms.Label lblMinMax;
        private System.Windows.Forms.Label lblAggregate;
        private System.Windows.Forms.Button btnCalcAggregates;
        private System.Windows.Forms.Button btnExceptOnlineOnly;
        private System.Windows.Forms.Button btnIntersectBoth;
        private System.Windows.Forms.Button btnUnionAllUnique;
        private System.Windows.Forms.Button btnConcatDistinct;
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
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.grpAggregates = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.lblAvg = new System.Windows.Forms.Label();
            this.lblMinMax = new System.Windows.Forms.Label();
            this.lblAggregate = new System.Windows.Forms.Label();
            this.btnCalcAggregates = new System.Windows.Forms.Button();
            this.btnExceptOnlineOnly = new System.Windows.Forms.Button();
            this.btnIntersectBoth = new System.Windows.Forms.Button();
            this.btnUnionAllUnique = new System.Windows.Forms.Button();
            this.btnConcatDistinct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.grpAggregates.SuspendLayout();
            this.SuspendLayout();
            this.grpAggregates.Controls.Add(this.lblCount);
            this.grpAggregates.Controls.Add(this.lblSum);
            this.grpAggregates.Controls.Add(this.lblAvg);
            this.grpAggregates.Controls.Add(this.lblMinMax);
            this.grpAggregates.Controls.Add(this.lblAggregate);
            this.grpAggregates.Location = new System.Drawing.Point(15, 15);
            this.grpAggregates.Name = "grpAggregates";
            this.grpAggregates.Size = new System.Drawing.Size(870, 165);
            this.grpAggregates.TabIndex = 0;
            this.grpAggregates.TabStop = false;
            this.grpAggregates.Text = "Агрегатные показатели (OnlineOrders)";
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(15, 28);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(60, 17);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Count():-";
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(15, 55);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(51, 17);
            this.lblSum.TabIndex = 1;
            this.lblSum.Text = "Sum():-";
            this.lblAvg.AutoSize = true;
            this.lblAvg.Location = new System.Drawing.Point(15, 82);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.Size = new System.Drawing.Size(74, 17);
            this.lblAvg.TabIndex = 2;
            this.lblAvg.Text = "Average():-";
            this.lblMinMax.AutoSize = true;
            this.lblMinMax.Location = new System.Drawing.Point(15, 109);
            this.lblMinMax.Name = "lblMinMax";
            this.lblMinMax.Size = new System.Drawing.Size(85, 17);
            this.lblMinMax.TabIndex = 3;
            this.lblMinMax.Text = "Min()/Max():-";
            this.lblAggregate.AutoSize = true;
            this.lblAggregate.Location = new System.Drawing.Point(15, 136);
            this.lblAggregate.Name = "lblAggregate";
            this.lblAggregate.Size = new System.Drawing.Size(88, 17);
            this.lblAggregate.TabIndex = 4;
            this.lblAggregate.Text = "Aggregate():-";
            this.btnCalcAggregates.Location = new System.Drawing.Point(15, 190);
            this.btnCalcAggregates.Name = "btnCalcAggregates";
            this.btnCalcAggregates.Size = new System.Drawing.Size(165, 42);
            this.btnCalcAggregates.TabIndex = 1;
            this.btnCalcAggregates.Text = "Агрегаты (Online)";
            this.btnCalcAggregates.UseVisualStyleBackColor = true;
            this.btnCalcAggregates.Click += new System.EventHandler(this.BtnCalcAggregates_Click);
            this.btnExceptOnlineOnly.Location = new System.Drawing.Point(190, 190);
            this.btnExceptOnlineOnly.Name = "btnExceptOnlineOnly";
            this.btnExceptOnlineOnly.Size = new System.Drawing.Size(165, 42);
            this.btnExceptOnlineOnly.TabIndex = 2;
            this.btnExceptOnlineOnly.Text = "Только онлайн (Except)";
            this.btnExceptOnlineOnly.UseVisualStyleBackColor = true;
            this.btnExceptOnlineOnly.Click += new System.EventHandler(this.BtnExceptOnlineOnly_Click);
            this.btnIntersectBoth.Location = new System.Drawing.Point(365, 190);
            this.btnIntersectBoth.Name = "btnIntersectBoth";
            this.btnIntersectBoth.Size = new System.Drawing.Size(165, 42);
            this.btnIntersectBoth.TabIndex = 3;
            this.btnIntersectBoth.Text = "Оба канала (Intersect)";
            this.btnIntersectBoth.UseVisualStyleBackColor = true;
            this.btnIntersectBoth.Click += new System.EventHandler(this.BtnIntersectBoth_Click);
            this.btnUnionAllUnique.Location = new System.Drawing.Point(540, 190);
            this.btnUnionAllUnique.Name = "btnUnionAllUnique";
            this.btnUnionAllUnique.Size = new System.Drawing.Size(165, 42);
            this.btnUnionAllUnique.TabIndex = 4;
            this.btnUnionAllUnique.Text = "Все уникальные (Union)";
            this.btnUnionAllUnique.UseVisualStyleBackColor = true;
            this.btnUnionAllUnique.Click += new System.EventHandler(this.BtnUnionAllUnique_Click);
            this.btnConcatDistinct.Location = new System.Drawing.Point(715, 190);
            this.btnConcatDistinct.Name = "btnConcatDistinct";
            this.btnConcatDistinct.Size = new System.Drawing.Size(170, 42);
            this.btnConcatDistinct.TabIndex = 5;
            this.btnConcatDistinct.Text = "Concat()+Distinct()";
            this.btnConcatDistinct.UseVisualStyleBackColor = true;
            this.btnConcatDistinct.Click += new System.EventHandler(this.BtnConcatDistinct_Click);
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(15, 245);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(870, 320);
            this.dgvResults.TabIndex = 6;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 581);
            this.Controls.Add(this.grpAggregates);
            this.Controls.Add(this.btnCalcAggregates);
            this.Controls.Add(this.btnExceptOnlineOnly);
            this.Controls.Add(this.btnIntersectBoth);
            this.Controls.Add(this.btnUnionAllUnique);
            this.Controls.Add(this.btnConcatDistinct);
            this.Controls.Add(this.dgvResults);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQLite+LINQ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.grpAggregates.ResumeLayout(false);
            this.grpAggregates.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}