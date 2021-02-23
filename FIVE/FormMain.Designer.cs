namespace WindowsFormsApplication1
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.双人游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单人游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.我先ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电脑先ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电脑自个玩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析局面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vCF测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vCT测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(12, 11);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(61, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.退出ToolStripMenuItem,
            this.分析局面ToolStripMenuItem,
            this.vCF测试ToolStripMenuItem,
            this.vCT测试ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.游戏ToolStripMenuItem.Text = "游戏";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.双人游戏ToolStripMenuItem,
            this.单人游戏ToolStripMenuItem,
            this.电脑自个玩ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 双人游戏ToolStripMenuItem
            // 
            this.双人游戏ToolStripMenuItem.Name = "双人游戏ToolStripMenuItem";
            this.双人游戏ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.双人游戏ToolStripMenuItem.Text = "双人游戏";
            this.双人游戏ToolStripMenuItem.Click += new System.EventHandler(this.双人游戏ToolStripMenuItem_Click);
            // 
            // 单人游戏ToolStripMenuItem
            // 
            this.单人游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.我先ToolStripMenuItem,
            this.电脑先ToolStripMenuItem});
            this.单人游戏ToolStripMenuItem.Name = "单人游戏ToolStripMenuItem";
            this.单人游戏ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.单人游戏ToolStripMenuItem.Text = "单人游戏";
            // 
            // 我先ToolStripMenuItem
            // 
            this.我先ToolStripMenuItem.Name = "我先ToolStripMenuItem";
            this.我先ToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.我先ToolStripMenuItem.Text = "我先";
            this.我先ToolStripMenuItem.Click += new System.EventHandler(this.我先ToolStripMenuItem_Click);
            // 
            // 电脑先ToolStripMenuItem
            // 
            this.电脑先ToolStripMenuItem.Name = "电脑先ToolStripMenuItem";
            this.电脑先ToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.电脑先ToolStripMenuItem.Text = "电脑先";
            this.电脑先ToolStripMenuItem.Click += new System.EventHandler(this.电脑先ToolStripMenuItem_Click);
            // 
            // 电脑自个玩ToolStripMenuItem
            // 
            this.电脑自个玩ToolStripMenuItem.Name = "电脑自个玩ToolStripMenuItem";
            this.电脑自个玩ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.电脑自个玩ToolStripMenuItem.Text = "电脑自个玩";
            this.电脑自个玩ToolStripMenuItem.Click += new System.EventHandler(this.电脑自个玩ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.退出ToolStripMenuItem.Text = "悔棋";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 分析局面ToolStripMenuItem
            // 
            this.分析局面ToolStripMenuItem.Name = "分析局面ToolStripMenuItem";
            this.分析局面ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.分析局面ToolStripMenuItem.Text = "分析局面";
            this.分析局面ToolStripMenuItem.Click += new System.EventHandler(this.分析局面ToolStripMenuItem_Click);
            // 
            // vCF测试ToolStripMenuItem
            // 
            this.vCF测试ToolStripMenuItem.Name = "vCF测试ToolStripMenuItem";
            this.vCF测试ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.vCF测试ToolStripMenuItem.Text = "VCF测试";
            this.vCF测试ToolStripMenuItem.Click += new System.EventHandler(this.vCF测试ToolStripMenuItem_Click);
            // 
            // vCT测试ToolStripMenuItem
            // 
            this.vCT测试ToolStripMenuItem.Name = "vCT测试ToolStripMenuItem";
            this.vCT测试ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.vCT测试ToolStripMenuItem.Text = "VCT测试";
            this.vCT测试ToolStripMenuItem.Click += new System.EventHandler(this.vCT测试ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 46);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(867, 812);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(932, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "x:-1,y:-1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(935, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 851);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分析局面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vCF测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 双人游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单人游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 我先ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 电脑先ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 电脑自个玩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vCT测试ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

