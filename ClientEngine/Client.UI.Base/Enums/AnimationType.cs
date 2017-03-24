using System;
using System.Collections.Generic;
using System.Text;

namespace Client.UI.Base.Enums
{
    public enum AnimationType
    {
        Custom,
        Rotate,
        HorizSlide,
        VertSlide,
        Scale,
        ScaleAndRotate,
        HorizSlideAndRotate,
        ScaleAndHorizSlide,
        Transparent,
        Leaf,
        Mosaic,
        Particles,
        VertBlind,
        HorizBlind
    }

    public enum AnimateMode
    {
        Show,
        Hide,
        Update,
        BeginUpdate
    }
}
