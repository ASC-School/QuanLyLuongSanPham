using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DevExpress.XtraBars
{
    internal class Ribbon
    {
        public static object RibbonControlColorScheme { get; internal set; }

        internal class RibbonControl
        {
            public RibbonControl()
            {
            }

            public object ApplicationButtonImageOptions { get; internal set; }
            public bool AutoSizeItems { get; internal set; }
            public object ColorScheme { get; internal set; }
            public object ExpandCollapseItem { get; internal set; }
            public ImeMode ImeMode { get; internal set; }
            public XtraBars.BarItem SearchEditItem { get; internal set; }
            public object Items { get; internal set; }
            public Point Location { get; internal set; }
            public int MaxItemId { get; internal set; }
            public object RibbonStyle { get; internal set; }
        }

        internal class RibbonPage
        {
            public RibbonPage()
            {
            }
        }

        internal class RibbonPageGroup
        {
            public RibbonPageGroup()
            {
            }
        }

        internal class ApplicationMenu
        {
            private IContainer components;

            public ApplicationMenu(IContainer components)
            {
                this.components = components;
            }
        }
    }
}