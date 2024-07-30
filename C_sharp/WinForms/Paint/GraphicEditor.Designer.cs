namespace Paint
{
    partial class GraphicEditor
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicEditor));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.brushToolButton = new System.Windows.Forms.ToolStripButton();
            this.eraserToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lineThicknessToolStripDropDownButton = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.rectangleToolButton = new System.Windows.Forms.ToolStripButton();
            this.ellipseToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.colorChooseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fillingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brushToolButton,
            this.eraserToolButton,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.lineThicknessToolStripDropDownButton,
            this.toolStripSeparator4,
            this.rectangleToolButton,
            this.ellipseToolButton,
            this.toolStripSeparator5,
            this.colorChooseToolStripButton,
            this.fillingToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // brushToolButton
            // 
            this.brushToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.brushToolButton.Image = ((System.Drawing.Image)(resources.GetObject("brushToolButton.Image")));
            this.brushToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.brushToolButton.Name = "brushToolButton";
            this.brushToolButton.Size = new System.Drawing.Size(23, 22);
            this.brushToolButton.Text = "Кисть";
            this.brushToolButton.Click += new System.EventHandler(this.brushToolButton_Click);
            // 
            // eraserToolButton
            // 
            this.eraserToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraserToolButton.Image = ((System.Drawing.Image)(resources.GetObject("eraserToolButton.Image")));
            this.eraserToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraserToolButton.Name = "eraserToolButton";
            this.eraserToolButton.Size = new System.Drawing.Size(23, 22);
            this.eraserToolButton.Text = "Ластик";
            this.eraserToolButton.Click += new System.EventHandler(this.eraserToolButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lineThicknessToolStripDropDownButton
            // 
            this.lineThicknessToolStripDropDownButton.Name = "lineThicknessToolStripDropDownButton";
            this.lineThicknessToolStripDropDownButton.Size = new System.Drawing.Size(109, 25);
            this.lineThicknessToolStripDropDownButton.TextChanged += new System.EventHandler(this.lineThicknessToolStripDropDownButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // rectangleToolButton
            // 
            this.rectangleToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleToolButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleToolButton.Image")));
            this.rectangleToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleToolButton.Name = "rectangleToolButton";
            this.rectangleToolButton.Size = new System.Drawing.Size(23, 22);
            this.rectangleToolButton.Text = "Прямоугольник";
            this.rectangleToolButton.Click += new System.EventHandler(this.rectangleToolButton_Click);
            // 
            // ellipseToolButton
            // 
            this.ellipseToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ellipseToolButton.Image = ((System.Drawing.Image)(resources.GetObject("ellipseToolButton.Image")));
            this.ellipseToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ellipseToolButton.Name = "ellipseToolButton";
            this.ellipseToolButton.Size = new System.Drawing.Size(23, 22);
            this.ellipseToolButton.Text = "Эллипс";
            this.ellipseToolButton.Click += new System.EventHandler(this.ellipseToolButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // colorChooseToolStripButton
            // 
            this.colorChooseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.colorChooseToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("colorChooseToolStripButton.Image")));
            this.colorChooseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorChooseToolStripButton.Name = "colorChooseToolStripButton";
            this.colorChooseToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.colorChooseToolStripButton.Text = "Цвет рисования";
            this.colorChooseToolStripButton.Click += new System.EventHandler(this.colorChooseToolStripButton_Click);
            // 
            // fillingToolStripButton
            // 
            this.fillingToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fillingToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fillingToolStripButton.Image")));
            this.fillingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillingToolStripButton.Name = "fillingToolStripButton";
            this.fillingToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.fillingToolStripButton.Text = "Заливка";
            this.fillingToolStripButton.Click += new System.EventHandler(this.fillingToolStripButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileMenuItem,
            this.openFileMenuItem,
            this.toolStripSeparator1,
            this.exportMenuItem,
            this.splitToolStripMenuItem,
            this.exitMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // newFileMenuItem
            // 
            this.newFileMenuItem.Name = "newFileMenuItem";
            this.newFileMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newFileMenuItem.Text = "Создать";
            this.newFileMenuItem.Click += new System.EventHandler(this.newFileMenuItem_Click);
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFileMenuItem.Text = "Открыть";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportMenuItem.Text = "Экспорт...";
            this.exportMenuItem.Click += new System.EventHandler(this.exportMenuItem_Click);
            // 
            // splitToolStripMenuItem
            // 
            this.splitToolStripMenuItem.Name = "splitToolStripMenuItem";
            this.splitToolStripMenuItem.Size = new System.Drawing.Size(177, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitMenuItem.Text = "Выход";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.HelpRequest += new System.EventHandler(this.colorChooseToolStripButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 52);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(800, 401);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // GraphicEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "GraphicEditor";
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.GraphicEditor_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripButton brushToolButton;
        private System.Windows.Forms.ToolStripButton eraserToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton rectangleToolButton;
        private System.Windows.Forms.ToolStripButton ellipseToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripButton colorChooseToolStripButton;
        private System.Windows.Forms.ToolStripComboBox lineThicknessToolStripDropDownButton;
        private System.Windows.Forms.ToolStripButton fillingToolStripButton;
    }
}

