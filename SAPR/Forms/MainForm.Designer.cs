namespace SAPR.Forms
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripLeft = new System.Windows.Forms.ToolStrip();
            this.buttonSelection = new System.Windows.Forms.ToolStripButton();
            this.buttonVertex = new System.Windows.Forms.ToolStripButton();
            this.buttonEdge = new System.Windows.Forms.ToolStripButton();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.GLControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.toolStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAdjMatrix = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAlgorithms = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripLeft.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripLeft
            // 
            this.toolStripLeft.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStripLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripLeft.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSelection,
            this.buttonVertex,
            this.buttonEdge});
            this.toolStripLeft.Location = new System.Drawing.Point(0, 24);
            this.toolStripLeft.Name = "toolStripLeft";
            this.toolStripLeft.Size = new System.Drawing.Size(24, 343);
            this.toolStripLeft.TabIndex = 0;
            this.toolStripLeft.Text = "toolStrip1";
            this.toolStripLeft.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripLeft_ItemClicked);
            // 
            // buttonSelection
            // 
            this.buttonSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSelection.Image = global::SAPR.Properties.Resources.select;
            this.buttonSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSelection.Name = "buttonSelection";
            this.buttonSelection.Size = new System.Drawing.Size(21, 20);
            this.buttonSelection.Text = "Выделение";
            this.buttonSelection.Click += new System.EventHandler(this.buttonSelection_Click);
            // 
            // buttonVertex
            // 
            this.buttonVertex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonVertex.Image = global::SAPR.Properties.Resources.vertex;
            this.buttonVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonVertex.Name = "buttonVertex";
            this.buttonVertex.Size = new System.Drawing.Size(21, 20);
            this.buttonVertex.Text = "Поставить вершину";
            this.buttonVertex.Click += new System.EventHandler(this.buttonVertex_Click);
            // 
            // buttonEdge
            // 
            this.buttonEdge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEdge.Image = global::SAPR.Properties.Resources.edge;
            this.buttonEdge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEdge.Name = "buttonEdge";
            this.buttonEdge.Size = new System.Drawing.Size(21, 20);
            this.buttonEdge.Text = "Поставить ребро";
            this.buttonEdge.CheckedChanged += new System.EventHandler(this.buttonEdge_CheckedChanged);
            this.buttonEdge.Click += new System.EventHandler(this.buttonEdge_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // toolStripTop
            // 
            this.toolStripTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.toolStripTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripTop.Location = new System.Drawing.Point(24, 24);
            this.toolStripTop.Name = "toolStripTop";
            this.toolStripTop.Size = new System.Drawing.Size(744, 25);
            this.toolStripTop.TabIndex = 2;
            // 
            // GLControl
            // 
            this.GLControl.AccumBits = ((byte)(0));
            this.GLControl.AutoCheckErrors = false;
            this.GLControl.AutoFinish = false;
            this.GLControl.AutoMakeCurrent = true;
            this.GLControl.AutoSwapBuffers = false;
            this.GLControl.BackColor = System.Drawing.Color.Black;
            this.GLControl.ColorBits = ((byte)(32));
            this.GLControl.DepthBits = ((byte)(16));
            this.GLControl.Location = new System.Drawing.Point(98, 64);
            this.GLControl.Name = "GLControl";
            this.GLControl.Size = new System.Drawing.Size(33, 29);
            this.GLControl.StencilBits = ((byte)(0));
            this.GLControl.TabIndex = 3;
            this.GLControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GLControl_KeyDown);
            this.GLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GLControl_MouseDown);
            this.GLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GLControl_MouseMove);
            this.GLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GLControl_MouseUp);
            // 
            // toolStripFile
            // 
            this.toolStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNewFile,
            this.toolStripOpenFile,
            this.toolStripSaveFile,
            this.toolStripSaveAs,
            this.toolStripSeparator1,
            this.toolStripExit});
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.Size = new System.Drawing.Size(48, 20);
            this.toolStripFile.Text = "Файл";
            // 
            // toolStripNewFile
            // 
            this.toolStripNewFile.Name = "toolStripNewFile";
            this.toolStripNewFile.Size = new System.Drawing.Size(153, 22);
            this.toolStripNewFile.Text = "Новый";
            this.toolStripNewFile.Click += new System.EventHandler(this.toolStripNewFile_Click);
            // 
            // toolStripOpenFile
            // 
            this.toolStripOpenFile.Name = "toolStripOpenFile";
            this.toolStripOpenFile.Size = new System.Drawing.Size(153, 22);
            this.toolStripOpenFile.Text = "Открыть";
            this.toolStripOpenFile.Click += new System.EventHandler(this.toolStripOpenFile_Click);
            // 
            // toolStripSaveFile
            // 
            this.toolStripSaveFile.Name = "toolStripSaveFile";
            this.toolStripSaveFile.Size = new System.Drawing.Size(153, 22);
            this.toolStripSaveFile.Text = "Сохранить";
            this.toolStripSaveFile.Click += new System.EventHandler(this.toolStripSaveFile_Click);
            // 
            // toolStripSaveAs
            // 
            this.toolStripSaveAs.Name = "toolStripSaveAs";
            this.toolStripSaveAs.Size = new System.Drawing.Size(153, 22);
            this.toolStripSaveAs.Text = "Сохранить как";
            this.toolStripSaveAs.Click += new System.EventHandler(this.toolStripSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // toolStripExit
            // 
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Size = new System.Drawing.Size(153, 22);
            this.toolStripExit.Text = "Выход";
            this.toolStripExit.Click += new System.EventHandler(this.toolStripExit_Click);
            // 
            // toolStripProgram
            // 
            this.toolStripProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSettings,
            this.toolStripAdjMatrix});
            this.toolStripProgram.Name = "toolStripProgram";
            this.toolStripProgram.Size = new System.Drawing.Size(84, 20);
            this.toolStripProgram.Text = "Программа";
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.Size = new System.Drawing.Size(188, 22);
            this.toolStripSettings.Text = "Настройки";
            this.toolStripSettings.Click += new System.EventHandler(this.toolStripSettings_Click);
            // 
            // toolStripAdjMatrix
            // 
            this.toolStripAdjMatrix.Checked = true;
            this.toolStripAdjMatrix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripAdjMatrix.Name = "toolStripAdjMatrix";
            this.toolStripAdjMatrix.Size = new System.Drawing.Size(188, 22);
            this.toolStripAdjMatrix.Text = "Матрица смежности";
            this.toolStripAdjMatrix.Click += new System.EventHandler(this.toolStripAdjMatrix_Click);
            // 
            // toolStripAlgorithms
            // 
            this.toolStripAlgorithms.Name = "toolStripAlgorithms";
            this.toolStripAlgorithms.Size = new System.Drawing.Size(83, 20);
            this.toolStripAlgorithms.Text = "Алгоритмы";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFile,
            this.toolStripProgram,
            this.toolStripAlgorithms});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(768, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Graph files|*.graph";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Graph files|*.graph";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(768, 367);
            this.Controls.Add(this.GLControl);
            this.Controls.Add(this.toolStripTop);
            this.Controls.Add(this.toolStripLeft);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.toolStripLeft.ResumeLayout(false);
            this.toolStripLeft.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripLeft;
        private System.Windows.Forms.ToolStripButton buttonSelection;
        private System.Windows.Forms.ToolStripButton buttonVertex;
        private System.Windows.Forms.ToolStripButton buttonEdge;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStrip toolStripTop;
        private Tao.Platform.Windows.SimpleOpenGlControl GLControl;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripAlgorithms;
        private System.Windows.Forms.ToolStripMenuItem toolStripSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripProgram;
        private System.Windows.Forms.ToolStripMenuItem toolStripExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveAs;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripOpenFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripNewFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripAdjMatrix;
    }
}

