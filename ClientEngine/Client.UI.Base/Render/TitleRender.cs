using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Client.UI.Base.Enums;
using Client.UI.Base.Forms;
using System.IO;
using Client.UI.Base.Forms.Title;

namespace Client.UI.Base.Render
{
    public abstract class TitleRender : ContorlRenderBase<FormBase>
    {
        private bool m_MouseDown = false;
        private Configs.TitleRenderConfig m_Rconfig = null;

        public delegate void TitleButtonOnClickHandler(object sender, Point mousePoint);
        public event TitleButtonOnClickHandler TitleButtonOnClick;
        /// <summary>
        /// 判断鼠标点是否在系统按钮矩形内
        /// </summary>
        /// <param name="mousePoint">鼠标坐标点</param>
        /// <returns>如果存在，返回系统按钮索引，否则返回 -1</returns>
        private int SearchPointInRects(Point mousePoint)
        {
            bool isFind = false;
            int index = 0;
            foreach (TitleButton button in m_Rconfig.ButtonList)
            {

                if (button.TitleBoxRect.Contains(mousePoint))
                {
                    isFind = true;
                    break;
                }
                index++;
            }
            if (isFind)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        public bool IsInTitleRegion(Point mousePoint)
        {
            if (SearchPointInRects(mousePoint) != -1)
                return true;
            return false;
        }

        public override void Render(Graphics g)
        {
            foreach (TitleButton tb in m_Rconfig.ButtonList)
            {
                g.DrawImage(tb.CurrentStatuImage, tb.TitleBoxRect);
            }

        }

        private void Invalidate(Rectangle rect)
        {
            this.m_HostForm.Invalidate(rect);
        }

        #region >Mouse Action <

        public void ProcessMouseOperate(Point mousePoint, MouseOperate operate)
        {
            switch (operate)
            {
                case MouseOperate.Move:
                    this.ProcessMouseMove(mousePoint);
                    break;
                case MouseOperate.Down:
                    this.ProcessMouseDown(mousePoint);
                    break;
                case MouseOperate.Up:
                    this.ProcessMouseUP(mousePoint);
                    break;
                case MouseOperate.Leave:
                    this.ProcessMouseLeave();
                    break;
            }
        }

        private void ProcessMouseMove(Point mousePoint)
        {
            bool hide = true;
            int index = SearchPointInRects(mousePoint);
            if (index != -1)
            {
                hide = false;  //显示提示文本
                if (!m_MouseDown)
                {
                    //if (this.m_Trconfig.ButtonList[index].State != ButtonStatus.Hover)
                    //{
                    //    toolTip = SystemButtonArray[index].ToolTip;
                    //}
                    this.m_Rconfig.ButtonList[index].State = ButtonStatus.Hover;

                }
                else
                {
                    if (this.m_Rconfig.ButtonList[index].State == ButtonStatus.PressedLeave)
                    {
                        this.m_Rconfig.ButtonList[index].State = ButtonStatus.Pressed;
                    }
                }

                //其他按钮的状态为 Normal
                for (int i = 0; i < this.m_Rconfig.ButtonList.Count; i++)
                {
                    if (i != index)
                        this.m_Rconfig.ButtonList[i].State = ButtonStatus.Normal;
                }
            }
            else
            {
                for (int i = 0; i < this.m_Rconfig.ButtonList.Count; i++)
                {
                    if (!m_MouseDown)
                    {
                        this.m_Rconfig.ButtonList[i].State = ButtonStatus.Normal;
                    }
                    else
                    {
                        if (this.m_Rconfig.ButtonList[i].State == ButtonStatus.Pressed)
                        {
                            this.m_Rconfig.ButtonList[i].State = ButtonStatus.PressedLeave;
                        }
                    }

                }
            }
        }

        private void ProcessMouseDown(Point mousePoint)
        {

            int index = SearchPointInRects(mousePoint);
            if (index != -1)
            {
                m_MouseDown = true;
                this.m_Rconfig.ButtonList[index].State = ButtonStatus.Pressed;
            }
        }

        private void ProcessMouseUP(Point mousePoint)
        {
            this.m_MouseDown = false;

            int index = SearchPointInRects(mousePoint);
            
            if (index != -1)
            {
                TitleButton tb=this.m_Rconfig.ButtonList[index];
                if (tb.State == ButtonStatus.Pressed)
                {
                    tb.State = ButtonStatus.Normal;
                    tb.ButtonPressed(mousePoint);
                    m_HostForm.OnTitleButtonClick(tb, mousePoint);
                }
            }
            else
            {
                ProcessMouseLeave();
            }
        }

        private void ProcessMouseLeave()
        {
            for (int i = 0; i < this.m_Rconfig.ButtonList.Count; i++)
            {
                if (this.m_Rconfig.ButtonList[i].State == ButtonStatus.Pressed)
                {
                    this.m_Rconfig.ButtonList[i].State = ButtonStatus.PressedLeave;
                }
                else
                { //所有按钮的状态为 Normal
                    this.m_Rconfig.ButtonList[i].State = ButtonStatus.Normal;
                }
            }

            //if (CloseBoxVisibale)
            //    this.CloseBoxState = this.CloseBoxState != ButtonStatus.Pressed ? ButtonStatus.Normal : ButtonStatus.PressedLeave;
            //if (minimizeBoxVisibale)
            //    this.MinimizeBoxState = this.MinimizeBoxState != ButtonStatus.Pressed ? ButtonStatus.Normal : ButtonStatus.PressedLeave;

            //if (maximizeBoxVisibale)
            //    this.MaximizeBoxState = this.MaximizeBoxState != ButtonStatus.Pressed ? ButtonStatus.Normal : ButtonStatus.PressedLeave;
            //this.HideToolTip();
        }



        #endregion

        public override void InitConfig()
        {
            m_Rconfig = new Configs.TitleRenderConfig();
            this.AddCustomButtons();
        }

        void tb_ButtonOnClick(object sender, Point mousePoint)
        {
            if (TitleButtonOnClick != null)
                TitleButtonOnClick(sender, mousePoint);
        }

        public abstract void AddCustomButtons();

        protected void AddButton(TitleButton tb)
        {
            m_Rconfig.ButtonList.Add(tb);
        }
    }



    

    

    
}
