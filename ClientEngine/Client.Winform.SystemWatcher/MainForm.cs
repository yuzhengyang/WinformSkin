using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Client.Winform.SystemWatcher
{
    public partial class MainForm : UI.Forms.Main
    {
        private string[] m_TabFormsName;

        public MainForm()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            this.m_TabFormsName = new string[] { "FrmServer", "FrmPlugin", "FrmLogViewer", "FrmQuickLog" };
            AddTabPagesByIndex(0);

            this.TitleButtonOnClick += MainForm_TitleButtonOnClick;
            this.tabControlMenu.SizeMode = TabSizeMode.Fixed;
            this.tabControlMenu.ItemSize = new System.Drawing.Size(0, 1);
        }

        #region >菜单相关<
        void MainForm_TitleButtonOnClick(object sender, Point mousePoint)
        {
            if (sender is UI.Render.MenuButton)
            {
                MainMenuStrip.Show(this, mousePoint.X - 3, mousePoint.Y + 10);
            }
        }

        private void 添加插件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region >事件<
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //this.tabControlMenu.Region = new Region(new RectangleF(this.tabPageServer.Left, this.tabPageServer.Top, this.tabPageServer.Width, this.tabPageServer.Height));
        }

        private void uiToolBar1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void tabControlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void AddTabPagesByIndex(int index)
        {
            if (this.tabControlMenu.TabPages[index].Tag != null)
                return;
            if (index >= m_TabFormsName.Length)
            {
                MessageBox.Show("请添加m_TabFormsName变量");
                return;
            }
            Form win = Assembly.GetAssembly(this.GetType()).CreateInstance("Client.Winform.SystemWatcher.TabForm." + m_TabFormsName[index]) as Form;
            if (win == null)
                win = new Form();
            win.TopLevel = false;
            win.Visible = true;
            win.FormBorderStyle = FormBorderStyle.None;
            win.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.tabControlMenu.TabPages[index].Controls.Add(win);
            this.tabControlMenu.TabPages[index].Tag = win;
            win.Size = new Size(this.tabControlMenu.Size.Width, this.tabControlMenu.Size.Height);
        }

        public void JumpMenuTabByTabIndex(int index)
        {
            this.uiToolBar1.SelectIndex(index);
        }
    }
}
