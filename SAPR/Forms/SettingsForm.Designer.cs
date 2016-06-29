namespace SAPR.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_changeAlgFolderButton = new System.Windows.Forms.Button();
            this.m_algorithmsFolderText = new System.Windows.Forms.TextBox();
            this.m_verticesRadiusNumeric = new System.Windows.Forms.NumericUpDown();
            this.m_edgesWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_textColorButton = new SAPR.Classes.ButtonColor();
            this.m_bgColorButton = new SAPR.Classes.ButtonColor();
            this.m_edgesColorButton = new SAPR.Classes.ButtonColor();
            this.m_verticesColorButton = new SAPR.Classes.ButtonColor();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_buttonSave = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_verticesRadiusNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edgesWidthNumeric)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(436, 320);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_changeAlgFolderButton);
            this.tabPage1.Controls.Add(this.m_algorithmsFolderText);
            this.tabPage1.Controls.Add(this.m_verticesRadiusNumeric);
            this.tabPage1.Controls.Add(this.m_edgesWidthNumeric);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(428, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Общие";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // m_changeAlgFolderButton
            // 
            this.m_changeAlgFolderButton.Location = new System.Drawing.Point(349, 59);
            this.m_changeAlgFolderButton.Name = "m_changeAlgFolderButton";
            this.m_changeAlgFolderButton.Size = new System.Drawing.Size(73, 23);
            this.m_changeAlgFolderButton.TabIndex = 6;
            this.m_changeAlgFolderButton.Text = "Изменить";
            this.m_changeAlgFolderButton.UseVisualStyleBackColor = true;
            this.m_changeAlgFolderButton.Click += new System.EventHandler(this.m_ChangeAlgFolderClickHandler);
            // 
            // m_algorithmsFolderText
            // 
            this.m_algorithmsFolderText.Location = new System.Drawing.Point(148, 60);
            this.m_algorithmsFolderText.Name = "m_algorithmsFolderText";
            this.m_algorithmsFolderText.ReadOnly = true;
            this.m_algorithmsFolderText.Size = new System.Drawing.Size(195, 20);
            this.m_algorithmsFolderText.TabIndex = 5;
            this.m_algorithmsFolderText.Tag = "algorithms_folder";
            this.m_algorithmsFolderText.TextChanged += new System.EventHandler(this.m_ChangeValueHandler);
            // 
            // m_verticesRadiusNumeric
            // 
            this.m_verticesRadiusNumeric.Location = new System.Drawing.Point(148, 35);
            this.m_verticesRadiusNumeric.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.m_verticesRadiusNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_verticesRadiusNumeric.Name = "m_verticesRadiusNumeric";
            this.m_verticesRadiusNumeric.Size = new System.Drawing.Size(120, 20);
            this.m_verticesRadiusNumeric.TabIndex = 4;
            this.m_verticesRadiusNumeric.Tag = "vertices_radius";
            this.m_verticesRadiusNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_verticesRadiusNumeric.ValueChanged += new System.EventHandler(this.m_ChangeValueHandler);
            // 
            // m_edgesWidthNumeric
            // 
            this.m_edgesWidthNumeric.Location = new System.Drawing.Point(148, 10);
            this.m_edgesWidthNumeric.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.m_edgesWidthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_edgesWidthNumeric.Name = "m_edgesWidthNumeric";
            this.m_edgesWidthNumeric.Size = new System.Drawing.Size(120, 20);
            this.m_edgesWidthNumeric.TabIndex = 3;
            this.m_edgesWidthNumeric.Tag = "edges_width";
            this.m_edgesWidthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_edgesWidthNumeric.ValueChanged += new System.EventHandler(this.m_ChangeValueHandler);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "Папка расположения алгоритмов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Радиус вершин, px:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Толщина ребер, px:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_textColorButton);
            this.tabPage2.Controls.Add(this.m_bgColorButton);
            this.tabPage2.Controls.Add(this.m_edgesColorButton);
            this.tabPage2.Controls.Add(this.m_verticesColorButton);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(428, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Цвета";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // m_textColorButton
            // 
            this.m_textColorButton.Color = System.Drawing.Color.Black;
            this.m_textColorButton.Image = ((System.Drawing.Image)(resources.GetObject("m_textColorButton.Image")));
            this.m_textColorButton.Location = new System.Drawing.Point(341, 85);
            this.m_textColorButton.Name = "m_textColorButton";
            this.m_textColorButton.Size = new System.Drawing.Size(75, 23);
            this.m_textColorButton.TabIndex = 8;
            this.m_textColorButton.Tag = "vertices_text_color";
            this.m_textColorButton.UseVisualStyleBackColor = true;
            // 
            // m_bgColorButton
            // 
            this.m_bgColorButton.Color = System.Drawing.Color.Black;
            this.m_bgColorButton.Image = ((System.Drawing.Image)(resources.GetObject("m_bgColorButton.Image")));
            this.m_bgColorButton.Location = new System.Drawing.Point(341, 60);
            this.m_bgColorButton.Name = "m_bgColorButton";
            this.m_bgColorButton.Size = new System.Drawing.Size(75, 23);
            this.m_bgColorButton.TabIndex = 7;
            this.m_bgColorButton.Tag = "background_color";
            this.m_bgColorButton.UseVisualStyleBackColor = true;
            // 
            // m_edgesColorButton
            // 
            this.m_edgesColorButton.Color = System.Drawing.Color.Black;
            this.m_edgesColorButton.Image = ((System.Drawing.Image)(resources.GetObject("m_edgesColorButton.Image")));
            this.m_edgesColorButton.Location = new System.Drawing.Point(341, 35);
            this.m_edgesColorButton.Name = "m_edgesColorButton";
            this.m_edgesColorButton.Size = new System.Drawing.Size(75, 23);
            this.m_edgesColorButton.TabIndex = 6;
            this.m_edgesColorButton.Tag = "edges_color";
            this.m_edgesColorButton.UseVisualStyleBackColor = true;
            // 
            // m_verticesColorButton
            // 
            this.m_verticesColorButton.Color = System.Drawing.Color.Black;
            this.m_verticesColorButton.Image = ((System.Drawing.Image)(resources.GetObject("m_verticesColorButton.Image")));
            this.m_verticesColorButton.Location = new System.Drawing.Point(341, 10);
            this.m_verticesColorButton.Name = "m_verticesColorButton";
            this.m_verticesColorButton.Size = new System.Drawing.Size(75, 23);
            this.m_verticesColorButton.TabIndex = 5;
            this.m_verticesColorButton.Tag = "vertices_color";
            this.m_verticesColorButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(8, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Цвет текста над вершинами по умолчанию:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(8, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Цвет заднего фона:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(8, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Цвет ребер по умолчанию:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Цвет вершин по умолчанию:";
            // 
            // m_buttonSave
            // 
            this.m_buttonSave.Location = new System.Drawing.Point(15, 326);
            this.m_buttonSave.Name = "m_buttonSave";
            this.m_buttonSave.Size = new System.Drawing.Size(75, 23);
            this.m_buttonSave.TabIndex = 1;
            this.m_buttonSave.Text = "Сохранить";
            this.m_buttonSave.UseVisualStyleBackColor = true;
            this.m_buttonSave.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Location = new System.Drawing.Point(347, 326);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.m_buttonCancel.TabIndex = 2;
            this.m_buttonCancel.Text = "Отмена";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            this.m_buttonCancel.Click += new System.EventHandler(this.m_buttonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 354);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonSave);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_verticesRadiusNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edgesWidthNumeric)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_buttonSave;
        private System.Windows.Forms.Button m_buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown m_edgesWidthNumeric;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_algorithmsFolderText;
        private System.Windows.Forms.NumericUpDown m_verticesRadiusNumeric;
        private Classes.ButtonColor m_edgesColorButton;
        private Classes.ButtonColor m_verticesColorButton;
        private Classes.ButtonColor m_textColorButton;
        private Classes.ButtonColor m_bgColorButton;
        private System.Windows.Forms.Button m_changeAlgFolderButton;
    }
}