using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Client.UI.Base.Enums;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Client.UI.Base.Utils;

namespace Client.UI.Base.Render
{
    public class UIToolStripRenderer : ToolStripRenderer
    {
         private ToolStripColorTable _colorTable;

        public UIToolStripRenderer()
        {
            this.ColorTable = new ToolStripColorTable();
        }

        public UIToolStripRenderer(ToolStripColorTable colorTable)
        {
            this.ColorTable = colorTable;
        }

        private void DrawCircle(Graphics g, Rectangle bounds, Color borderColor, Color fillColor)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(bounds);
                path.CloseFigure();
                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawPath(pen, path);
                }
                using (Brush brush = new SolidBrush(fillColor))
                {
                    g.FillPath(brush, path);
                }
            }
        }

        private void DrawDottedGrip(Graphics g, Rectangle bounds, bool vertical, bool largeDot, Color innerColor, Color outerColor)
        {
            bounds.Height -= 3;
            Point point = new Point(bounds.X, bounds.Y);
            Rectangle rectangle = new Rectangle(0, 0, 2, 2);
            using (new SmoothingModeGraphics(g))
            {
                int height;
                IntPtr hdc;
                if (vertical)
                {
                    height = bounds.Height;
                    point.Y += 8;
                    for (int i = 0; point.Y > 4; i += 4)
                    {
                        point.Y = height - (2 + i);
                        if (largeDot)
                        {
                            rectangle.Location = point;
                            this.DrawCircle(g, rectangle, outerColor, innerColor);
                        }
                        else
                        {
                            int crColor = ColorTranslator.ToWin32(innerColor);
                            int num4 = ColorTranslator.ToWin32(outerColor);
                            hdc = g.GetHdc();
                            SetPixel(hdc, point.X, point.Y, crColor);
                            SetPixel(hdc, point.X + 1, point.Y, num4);
                            SetPixel(hdc, point.X, point.Y + 1, num4);
                            SetPixel(hdc, point.X + 3, point.Y, crColor);
                            SetPixel(hdc, point.X + 4, point.Y, num4);
                            SetPixel(hdc, point.X + 3, point.Y + 1, num4);
                            g.ReleaseHdc(hdc);
                        }
                    }
                }
                else
                {
                    bounds.Inflate(-2, 0);
                    height = bounds.Width;
                    point.X += 2;
                    for (int j = 1; point.X > 0; j += 4)
                    {
                        point.X = height - (2 + j);
                        if (largeDot)
                        {
                            rectangle.Location = point;
                            this.DrawCircle(g, rectangle, outerColor, innerColor);
                        }
                        else
                        {
                            int num6 = ColorTranslator.ToWin32(innerColor);
                            int num7 = ColorTranslator.ToWin32(outerColor);
                            hdc = g.GetHdc();
                            SetPixel(hdc, point.X, point.Y, num6);
                            SetPixel(hdc, point.X + 1, point.Y, num7);
                            SetPixel(hdc, point.X, point.Y + 1, num7);
                            SetPixel(hdc, point.X + 3, point.Y, num6);
                            SetPixel(hdc, point.X + 4, point.Y, num7);
                            SetPixel(hdc, point.X + 3, point.Y + 1, num7);
                            g.ReleaseHdc(hdc);
                        }
                    }
                }
            }
        }

        private void DrawDottedStatusGrip(Graphics g, Rectangle bounds, Color innerColor, Color outerColor)
        {
            Rectangle rectangle = new Rectangle(0, 0, 2, 2);
            rectangle.X = bounds.Width - 0x11;
            rectangle.Y = bounds.Height - 8;
            using (new SmoothingModeGraphics(g))
            {
                this.DrawCircle(g, rectangle, outerColor, innerColor);
                rectangle.X = bounds.Width - 12;
                this.DrawCircle(g, rectangle, outerColor, innerColor);
                rectangle.X = bounds.Width - 7;
                this.DrawCircle(g, rectangle, outerColor, innerColor);
                rectangle.Y = bounds.Height - 13;
                this.DrawCircle(g, rectangle, outerColor, innerColor);
                rectangle.Y = bounds.Height - 0x12;
                this.DrawCircle(g, rectangle, outerColor, innerColor);
                rectangle.Y = bounds.Height - 13;
                rectangle.X = bounds.Width - 12;
                this.DrawCircle(g, rectangle, outerColor, innerColor);
            }
        }

        private void DrawSolidStatusGrip(Graphics g, Rectangle bounds, Color innerColor, Color outerColor)
        {
            using (new SmoothingModeGraphics(g))
            {
                using (Pen pen = new Pen(innerColor))
                {
                    using (Pen pen2 = new Pen(outerColor))
                    {
                        g.DrawLine(pen2, new Point(bounds.Width - 14, bounds.Height - 6), new Point(bounds.Width - 4, bounds.Height - 0x10));
                        g.DrawLine(pen, new Point(bounds.Width - 13, bounds.Height - 6), new Point(bounds.Width - 4, bounds.Height - 15));
                        g.DrawLine(pen2, new Point(bounds.Width - 12, bounds.Height - 6), new Point(bounds.Width - 4, bounds.Height - 14));
                        g.DrawLine(pen, new Point(bounds.Width - 11, bounds.Height - 6), new Point(bounds.Width - 4, bounds.Height - 13));
                        g.DrawLine(pen2, new Point(bounds.Width - 10, bounds.Height - 6), new Point(bounds.Width - 4, bounds.Height - 12));
                        g.DrawLine(pen, new Point(bounds.Width - 9, bounds.Height - 6), new Point(bounds.Width - 4, bounds.Height - 11));
                        g.DrawLine(pen2, new Point(bounds.Width - 8, bounds.Height - 6), new Point(bounds.Width - 4, bounds.Height - 10));
                        g.DrawLine(pen, new Point(bounds.Width - 7, bounds.Height - 6), new Point(bounds.Width - 4, bounds.Height - 9));
                        g.DrawLine(pen2, new Point(bounds.Width - 6, bounds.Height - 6), new Point(bounds.Width - 4, bounds.Height - 8));
                        g.DrawLine(pen, new Point(bounds.Width - 5, bounds.Height - 6), new Point(bounds.Width - 4, bounds.Height - 7));
                    }
                }
            }
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                e.ArrowColor = this.ColorTable.Arrow;
            }
            if ((e.Item.Owner is ToolStripDropDown) && (e.Item is ToolStripMenuItem))
            {
                Rectangle arrowRectangle = e.ArrowRectangle;
                e.ArrowRectangle = arrowRectangle;
            }
            base.OnRenderArrow(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripButton item = e.Item as ToolStripButton;
            Graphics graphics = e.Graphics;
            if (item == null)
            {
                return;
            }
            LinearGradientMode mode = (toolStrip.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            SmoothingModeGraphics graphics2 = new SmoothingModeGraphics(graphics);
            Rectangle bounds = new Rectangle(Point.Empty, item.Size);
            if (item.BackgroundImage != null)
            {
                Rectangle clipRect = item.Selected ? item.ContentRectangle : bounds;
                GraphicUtils.DrawBackgroundImage(graphics, item.BackgroundImage, this.ColorTable.Back, item.BackgroundImageLayout, bounds, clipRect);
            }
            if (item.CheckState == CheckState.Unchecked)
            {
                if (item.Selected)
                {
                    Bitmap img = item.Pressed ? ((Bitmap) this.ColorTable.BaseItemDown) : ((Bitmap) this.ColorTable.BaseItemMouse);
                    if (img != null)
                    {
                        GraphicUtils.DrawRect(graphics, img, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                    }
                    else
                    {
                        Color baseItemHover = this.ColorTable.BaseItemHover;
                        if (item.Pressed)
                        {
                            baseItemHover = this.ColorTable.BaseItemPressed;
                        }
                        GraphicUtils.RenderBackgroundInternal(graphics, bounds, baseItemHover, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                    }
                    goto Label_0302;
                }
                if (!(toolStrip is ToolStripOverflow))
                {
                    goto Label_0302;
                }
                using (Brush brush = new SolidBrush(this.ColorTable.ItemHover))
                {
                    graphics.FillRectangle(brush, bounds);
                    goto Label_0302;
                }
            }
            Bitmap baseItemMouse = (Bitmap) this.ColorTable.BaseItemMouse;
            Color baseColor = ControlPaint.Light(this.ColorTable.ItemHover);
            if (item.Selected)
            {
                baseColor = this.ColorTable.ItemHover;
                baseItemMouse = (Bitmap) this.ColorTable.BaseItemMouse;
            }
            if (item.Pressed)
            {
                baseColor = this.ColorTable.ItemPressed;
                baseItemMouse = (Bitmap) this.ColorTable.BaseItemDown;
            }
            if (baseItemMouse == null)
            {
                GraphicUtils.RenderBackgroundInternal(graphics, bounds, baseColor, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
            }
            else
            {
                GraphicUtils.DrawRect(graphics, baseItemMouse, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
            }
        Label_0302:
            graphics2.Dispose();
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripDropDownItem item = e.Item as ToolStripDropDownItem;
            if (item == null)
            {
                return;
            }
            LinearGradientMode mode = (toolStrip.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            Graphics graphics = e.Graphics;
            SmoothingModeGraphics graphics2 = new SmoothingModeGraphics(graphics);
            Rectangle r = new Rectangle(Point.Empty, item.Size);
            if (item.Pressed && item.HasDropDownItems)
            {
                if (this.ColorTable.BaseItemDown != null)
                {
                    GraphicUtils.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemDown, r, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                }
                else
                {
                    GraphicUtils.RenderBackgroundInternal(graphics, r, this.ColorTable.BaseItemPressed, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                }
            }
            else if (item.Selected)
            {
                if (this.ColorTable.BaseItemDown != null)
                {
                    GraphicUtils.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemMouse, r, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                }
                else
                {
                    GraphicUtils.RenderBackgroundInternal(graphics, r, this.ColorTable.BaseItemHover, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                }
            }
            else
            {
                if (toolStrip is ToolStripOverflow)
                {
                    using (Brush brush = new SolidBrush(this.ColorTable.Back))
                    {
                        graphics.FillRectangle(brush, r);
                        goto Label_0256;
                    }
                }
                base.OnRenderDropDownButtonBackground(e);
            }
        Label_0256:
            graphics2.Dispose();
        }

        protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
            if (e.GripStyle == ToolStripGripStyle.Visible)
            {
                Rectangle gripBounds = e.GripBounds;
                bool vertical = e.GripDisplayStyle == ToolStripGripDisplayStyle.Vertical;
                ToolStrip toolStrip = e.ToolStrip;
                Graphics g = e.Graphics;
                if (vertical)
                {
                    gripBounds.X = e.AffectedBounds.X;
                    gripBounds.Width = e.AffectedBounds.Width;
                    if (toolStrip is MenuStrip)
                    {
                        if (e.AffectedBounds.Height > e.AffectedBounds.Width)
                        {
                            vertical = false;
                            gripBounds.Y = e.AffectedBounds.Y;
                        }
                        else
                        {
                            toolStrip.GripMargin = new Padding(0, 2, 0, 2);
                            gripBounds.Y = e.AffectedBounds.Y;
                            gripBounds.Height = e.AffectedBounds.Height;
                        }
                    }
                    else
                    {
                        toolStrip.GripMargin = new Padding(2, 2, 4, 2);
                        gripBounds.X++;
                        gripBounds.Width++;
                    }
                }
                else
                {
                    gripBounds.Y = e.AffectedBounds.Y;
                    gripBounds.Height = e.AffectedBounds.Height;
                }
                this.DrawDottedGrip(g, gripBounds, vertical, false, this.ColorTable.Back, ControlPaint.Dark(this.ColorTable.Base, 0.3f));
            }
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            Rectangle affectedBounds = e.AffectedBounds;
            if (toolStrip is ToolStripDropDown)
            {
                bool flag = toolStrip.RightToLeft == RightToLeft.Yes;
                Rectangle rectangle2 = affectedBounds;
                Rectangle rect = affectedBounds;
                if (flag)
                {
                    rect.X -= 2;
                    rectangle2.X = rect.X;
                }
                else
                {
                    rect.X += 2;
                    rectangle2.X = rect.Right;
                }
                rect.Y++;
                rect.Height -= 2;
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, this.ColorTable.TitleColor, this.ColorTable.Back, 90f))
                {
                    Blend blend = new Blend();
                    float[] numArray = new float[3];
                    numArray[1] = 0.2f;
                    numArray[2] = 1f;
                    blend.Positions = numArray;
                    float[] numArray2 = new float[3];
                    numArray2[1] = 0.1f;
                    numArray2[2] = 0.9f;
                    blend.Factors = numArray2;
                    brush.Blend = blend;
                    rect.Y++;
                    rect.Height -= 2;
                    using (GraphicsPath path = GraphicUtils.CreatePath(rect, this.ColorTable.TitleRadius, this.ColorTable.TitleRadiusStyle, false))
                    {
                        using (new SmoothingModeGraphics(graphics))
                        {
                            if (this.ColorTable.TitleAnamorphosis)
                            {
                                graphics.FillPath(brush, path);
                            }
                            else
                            {
                                SolidBrush brush2 = new SolidBrush(this.ColorTable.TitleColor);
                                graphics.FillPath(brush2, path);
                            }
                            return;
                        }
                    }
                }
            }
            base.OnRenderImageMargin(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            if ((toolStrip is ToolStripDropDown) && (e.Item is ToolStripMenuItem))
            {
                Rectangle imageRectangle = e.ImageRectangle;
                if (e.Item.RightToLeft == RightToLeft.Yes)
                {
                    imageRectangle.X -= 2;
                }
                else
                {
                    imageRectangle.X += 2;
                }
                imageRectangle.Width = 13;
                imageRectangle.Y++;
                imageRectangle.Height -= 3;
                using (new SmoothingModeGraphics(graphics))
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddRectangle(imageRectangle);
                        using (PathGradientBrush brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = Color.White;
                            brush.SurroundColors = new Color[] { ControlPaint.Light(this.ColorTable.Back) };
                            Blend blend = new Blend();
                            float[] numArray = new float[3];
                            numArray[1] = 0.3f;
                            numArray[2] = 1f;
                            blend.Positions = numArray;
                            float[] numArray2 = new float[3];
                            numArray2[1] = 0.5f;
                            numArray2[2] = 1f;
                            blend.Factors = numArray2;
                            brush.Blend = blend;
                            graphics.FillRectangle(brush, imageRectangle);
                        }
                    }
                    using (Pen pen = new Pen(ControlPaint.Light(this.ColorTable.Back)))
                    {
                        graphics.DrawRectangle(pen, imageRectangle);
                    }
                    GraphicUtils.DrawCheckedFlag(graphics, imageRectangle, this.ColorTable.Fore);
                    return;
                }
            }
            base.OnRenderItemCheck(e);
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            if ((toolStrip is ToolStripDropDown) && (e.Item is ToolStripMenuItem))
            {
                ToolStripMenuItem item = (ToolStripMenuItem) e.Item;
                if (item.Checked)
                {
                    return;
                }
                Rectangle imageRectangle = e.ImageRectangle;
                if (e.Item.RightToLeft == RightToLeft.Yes)
                {
                    imageRectangle.X -= 2;
                }
                else
                {
                    imageRectangle.X += 2;
                }
                using (new InterpolationModeGraphics(graphics))
                {
                    ToolStripItemImageRenderEventArgs args = new ToolStripItemImageRenderEventArgs(graphics, e.Item, e.Image, imageRectangle);
                    base.OnRenderItemImage(args);
                    return;
                }
            }
            base.OnRenderItemImage(e);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripItem item = e.Item;
            if (toolStrip is ToolStripDropDown)
            {
                e.TextColor = item.Selected ? this.ColorTable.HoverFore : this.ColorTable.Fore;
            }
            else
            {
                e.TextColor = item.Selected ? this.ColorTable.BaseHoverFore : this.ColorTable.BaseFore;
            }
            if ((toolStrip is ToolStripDropDown) && (e.Item is ToolStripMenuItem))
            {
                Rectangle textRectangle = e.TextRectangle;
                e.TextRectangle = textRectangle;
            }
            if ((!(toolStrip is ToolStripDropDown) && this.ColorTable.BaseForeAnamorphosis) && !string.IsNullOrEmpty(e.Item.Text))
            {
                Graphics graphics = e.Graphics;
                Image image = ImageUtils.ImageLightEffect(e.Item.Text, e.Item.Font, e.TextColor, this.ColorTable.BaseForeAnamorphosisColor, this.ColorTable.BaseForeAnamorphosisBorder);
                graphics.DrawImage(image, (int) (e.TextRectangle.Left - (this.ColorTable.BaseForeAnamorphosisBorder / 2)), (int) (e.TextRectangle.Top - (this.ColorTable.BaseForeAnamorphosisBorder / 2)));
            }
            else
            {
                base.OnRenderItemText(e);
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripItem item = e.Item;
            if (item.Enabled)
            {
                Graphics g = e.Graphics;
                Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
                if (toolStrip is MenuStrip)
                {
                    LinearGradientMode mode = (toolStrip.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
                    if (item.Selected)
                    {
                        GraphicUtils.RenderBackgroundInternal(g, rect, this.ColorTable.ItemHover, this.ColorTable.ItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, true, true, mode);
                    }
                    else if (item.Pressed)
                    {
                        GraphicUtils.RenderBackgroundInternal(g, rect, this.ColorTable.ItemPressed, this.ColorTable.ItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, true, true, mode);
                    }
                    else
                    {
                        base.OnRenderMenuItemBackground(e);
                    }
                }
                else if (toolStrip is ToolStripDropDown)
                {
                    rect = new Rectangle(new Point(-2, 0), new Size(e.Item.Size.Width + 5, e.Item.Size.Height + 1));
                    if (item.RightToLeft == RightToLeft.Yes)
                    {
                        rect.X += 4;
                    }
                    else
                    {
                        rect.X += 4;
                    }
                    rect.Width -= 8;
                    rect.Height--;
                    if (item.Selected)
                    {
                        GraphicUtils.RenderBackgroundInternal(g, rect, this.ColorTable.ItemHover, this.ColorTable.ItemBorder, this.ColorTable.Back, this.ColorTable.ItemRadiusStyle, this.ColorTable.ItemRadius, this.ColorTable.ItemBorderShow, this.ColorTable.ItemAnamorphosis, LinearGradientMode.Vertical);
                    }
                    else
                    {
                        base.OnRenderMenuItemBackground(e);
                    }
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
        }

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStripItem item = e.Item;
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            bool rightToLeft = item.RightToLeft == RightToLeft.Yes;
            new SmoothingModeGraphics(graphics);
            this.RenderOverflowBackground(e, rightToLeft);
            bool flag2 = toolStrip.Orientation == Orientation.Horizontal;
            Rectangle empty = Rectangle.Empty;
            if (rightToLeft)
            {
                empty = new Rectangle(0, item.Height - 8, 10, 5);
            }
            else
            {
                empty = new Rectangle(item.Width - 12, item.Height - 8, 10, 5);
            }
            ArrowDirection direction = flag2 ? ArrowDirection.Down : ArrowDirection.Right;
            int x = (rightToLeft && flag2) ? -1 : 1;
            empty.Offset(x, 1);
            Color color = toolStrip.Enabled ? this.ColorTable.Fore : SystemColors.ControlDark;
            using (Brush brush = new SolidBrush(color))
            {
                GraphicUtils.RenderArrowInternal(graphics, empty, direction, brush);
            }
            if (flag2)
            {
                using (Pen pen = new Pen(color))
                {
                    graphics.DrawLine(pen, (int) (empty.Right - 8), (int) (empty.Y - 2), (int) (empty.Right - 2), (int) (empty.Y - 2));
                    graphics.DrawLine(pen, (int) (empty.Right - 8), (int) (empty.Y - 1), (int) (empty.Right - 2), (int) (empty.Y - 1));
                    return;
                }
            }
            using (Pen pen2 = new Pen(color))
            {
                graphics.DrawLine(pen2, empty.X, empty.Y, empty.X, empty.Bottom - 1);
                graphics.DrawLine(pen2, empty.X, empty.Y + 1, empty.X, empty.Bottom);
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Rectangle contentRectangle = e.Item.ContentRectangle;
            Graphics g = e.Graphics;
            if (toolStrip is ToolStripDropDown)
            {
                if (e.Item.RightToLeft != RightToLeft.Yes)
                {
                    contentRectangle.X += 0x1a;
                }
                contentRectangle.Width -= 0x1c;
            }
            this.RenderSeparatorLine(g, contentRectangle, this.ColorTable.BaseItemSplitter, this.ColorTable.Back, SystemColors.ControlLightLight, e.Vertical);
        }

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripSplitButton item = e.Item as ToolStripSplitButton;
            if (item != null)
            {
                Graphics graphics = e.Graphics;
                LinearGradientMode mode = (toolStrip.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
                Rectangle bounds = new Rectangle(Point.Empty, item.Size);
                new SmoothingModeGraphics(graphics);
                Color arrowColor = toolStrip.Enabled ? this.ColorTable.Fore : SystemColors.ControlDark;
                if (item.BackgroundImage != null)
                {
                    Rectangle clipRect = item.Selected ? item.ContentRectangle : bounds;
                    GraphicUtils.DrawBackgroundImage(graphics, item.BackgroundImage, this.ColorTable.Back, item.BackgroundImageLayout, bounds, clipRect);
                }
                if (item.ButtonPressed)
                {
                    if (this.ColorTable.BaseItemDown != null)
                    {
                        GraphicUtils.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemDown, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                    }
                    else
                    {
                        Rectangle buttonBounds = item.ButtonBounds;
                        Padding padding = (item.RightToLeft == RightToLeft.Yes) ? new Padding(0, 1, 1, 1) : new Padding(1, 1, 0, 1);
                        buttonBounds = DeflateRect(buttonBounds, padding);
                        GraphicUtils.RenderBackgroundInternal(graphics, bounds, this.ColorTable.BaseItemHover, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                        buttonBounds.Inflate(-1, -1);
                        graphics.SetClip(buttonBounds);
                        GraphicUtils.RenderBackgroundInternal(graphics, buttonBounds, this.ColorTable.BaseItemPressed, this.ColorTable.BaseItemBorder, this.ColorTable.Back, RoundStyle.Left, false, true, mode);
                        graphics.ResetClip();
                        using (Pen pen = new Pen(this.ColorTable.BaseItemSplitter))
                        {
                            graphics.DrawLine(pen, item.SplitterBounds.Left, item.SplitterBounds.Top, item.SplitterBounds.Left, item.SplitterBounds.Bottom);
                        }
                    }
                    base.DrawArrow(new ToolStripArrowRenderEventArgs(graphics, item, item.DropDownButtonBounds, arrowColor, ArrowDirection.Down));
                }
                else if (item.Pressed || item.DropDownButtonPressed)
                {
                    if (this.ColorTable.BaseItemDown != null)
                    {
                        GraphicUtils.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemDown, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                    }
                    else
                    {
                        GraphicUtils.RenderBackgroundInternal(graphics, bounds, this.ColorTable.BaseItemPressed, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                    }
                    base.DrawArrow(new ToolStripArrowRenderEventArgs(graphics, item, item.DropDownButtonBounds, arrowColor, ArrowDirection.Down));
                }
                else if (item.Selected)
                {
                    if (this.ColorTable.BaseItemMouse != null)
                    {
                        GraphicUtils.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemMouse, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                    }
                    else
                    {
                        GraphicUtils.RenderBackgroundInternal(graphics, bounds, this.ColorTable.BaseItemHover, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                        using (Pen pen2 = new Pen(this.ColorTable.BaseItemSplitter))
                        {
                            graphics.DrawLine(pen2, item.SplitterBounds.Left, item.SplitterBounds.Top, item.SplitterBounds.Left, item.SplitterBounds.Bottom);
                        }
                    }
                    base.DrawArrow(new ToolStripArrowRenderEventArgs(graphics, item, item.DropDownButtonBounds, arrowColor, ArrowDirection.Down));
                }
                else
                {
                    base.DrawArrow(new ToolStripArrowRenderEventArgs(graphics, item, item.DropDownButtonBounds, arrowColor, ArrowDirection.Down));
                }
            }
            else
            {
                base.OnRenderSplitButtonBackground(e);
            }
        }

        protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            this.DrawSolidStatusGrip(e.Graphics, e.AffectedBounds, this.ColorTable.Back, ControlPaint.Dark(this.ColorTable.Base, 0.3f));
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;
            Rectangle affectedBounds = e.AffectedBounds;
            if (toolStrip is ToolStripDropDown)
            {
                GraphicUtils.CreateRegion(toolStrip, affectedBounds, this.ColorTable.BackRadius, this.ColorTable.RadiusStyle);
                using (SolidBrush brush = new SolidBrush(this.ColorTable.Back))
                {
                    g.FillRectangle(brush, affectedBounds);
                    return;
                }
            }
            LinearGradientMode mode = (toolStrip.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            GraphicUtils.RenderBackgroundInternal(g, affectedBounds, this.ColorTable.Base, this.ColorTable.ItemBorder, this.ColorTable.Back, this.ColorTable.RadiusStyle, this.ColorTable.BackRadius, 0.35f, false, false, mode);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            Rectangle affectedBounds = e.AffectedBounds;
            if (toolStrip is ToolStripDropDown)
            {
                if (this.ColorTable.RadiusStyle == RoundStyle.None)
                {
                    affectedBounds.Width--;
                    affectedBounds.Height--;
                }
                using (new SmoothingModeGraphics(graphics))
                {
                    using (GraphicsPath path = GraphicUtils.CreatePath(affectedBounds, this.ColorTable.BackRadius, this.ColorTable.RadiusStyle, true))
                    {
                        using (Pen pen = new Pen(this.ColorTable.DropDownImageSeparator))
                        {
                            path.Widen(pen);
                            graphics.DrawPath(pen, path);
                        }
                    }
                }
                if (toolStrip is ToolStripOverflow)
                {
                    return;
                }
                affectedBounds.Inflate(-1, -1);
                using (GraphicsPath path2 = GraphicUtils.CreatePath(affectedBounds, this.ColorTable.BackRadius, this.ColorTable.RadiusStyle, true))
                {
                    using (Pen pen2 = new Pen(this.ColorTable.Back))
                    {
                        graphics.DrawPath(pen2, path2);
                    }
                    return;
                }
            }
            base.OnRenderToolStripBorder(e);
        }

        public void RenderOverflowBackground(ToolStripItemRenderEventArgs e, bool rightToLeft)
        {
            Color empty = Color.Empty;
            Graphics g = e.Graphics;
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripOverflowButton item = e.Item as ToolStripOverflowButton;
            Rectangle bounds = new Rectangle(Point.Empty, item.Size);
            Rectangle withinBounds = bounds;
            bool flag = !(item.GetCurrentParent() is MenuStrip);
            bool flag2 = toolStrip.Orientation == Orientation.Horizontal;
            if (flag2)
            {
                bounds.X += (bounds.Width - 12) + 1;
                bounds.Width = 12;
                if (rightToLeft)
                {
                    bounds = RTLTranslate(bounds, withinBounds);
                }
            }
            else
            {
                bounds.Y = (bounds.Height - 12) + 1;
                bounds.Height = 12;
            }
            if (item.Pressed)
            {
                empty = this.ColorTable.ItemPressed;
            }
            else if (item.Selected)
            {
                empty = this.ColorTable.ItemHover;
            }
            else
            {
                empty = this.ColorTable.Base;
            }
            if (flag)
            {
                using (Pen pen = new Pen(this.ColorTable.Base))
                {
                    Point point = new Point(bounds.Left - 1, bounds.Height - 2);
                    Point point2 = new Point(bounds.Left, bounds.Height - 2);
                    if (rightToLeft)
                    {
                        point.X = bounds.Right + 1;
                        point2.X = bounds.Right;
                    }
                    g.DrawLine(pen, point, point2);
                }
            }
            LinearGradientMode mode = flag2 ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            GraphicUtils.RenderBackgroundInternal(g, bounds, empty, this.ColorTable.ItemBorder, this.ColorTable.Back, RoundStyle.None, 0, 0.35f, false, false, mode);
            if (flag)
            {
                using (Brush brush = new SolidBrush(this.ColorTable.Base))
                {
                    if (flag2)
                    {
                        Point point3 = new Point(bounds.X - 2, 0);
                        Point point4 = new Point(bounds.X - 1, 1);
                        if (rightToLeft)
                        {
                            point3.X = bounds.Right + 1;
                            point4.X = bounds.Right;
                        }
                        g.FillRectangle(brush, point3.X, point3.Y, 1, 1);
                        g.FillRectangle(brush, point4.X, point4.Y, 1, 1);
                    }
                    else
                    {
                        g.FillRectangle(brush, bounds.Width - 3, bounds.Top - 1, 1, 1);
                        g.FillRectangle(brush, bounds.Width - 2, bounds.Top - 2, 1, 1);
                    }
                }
                using (Brush brush2 = new SolidBrush(this.ColorTable.Base))
                {
                    if (flag2)
                    {
                        Rectangle rect = new Rectangle(bounds.X - 1, 0, 1, 1);
                        if (rightToLeft)
                        {
                            rect.X = bounds.Right;
                        }
                        g.FillRectangle(brush2, rect);
                    }
                    else
                    {
                        g.FillRectangle(brush2, bounds.X, bounds.Top - 1, 1, 1);
                    }
                }
            }
        }

        public void RenderSeparatorLine(Graphics g, Rectangle rect, Color baseColor, Color backColor, Color shadowColor, bool vertical)
        {
            if (vertical)
            {
                rect.Y += 2;
                rect.Height -= 4;
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, baseColor, backColor, LinearGradientMode.Vertical))
                {
                    using (Pen pen = new Pen(brush))
                    {
                        g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom);
                    }
                    return;
                }
            }
            using (LinearGradientBrush brush2 = new LinearGradientBrush(rect, baseColor, backColor, 180f))
            {
                Blend blend = new Blend();
                blend.Positions = new float[] { 0f, 0.2f, 0.5f, 0.8f, 1f };
                blend.Factors = new float[] { 1f, 0.3f, 0f, 0.3f, 1f };
                brush2.Blend = blend;
                using (Pen pen2 = new Pen(brush2))
                {
                    g.DrawLine(pen2, rect.X, rect.Y, rect.Right, rect.Y);
                    brush2.LinearColors = new Color[] { shadowColor, backColor };
                    pen2.Brush = brush2;
                    g.DrawLine(pen2, rect.X, rect.Y + 1, rect.Right, rect.Y + 1);
                }
            }
        }

        [DllImport("gdi32.dll")]
        private static extern uint SetPixel(IntPtr hdc, int X, int Y, int crColor);

        public ToolStripColorTable ColorTable
        {
            get
            {
                return this._colorTable;
            }
            set
            {
                this._colorTable = value;
            }
        }

        private  Rectangle DeflateRect(Rectangle rect, Padding padding)
        {
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect;
        }

        private Rectangle RTLTranslate(Rectangle bounds, Rectangle withinBounds)
        {
            bounds.X = withinBounds.Width - bounds.Right;
            return bounds;
        }
    }

    public class SmoothingModeGraphics : IDisposable
    {
        private Graphics _graphics;
        private SmoothingMode _oldMode;

        public SmoothingModeGraphics(Graphics graphics)
            : this(graphics, SmoothingMode.AntiAlias)
        {
        }

        public SmoothingModeGraphics(Graphics graphics, SmoothingMode newMode)
        {
            this._graphics = graphics;
            this._oldMode = graphics.SmoothingMode;
            graphics.SmoothingMode = newMode;
        }

        public void Dispose()
        {
            this._graphics.SmoothingMode = this._oldMode;
        }
    }

    public class InterpolationModeGraphics : IDisposable
    {
        private Graphics _graphics;
        private InterpolationMode _oldMode;

        public InterpolationModeGraphics(Graphics graphics)
            : this(graphics, InterpolationMode.HighQualityBicubic)
        {
        }

        public InterpolationModeGraphics(Graphics graphics, InterpolationMode newMode)
        {
            this._graphics = graphics;
            this._oldMode = graphics.InterpolationMode;
            graphics.InterpolationMode = newMode;
        }

        public void Dispose()
        {
            this._graphics.InterpolationMode = this._oldMode;
        }
    }

    public class ToolStripColorTable
    {
        private Color _arrow = Color.Black;
        private Color _back = Color.White;
        private int _backradius = 4;
        private Rectangle _backrectangle = new Rectangle(10, 10, 10, 10);
        private Color _base = Color.FromArgb(0x69, 200, 0xfe);
        private Color _baseFore = Color.Black;
        private bool _baseForeAnamorphosis;
        private int _baseForeAnamorphosisBorder = 4;
        private Color _baseForeAnamorphosisColor = Color.White;
        private Color _baseHoverFore = Color.White;
        private bool _baseItemAnamorphosis = true;
        private Color _baseItemBorder = Color.FromArgb(60, 0x94, 0xd4);
        private bool _baseItemBorderShow = true;
        private Image _baseItemDown = null; //Resources.allbtn_down;
        private Color _baseItemHover = Color.FromArgb(60, 0x94, 0xd4);
        private Image _baseItemMouse = null; //Resources.allbtn_highlight;
        private Color _baseItemPressed = Color.FromArgb(60, 0x94, 0xd4);
        private int _baseItemRadius = 4;
        private RoundStyle _baseItemRadiusStyle = RoundStyle.All;
        private Color _baseItemSplitter = Color.FromArgb(60, 0x94, 0xd4);
        private Color _dropDownImageSeparator = Color.FromArgb(0xc5, 0xc5, 0xc5);
        private Color _fore = Color.Black;
        private Color _hoverFore = Color.White;
        private bool _itemAnamorphosis = true;
        private Color _itemborder = Color.FromArgb(60, 0x94, 0xd4);
        private bool _itemBorderShow = true;
        private Color _itemHover = Color.FromArgb(60, 0x94, 0xd4);
        private Color _itemPressed = Color.FromArgb(60, 0x94, 0xd4);
        private int _itemRadius = 4;
        private RoundStyle _itemRadiusStyle = RoundStyle.All;
        private RoundStyle _radiusstyle = RoundStyle.All;
        private bool _titleAnamorphosis = true;
        private Color _titleColor = Color.FromArgb(0xd1, 0xe4, 0xec);
        private int _titleRadius = 4;
        private RoundStyle _titleRadiusStyle = RoundStyle.All;

        public Color Arrow
        {
            get
            {
                return this._arrow;
            }
            set
            {
                this._arrow = value;
            }
        }

        public Color Back
        {
            get
            {
                return this._back;
            }
            set
            {
                this._back = value;
            }
        }

        public int BackRadius
        {
            get
            {
                return this._backradius;
            }
            set
            {
                this._backradius = value;
            }
        }

        public Rectangle BackRectangle
        {
            get
            {
                return this._backrectangle;
            }
            set
            {
                this._backrectangle = value;
            }
        }

        public Color Base
        {
            get
            {
                return this._base;
            }
            set
            {
                this._base = value;
            }
        }

        public Color BaseFore
        {
            get
            {
                return this._baseFore;
            }
            set
            {
                this._baseFore = value;
            }
        }

        public bool BaseForeAnamorphosis
        {
            get
            {
                return this._baseForeAnamorphosis;
            }
            set
            {
                this._baseForeAnamorphosis = value;
            }
        }

        public int BaseForeAnamorphosisBorder
        {
            get
            {
                return this._baseForeAnamorphosisBorder;
            }
            set
            {
                this._baseForeAnamorphosisBorder = value;
            }
        }

        public Color BaseForeAnamorphosisColor
        {
            get
            {
                return this._baseForeAnamorphosisColor;
            }
            set
            {
                this._baseForeAnamorphosisColor = value;
            }
        }

        public Color BaseHoverFore
        {
            get
            {
                return this._baseHoverFore;
            }
            set
            {
                this._baseHoverFore = value;
            }
        }

        public bool BaseItemAnamorphosis
        {
            get
            {
                return this._baseItemAnamorphosis;
            }
            set
            {
                this._baseItemAnamorphosis = value;
            }
        }

        public Color BaseItemBorder
        {
            get
            {
                return this._baseItemBorder;
            }
            set
            {
                this._baseItemBorder = value;
            }
        }

        public bool BaseItemBorderShow
        {
            get
            {
                return this._baseItemBorderShow;
            }
            set
            {
                this._baseItemBorderShow = value;
            }
        }

        public Image BaseItemDown
        {
            get
            {
                return this._baseItemDown;
            }
            set
            {
                this._baseItemDown = value;
            }
        }

        public Color BaseItemHover
        {
            get
            {
                return this._baseItemHover;
            }
            set
            {
                this._baseItemHover = value;
            }
        }

        public Image BaseItemMouse
        {
            get
            {
                return this._baseItemMouse;
            }
            set
            {
                this._baseItemMouse = value;
            }
        }

        public Color BaseItemPressed
        {
            get
            {
                return this._baseItemPressed;
            }
            set
            {
                this._baseItemPressed = value;
            }
        }

        public int BaseItemRadius
        {
            get
            {
                return this._baseItemRadius;
            }
            set
            {
                this._baseItemRadius = value;
            }
        }

        public RoundStyle BaseItemRadiusStyle
        {
            get
            {
                return this._baseItemRadiusStyle;
            }
            set
            {
                this._baseItemRadiusStyle = value;
            }
        }

        public Color BaseItemSplitter
        {
            get
            {
                return this._baseItemSplitter;
            }
            set
            {
                this._baseItemSplitter = value;
            }
        }

        public Color DropDownImageSeparator
        {
            get
            {
                return this._dropDownImageSeparator;
            }
            set
            {
                this._dropDownImageSeparator = value;
            }
        }

        public Color Fore
        {
            get
            {
                return this._fore;
            }
            set
            {
                this._fore = value;
            }
        }

        public Color HoverFore
        {
            get
            {
                return this._hoverFore;
            }
            set
            {
                this._hoverFore = value;
            }
        }

        public bool ItemAnamorphosis
        {
            get
            {
                return this._itemAnamorphosis;
            }
            set
            {
                this._itemAnamorphosis = value;
            }
        }

        public Color ItemBorder
        {
            get
            {
                return this._itemborder;
            }
            set
            {
                this._itemborder = value;
            }
        }

        public bool ItemBorderShow
        {
            get
            {
                return this._itemBorderShow;
            }
            set
            {
                this._itemBorderShow = value;
            }
        }

        public Color ItemHover
        {
            get
            {
                return this._itemHover;
            }
            set
            {
                this._itemHover = value;
            }
        }

        public Color ItemPressed
        {
            get
            {
                return this._itemPressed;
            }
            set
            {
                this._itemPressed = value;
            }
        }

        public int ItemRadius
        {
            get
            {
                return this._itemRadius;
            }
            set
            {
                this._itemRadius = value;
            }
        }

        public RoundStyle ItemRadiusStyle
        {
            get
            {
                return this._itemRadiusStyle;
            }
            set
            {
                this._itemRadiusStyle = value;
            }
        }

        public RoundStyle RadiusStyle
        {
            get
            {
                return this._radiusstyle;
            }
            set
            {
                this._radiusstyle = value;
            }
        }

        public bool TitleAnamorphosis
        {
            get
            {
                return this._titleAnamorphosis;
            }
            set
            {
                this._titleAnamorphosis = value;
            }
        }

        public Color TitleColor
        {
            get
            {
                return this._titleColor;
            }
            set
            {
                this._titleColor = value;
            }
        }

        public int TitleRadius
        {
            get
            {
                return this._titleRadius;
            }
            set
            {
                this._titleRadius = value;
            }
        }

        public RoundStyle TitleRadiusStyle
        {
            get
            {
                return this._titleRadiusStyle;
            }
            set
            {
                this._titleRadiusStyle = value;
            }
        }
    }
}
