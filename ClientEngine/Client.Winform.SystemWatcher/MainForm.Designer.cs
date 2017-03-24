namespace Client.Winform.SystemWatcher
{
    partial class MainForm
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
            Client.UI.Contorls.UIToolBarItem uiToolBarItem1 = new Client.UI.Contorls.UIToolBarItem();
            Client.UI.Contorls.UIToolBarItem uiToolBarItem2 = new Client.UI.Contorls.UIToolBarItem();
            Client.UI.Contorls.UIToolBarItem uiToolBarItem3 = new Client.UI.Contorls.UIToolBarItem();
            Client.UI.Contorls.UIToolBarItem uiToolBarItem4 = new Client.UI.Contorls.UIToolBarItem();
            Client.UI.Contorls.UIToolBarItem uiToolBarItem5 = new Client.UI.Contorls.UIToolBarItem();
            Client.UI.Contorls.UIToolBarItem uiToolBarItem6 = new Client.UI.Contorls.UIToolBarItem();
            Client.UI.Contorls.UIToolBarItem uiToolBarItem7 = new Client.UI.Contorls.UIToolBarItem();
            this.tabPageServer = new System.Windows.Forms.TabPage();
            this.MainMenuStrip = new Client.UI.Contorls.UIContextMenuStrip();
            this.添加插件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMenu = new System.Windows.Forms.TabControl();
            this.tabPagePlugins = new System.Windows.Forms.TabPage();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.tabPageQuickFixed = new System.Windows.Forms.TabPage();
            this.tabPageCommand = new System.Windows.Forms.TabPage();
            this.tabPageWebsite = new System.Windows.Forms.TabPage();
            this.tabPageVersus = new System.Windows.Forms.TabPage();
            this.uiToolBar1 = new Client.UI.Contorls.UIToolBar();
            this.MainMenuStrip.SuspendLayout();
            this.tabControlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageServer
            // 
            this.tabPageServer.Location = new System.Drawing.Point(4, 22);
            this.tabPageServer.Name = "tabPageServer";
            this.tabPageServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServer.Size = new System.Drawing.Size(1316, 592);
            this.tabPageServer.TabIndex = 0;
            this.tabPageServer.Text = "服务器管理";
            this.tabPageServer.UseVisualStyleBackColor = true;
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Arrow = System.Drawing.Color.Black;
            this.MainMenuStrip.Back = System.Drawing.Color.White;
            this.MainMenuStrip.BackRadius = 4;
            this.MainMenuStrip.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.MainMenuStrip.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.MainMenuStrip.Fore = System.Drawing.Color.Black;
            this.MainMenuStrip.HoverFore = System.Drawing.Color.White;
            this.MainMenuStrip.ItemAnamorphosis = true;
            this.MainMenuStrip.ItemBorder = System.Drawing.Color.LightSeaGreen;
            this.MainMenuStrip.ItemBorderShow = true;
            this.MainMenuStrip.ItemHover = System.Drawing.Color.LightSeaGreen;
            this.MainMenuStrip.ItemPressed = System.Drawing.Color.LightSeaGreen;
            this.MainMenuStrip.ItemRadius = 4;
            this.MainMenuStrip.ItemRadiusStyle = Client.UI.Base.Enums.RoundStyle.All;
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加插件ToolStripMenuItem});
            this.MainMenuStrip.ItemSplitter = System.Drawing.Color.LightSeaGreen;
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.RadiusStyle = Client.UI.Base.Enums.RoundStyle.All;
            this.MainMenuStrip.Size = new System.Drawing.Size(125, 26);
            this.MainMenuStrip.TitleAnamorphosis = true;
            this.MainMenuStrip.TitleColor = System.Drawing.Color.DarkCyan;
            this.MainMenuStrip.TitleRadius = 4;
            this.MainMenuStrip.TitleRadiusStyle = Client.UI.Base.Enums.RoundStyle.All;
            // 
            // 添加插件ToolStripMenuItem
            // 
            this.添加插件ToolStripMenuItem.Name = "添加插件ToolStripMenuItem";
            this.添加插件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加插件ToolStripMenuItem.Text = "添加插件";
            // 
            // tabControlMenu
            // 
            this.tabControlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMenu.Controls.Add(this.tabPageServer);
            this.tabControlMenu.Controls.Add(this.tabPagePlugins);
            this.tabControlMenu.Controls.Add(this.tabPageLog);
            this.tabControlMenu.Controls.Add(this.tabPageQuickFixed);
            this.tabControlMenu.Controls.Add(this.tabPageCommand);
            this.tabControlMenu.Controls.Add(this.tabPageWebsite);
            this.tabControlMenu.Controls.Add(this.tabPageVersus);
            this.tabControlMenu.Location = new System.Drawing.Point(-3, 90);
            this.tabControlMenu.Name = "tabControlMenu";
            this.tabControlMenu.SelectedIndex = 0;
            this.tabControlMenu.Size = new System.Drawing.Size(1324, 618);
            this.tabControlMenu.TabIndex = 4;
            // 
            // tabPagePlugins
            // 
            this.tabPagePlugins.BackColor = System.Drawing.Color.Transparent;
            this.tabPagePlugins.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlugins.Name = "tabPagePlugins";
            this.tabPagePlugins.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlugins.Size = new System.Drawing.Size(1316, 592);
            this.tabPagePlugins.TabIndex = 1;
            this.tabPagePlugins.Text = "插件管理";
            // 
            // tabPageLog
            // 
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Size = new System.Drawing.Size(1316, 592);
            this.tabPageLog.TabIndex = 2;
            this.tabPageLog.Text = "日志查看";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // tabPageQuickFixed
            // 
            this.tabPageQuickFixed.Location = new System.Drawing.Point(4, 22);
            this.tabPageQuickFixed.Name = "tabPageQuickFixed";
            this.tabPageQuickFixed.Size = new System.Drawing.Size(1316, 592);
            this.tabPageQuickFixed.TabIndex = 3;
            this.tabPageQuickFixed.Text = "快速维护";
            this.tabPageQuickFixed.UseVisualStyleBackColor = true;
            // 
            // tabPageCommand
            // 
            this.tabPageCommand.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommand.Name = "tabPageCommand";
            this.tabPageCommand.Size = new System.Drawing.Size(1316, 592);
            this.tabPageCommand.TabIndex = 4;
            this.tabPageCommand.Text = "命令控制";
            this.tabPageCommand.UseVisualStyleBackColor = true;
            // 
            // tabPageWebsite
            // 
            this.tabPageWebsite.Location = new System.Drawing.Point(4, 22);
            this.tabPageWebsite.Name = "tabPageWebsite";
            this.tabPageWebsite.Size = new System.Drawing.Size(1316, 592);
            this.tabPageWebsite.TabIndex = 5;
            this.tabPageWebsite.Text = "站点管理";
            this.tabPageWebsite.UseVisualStyleBackColor = true;
            // 
            // tabPageVersus
            // 
            this.tabPageVersus.Location = new System.Drawing.Point(4, 22);
            this.tabPageVersus.Name = "tabPageVersus";
            this.tabPageVersus.Size = new System.Drawing.Size(1316, 592);
            this.tabPageVersus.TabIndex = 6;
            this.tabPageVersus.Text = "赛事相关";
            this.tabPageVersus.UseVisualStyleBackColor = true;
            // 
            // uiToolBar1
            // 
            this.uiToolBar1.BackColor = System.Drawing.Color.Transparent;
            this.uiToolBar1.ForeColor = System.Drawing.Color.Cornsilk;
            uiToolBarItem1.Image = global::Client.Winform.SystemWatcher.Properties.Resources.toolBarServer;
            uiToolBarItem1.Tag = null;
            uiToolBarItem1.Text = "服务器管理";
            uiToolBarItem2.Image = global::Client.Winform.SystemWatcher.Properties.Resources.toolBarPlugins;
            uiToolBarItem2.Tag = null;
            uiToolBarItem2.Text = "插件管理";
            uiToolBarItem3.Image = global::Client.Winform.SystemWatcher.Properties.Resources.toolBarLog;
            uiToolBarItem3.Tag = null;
            uiToolBarItem3.Text = "日志查看";
            uiToolBarItem4.Image = global::Client.Winform.SystemWatcher.Properties.Resources.toolBarQuickFixed;
            uiToolBarItem4.Tag = null;
            uiToolBarItem4.Text = "快速维护";
            uiToolBarItem5.Image = global::Client.Winform.SystemWatcher.Properties.Resources.toolBarCommand;
            uiToolBarItem5.Tag = null;
            uiToolBarItem5.Text = "命令控制";
            uiToolBarItem6.Image = global::Client.Winform.SystemWatcher.Properties.Resources.toolBarWebsites;
            uiToolBarItem6.Tag = null;
            uiToolBarItem6.Text = "站点管理";
            uiToolBarItem7.Image = global::Client.Winform.SystemWatcher.Properties.Resources.toolBarVersus;
            uiToolBarItem7.Tag = null;
            uiToolBarItem7.Text = "赛事相关";
            this.uiToolBar1.Items.Add(uiToolBarItem1);
            this.uiToolBar1.Items.Add(uiToolBarItem2);
            this.uiToolBar1.Items.Add(uiToolBarItem3);
            this.uiToolBar1.Items.Add(uiToolBarItem4);
            this.uiToolBar1.Items.Add(uiToolBarItem5);
            this.uiToolBar1.Items.Add(uiToolBarItem6);
            this.uiToolBar1.Items.Add(uiToolBarItem7);
            this.uiToolBar1.ItemSpace = 5;
            this.uiToolBar1.Location = new System.Drawing.Point(12, 18);
            this.uiToolBar1.Name = "uiToolBar1";
            this.uiToolBar1.Size = new System.Drawing.Size(990, 82);
            this.uiToolBar1.TabIndex = 3;
            this.uiToolBar1.Text = "uiToolBar1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1318, 727);
            this.Controls.Add(this.tabControlMenu);
            this.Controls.Add(this.uiToolBar1);
            this.Name = "MainForm";
            this.Text = "服务监控";
            this.MainMenuStrip.ResumeLayout(false);
            this.tabControlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageServer;
        private Client.UI.Contorls.UIContextMenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 添加插件ToolStripMenuItem;
        public System.Windows.Forms.TabControl tabControlMenu;
        private System.Windows.Forms.TabPage tabPagePlugins;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TabPage tabPageQuickFixed;
        private System.Windows.Forms.TabPage tabPageCommand;
        private System.Windows.Forms.TabPage tabPageWebsite;
        private System.Windows.Forms.TabPage tabPageVersus;
        public Client.UI.Contorls.UIToolBar uiToolBar1;
    }
}

