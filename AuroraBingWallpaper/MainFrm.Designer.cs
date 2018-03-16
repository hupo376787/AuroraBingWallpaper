namespace AuroraBingWallpaper
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.comboBox_Area = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_Wallpaper = new System.Windows.Forms.PictureBox();
            this.button_8days = new System.Windows.Forms.Button();
            this.button_SetWallpaper = new System.Windows.Forms.Button();
            this.textBox_Copyright = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Wallpaper)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_Area
            // 
            this.comboBox_Area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Area.FormattingEnabled = true;
            this.comboBox_Area.Location = new System.Drawing.Point(47, 14);
            this.comboBox_Area.Name = "comboBox_Area";
            this.comboBox_Area.Size = new System.Drawing.Size(100, 20);
            this.comboBox_Area.TabIndex = 0;
            this.comboBox_Area.SelectedIndexChanged += new System.EventHandler(this.comboBox_Area_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "区域";
            // 
            // pictureBox_Wallpaper
            // 
            this.pictureBox_Wallpaper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Wallpaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Wallpaper.Location = new System.Drawing.Point(12, 41);
            this.pictureBox_Wallpaper.Name = "pictureBox_Wallpaper";
            this.pictureBox_Wallpaper.Size = new System.Drawing.Size(820, 465);
            this.pictureBox_Wallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Wallpaper.TabIndex = 6;
            this.pictureBox_Wallpaper.TabStop = false;
            this.pictureBox_Wallpaper.DoubleClick += new System.EventHandler(this.pictureBox_Wallpaper_DoubleClick);
            // 
            // button_8days
            // 
            this.button_8days.Location = new System.Drawing.Point(153, 11);
            this.button_8days.Name = "button_8days";
            this.button_8days.Size = new System.Drawing.Size(80, 23);
            this.button_8days.TabIndex = 8;
            this.button_8days.Text = "近17日壁纸";
            this.button_8days.UseVisualStyleBackColor = true;
            this.button_8days.Click += new System.EventHandler(this.button_8days_Click);
            // 
            // button_SetWallpaper
            // 
            this.button_SetWallpaper.Location = new System.Drawing.Point(239, 11);
            this.button_SetWallpaper.Name = "button_SetWallpaper";
            this.button_SetWallpaper.Size = new System.Drawing.Size(80, 23);
            this.button_SetWallpaper.TabIndex = 10;
            this.button_SetWallpaper.Text = "设置为桌面";
            this.button_SetWallpaper.UseVisualStyleBackColor = true;
            this.button_SetWallpaper.Click += new System.EventHandler(this.button_SetWallpaper_Click);
            // 
            // textBox_Copyright
            // 
            this.textBox_Copyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Copyright.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Copyright.Location = new System.Drawing.Point(325, 15);
            this.textBox_Copyright.Name = "textBox_Copyright";
            this.textBox_Copyright.ReadOnly = true;
            this.textBox_Copyright.Size = new System.Drawing.Size(507, 14);
            this.textBox_Copyright.TabIndex = 11;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 516);
            this.Controls.Add(this.textBox_Copyright);
            this.Controls.Add(this.button_SetWallpaper);
            this.Controls.Add(this.button_8days);
            this.Controls.Add(this.pictureBox_Wallpaper);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Area);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aurora 必应壁纸";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Wallpaper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Area;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_Wallpaper;
        private System.Windows.Forms.Button button_8days;
        private System.Windows.Forms.Button button_SetWallpaper;
        private System.Windows.Forms.TextBox textBox_Copyright;
    }
}

