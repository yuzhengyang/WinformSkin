using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Client.UI.Base.Animations
{
    public interface IFakeControl
    {
        event EventHandler<PaintEventArgs> FramePainted;

        event EventHandler<PaintEventArgs> FramePainting;

        event EventHandler<TransfromNeededEventArg> TransfromNeeded;

        void InitParent(Control animatedControl, Padding padding);

        Bitmap BgBmp { get; set; }

        Bitmap Frame { get; set; }
    }
}
