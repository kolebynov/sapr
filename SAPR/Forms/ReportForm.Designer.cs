namespace SAPR.Forms
{
    partial class ReportForm
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
            this.m_gridPart = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_innerEdgesGrid = new System.Windows.Forms.DataGridView();
            this.m_outerEdgesGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.m_labelCutRate = new System.Windows.Forms.Label();
            this.m_labelPerformTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_innerEdgesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_outerEdgesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // m_gridPart
            // 
            this.m_gridPart.AllowUserToAddRows = false;
            this.m_gridPart.AllowUserToDeleteRows = false;
            this.m_gridPart.AllowUserToResizeRows = false;
            this.m_gridPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_gridPart.ColumnHeadersVisible = false;
            this.m_gridPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.m_gridPart.Location = new System.Drawing.Point(12, 27);
            this.m_gridPart.Name = "m_gridPart";
            this.m_gridPart.ReadOnly = true;
            this.m_gridPart.RowHeadersVisible = false;
            this.m_gridPart.Size = new System.Drawing.Size(410, 148);
            this.m_gridPart.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Куски, получившеся в результате выполнения алгоритма:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество ребер внутри сформированных кусков:";
            // 
            // m_innerEdgesGrid
            // 
            this.m_innerEdgesGrid.AllowUserToAddRows = false;
            this.m_innerEdgesGrid.AllowUserToDeleteRows = false;
            this.m_innerEdgesGrid.AllowUserToResizeRows = false;
            this.m_innerEdgesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_innerEdgesGrid.Location = new System.Drawing.Point(15, 207);
            this.m_innerEdgesGrid.Name = "m_innerEdgesGrid";
            this.m_innerEdgesGrid.ReadOnly = true;
            this.m_innerEdgesGrid.RowHeadersVisible = false;
            this.m_innerEdgesGrid.Size = new System.Drawing.Size(407, 60);
            this.m_innerEdgesGrid.TabIndex = 3;
            // 
            // m_outerEdgesGrid
            // 
            this.m_outerEdgesGrid.AllowUserToAddRows = false;
            this.m_outerEdgesGrid.AllowUserToDeleteRows = false;
            this.m_outerEdgesGrid.AllowUserToResizeRows = false;
            this.m_outerEdgesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_outerEdgesGrid.Location = new System.Drawing.Point(12, 301);
            this.m_outerEdgesGrid.Name = "m_outerEdgesGrid";
            this.m_outerEdgesGrid.ReadOnly = true;
            this.m_outerEdgesGrid.RowHeadersVisible = false;
            this.m_outerEdgesGrid.Size = new System.Drawing.Size(407, 60);
            this.m_outerEdgesGrid.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Количество внешних связей между кусками:";
            // 
            // m_labelCutRate
            // 
            this.m_labelCutRate.AutoSize = true;
            this.m_labelCutRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_labelCutRate.Location = new System.Drawing.Point(12, 373);
            this.m_labelCutRate.Name = "m_labelCutRate";
            this.m_labelCutRate.Size = new System.Drawing.Size(231, 15);
            this.m_labelCutRate.TabIndex = 6;
            this.m_labelCutRate.Text = "Коэффициент разрезания графа: G = ";
            // 
            // m_labelPerformTime
            // 
            this.m_labelPerformTime.AutoSize = true;
            this.m_labelPerformTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_labelPerformTime.Location = new System.Drawing.Point(12, 396);
            this.m_labelPerformTime.Name = "m_labelPerformTime";
            this.m_labelPerformTime.Size = new System.Drawing.Size(0, 15);
            this.m_labelPerformTime.TabIndex = 7;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 420);
            this.Controls.Add(this.m_labelPerformTime);
            this.Controls.Add(this.m_labelCutRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_outerEdgesGrid);
            this.Controls.Add(this.m_innerEdgesGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_gridPart);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2000, 459);
            this.MinimumSize = new System.Drawing.Size(0, 459);
            this.Name = "ReportForm";
            this.Text = "Отчет";
            this.Resize += new System.EventHandler(this.ReportForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.m_gridPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_innerEdgesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_outerEdgesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView m_gridPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView m_innerEdgesGrid;
        private System.Windows.Forms.DataGridView m_outerEdgesGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label m_labelCutRate;
        private System.Windows.Forms.Label m_labelPerformTime;
    }
}