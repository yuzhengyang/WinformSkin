using System;
using System.Collections.Generic;
using System.Text;

namespace Client.UI.Base.Enums
{
    public enum RoundStyle
    {
        None,
        All,
        Left,
        Right,
        Top,
        Bottom,
        BottomLeft,
        BottomRight
    }

    public enum MouseOperate
    {
        Normal,
        Move,
        Down,
        Up,
        Leave,
        Hover
    }

    public enum ButtonStatus
    {
        Normal,
        Hover,
        Pressed,
        PressedLeave
    }

    public enum DecorationType
    {
        None,
        BottomMirror,
        Custom
    }

    public enum DrawStyle
    {
        None,
        Img,
        Draw
    }
}
